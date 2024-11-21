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
    public class DetailsModel : PageModel
    {
        private readonly SimpleProjectManagement.Data.ManagementDbContext _context;

        public DetailsModel(SimpleProjectManagement.Data.ManagementDbContext context)
        {
            _context = context;
        }

        public TaskTracker TaskTracker { get; set; } = default!;

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
