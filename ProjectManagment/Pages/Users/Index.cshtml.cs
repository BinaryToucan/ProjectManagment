using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SimpleProjectManagement.Data;
using SimpleProjectManagement.Models;

namespace ProjectManagment.Pages.Users
{
    /// <summary>
    /// Модель страницы Index (список юзеров)
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
        /// Список юзеров
        /// </summary>
        public IList<User> Users { get;set; } = default!;

        /// <summary>
        /// Метод, который вызывается при инициализации страницы
        /// </summary>
        /// <returns></returns>
        public async Task OnGetAsync()
        {
            Users = await _context.Users.ToListAsync();
            var tasks = from m in _context.Tasks
                        select m;

            // Добавляем задачи юзеров
            foreach (User user in Users) { 
                user.Tasks = await tasks.Where(x => x.AssignId == user.Id).ToListAsync();
            }
        }
    }
}
