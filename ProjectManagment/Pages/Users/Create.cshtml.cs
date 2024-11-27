using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SimpleProjectManagement.Data;
using SimpleProjectManagement.Models;

namespace ProjectManagment.Pages.Users
{
    /// <summary>
    /// Модель страницы Create (создание юзера)
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
            return Page();
        }

        /// <summary>
        /// Юзер
        /// </summary>
        [BindProperty]
        public User User { get; set; } = default!;

        /// <summary>
        /// Создание юзера
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Users.Add(User);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
