using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SimpleProjectManagement.Data;
using SimpleProjectManagement.Models;
using SimpleProjectManagement.Models.Enums;

namespace ProjectManagment.Pages.Tasks
{
    /// <summary>
    /// Модуль страницы Index (список задач)
    /// </summary>
    public class IndexModel : PageModel
    {
        /// <summary>
        /// Контекст Бд
        /// </summary>
        private readonly ManagementDbContext _context;

        /// <summary>
        /// Конструктор 
        /// </summary>
        /// <param name="context"> контекст бд </param>
        public IndexModel(ManagementDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Задачи
        /// </summary>
        public IList<TaskTracker> Tasks { get;set; } = default!;

        /// <summary>
        /// Поисковая строка (ищем по Title)
        /// </summary>
        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        /// <summary>
        /// Список статусов
        /// </summary>
        public SelectList? Statues { get; set; }

        /// <summary>
        /// Выбранный статус
        /// </summary>
        [BindProperty(SupportsGet = true)]
        public StatusTask? TaskStatus { get; set; }

        /// <summary>
        /// Cписок приоритетов
        /// </summary>
        public SelectList? Priorities { get; set; }

        /// <summary>
        /// Выбранный приоритет
        /// </summary>
        [BindProperty(SupportsGet = true)]
        public Priority? TaskPriority { get; set; }

        /// <summary>
        /// Метод инициализации
        /// </summary>
        /// <returns></returns>
        public async Task OnGetAsync()
        {
            var tasks = from m in _context.Tasks
                         select m;

            var users = from m in _context.Users
                        select m;

            // Если есть поиск по названию
            if (!string.IsNullOrEmpty(SearchString))
            {
                tasks = tasks.Where(s => s.Title.Contains(SearchString));
            }

            // Если есть поиск по статусу
            if (TaskStatus != null)
            {
                tasks = tasks.Where(x => x.Status == TaskStatus);
            }
            
            // Если есть поиск по приоритету
            if (TaskPriority != null)
            {
                tasks = tasks.Where(x => x.Priority == TaskPriority);
            }

            // Статусы задач по перечислению (enum)
            Statues = new SelectList(
                Enum.GetValues(typeof(StatusTask))
                    .Cast<StatusTask>()
                    .Select(e => new { Value = (int)e, Text = e.ToString() }),
                "Value",
                "Text"
            );

            // Приоритеты задач по перечислению (enum)
            Priorities = new SelectList(
                Enum.GetValues(typeof(Priority))
                    .Cast<Priority>()
                    .Select(e => new { Value = (int)e, Text = e.ToString() }),
                "Value",
                "Text"
            );


            Tasks = await tasks.ToListAsync();

            foreach (var task in Tasks) {
                task.Assign = await users.Where(u => u.Id == task.AssignId).FirstAsync();
            }
        }
    }
}
