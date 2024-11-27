using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SimpleProjectManagement.Data;
using SimpleProjectManagement.Models;

namespace ProjectManagment.Pages.Users
{
    /// <summary>
    /// Модель страницы Details (информация об юзере)
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
        /// Юзер
        /// </summary>
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

            var user = await _context.Users.FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            else
            {
                var tasks = from m in _context.Tasks
                            select m;

                user.Tasks = await tasks.Where(x => x.AssignId == user.Id).ToListAsync();
                User = user;
            }
            return Page();
        }
    }
}
