using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SimpleProjectManagement.Data;
using SimpleProjectManagement.Models;

namespace ProjectManagment.Pages.Users
{
    /// <summary>
    /// Модель страницы Edit (редактирование юзера)
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
        /// <param name="context"> контекст БД</param>
        public EditModel(ManagementDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Юзер
        /// </summary>
        [BindProperty]
        public User User { get; set; } = default!;

        /// <summary>
        /// Метод инициализации
        /// </summary>
        /// <param name="id">id юзера</param>
        /// <returns></returns>
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user =  await _context.Users.FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            User = user;
            return Page();
        }

        /// <summary>
        /// Обновление юзера
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(User).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(User.Id))
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
        /// Существует ли юзер?
        /// </summary>
        /// <param name="id">id юзера</param>
        /// <returns> Есть ли такой юзер </returns>
        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
