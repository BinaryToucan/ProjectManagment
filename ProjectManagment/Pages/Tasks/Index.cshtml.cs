using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SimpleProjectManagement.Data;
using SimpleProjectManagement.Models;

namespace ProjectManagment.Pages.Tasks
{
    public class IndexModel : PageModel
    {
        private readonly SimpleProjectManagement.Data.ManagementDbContext _context;

        public IndexModel(SimpleProjectManagement.Data.ManagementDbContext context)
        {
            _context = context;
        }

        public IList<TaskTracker> TaskTracker { get;set; } = default!;

        public async Task OnGetAsync()
        {
            TaskTracker = await _context.Tasks
                .Include(t => t.Assign).ToListAsync();
        }
    }
}
