using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SimpleProjectManagement.Data;
using SimpleProjectManagement.Models;

namespace ProjectManagment.Pages.Tasks
{
    /// <summary>
    /// Модель страницы Details (описание задачи)
    /// </summary>
    public class DetailsModel : PageModel
    {
        /// <summary>
        /// Контекст Бд
        /// </summary>
        private readonly ManagementDbContext _context;

        /// <summary>
        /// Конструктор 
        /// </summary>
        /// <param name="context"> контекст бд </param>
        public DetailsModel(ManagementDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Задача
        /// </summary>
        public TaskTracker TaskTracker { get; set; } = default!;

        /// <summary>
        /// Метод инициализации
        /// </summary>
        /// <param name="id">id задачи</param>
        /// <returns></returns>
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tasktracker = await _context.Tasks.FirstOrDefaultAsync(m => m.Id == id);
            if (tasktracker == null)
            {
                return NotFound();
            }
            else
            {
                TaskTracker = tasktracker;
            }
            return Page();
        }
    }
}
