using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SimpleProjectManagement.Data;
using SimpleProjectManagement.Models;

namespace ProjectManagment.Pages.Tasks
{
    /// <summary>
    /// Модель страницы Create (создание задачи)
    /// </summary>
    public class CreateModel : PageModel
    {
        /// <summary>
        /// Контекст Бд
        /// </summary>
        private readonly ManagementDbContext _context;

        /// <summary>
        /// Конструктор 
        /// </summary>
        /// <param name="context"> контекст бд </param>
        public CreateModel(ManagementDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Метод инициализации
        /// </summary>
        /// <returns></returns>
        public IActionResult OnGet()
        {
            ViewData["AssignId"] = new SelectList(_context.Users, "Id", "Id");
                return Page();
        }

        /// <summary>
        /// Задача
        /// </summary>
        [BindProperty]
        public TaskTracker TaskTracker { get; set; } = default!;

        /// <summary>
        /// Создание задачи
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Tasks.Add(TaskTracker);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
