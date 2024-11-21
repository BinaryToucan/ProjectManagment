using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SimpleProjectManagement.Data;
using SimpleProjectManagement.Models;

namespace ProjectManagment.Pages.Tasks
{
    public class EditModel : PageModel
    {
        private readonly SimpleProjectManagement.Data.ManagementDbContext _context;

        public EditModel(SimpleProjectManagement.Data.ManagementDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TaskTracker TaskTracker { get; set; } = default!;

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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
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

        private bool TaskTrackerExists(int id)
        {
            return _context.Tasks.Any(e => e.Id == id);
        }
    }
}
