using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SimpleProjectManagement.Data;
using SimpleProjectManagement.Models;

namespace ProjectManagment.Pages.Tasks
{
    public class CreateModel : PageModel
    {
        private readonly ManagementDbContext _context;

        public CreateModel(ManagementDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["AssignId"] = new SelectList(_context.Users, "Id", "Id");
                return Page();
        }

        [BindProperty]
        public TaskTracker TaskTracker { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
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
