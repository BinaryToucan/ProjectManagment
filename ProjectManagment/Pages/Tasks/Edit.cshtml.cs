using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SimpleProjectManagement.Data;
using SimpleProjectManagement.Models;

namespace ProjectManagment.Pages.Tasks
{
    /// <summary>
    /// Модель страницы Edit (редактирование задачи)
    /// </summary>
    public class EditModel : PageModel
    {
        /// <summary>
        /// Контекст Бд
        /// </summary>
        private readonly ManagementDbContext _context;

        /// <summary>
        /// Конструктор 
        /// </summary>
        /// <param name="context"> контекст бд </param>
        public EditModel(ManagementDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Задача
        /// </summary>
        [BindProperty]
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

            var tasktracker =  await _context.Tasks.FirstOrDefaultAsync(m => m.Id == id);
            if (tasktracker == null)
            {
                return NotFound();
            }
            TaskTracker = tasktracker;
           ViewData["AssignId"] = new SelectList(_context.Users, "Id", "Id");
            return Page();
        }

        /// <summary>
        /// Обновление задачи
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(TaskTracker).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaskTrackerExists(TaskTracker.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        /// <summary>
        /// Существует ли задача
        /// </summary>
        /// <param name="id">id задачи</param>
        /// <returns> Существует ли задача </returns>
        private bool TaskTrackerExists(int id)
        {
            return _context.Tasks.Any(e => e.Id == id);
        }
    }
}
