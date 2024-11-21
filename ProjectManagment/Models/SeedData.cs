using Microsoft.EntityFrameworkCore;
using SimpleProjectManagement.Data;

namespace SimpleProjectManagement.Models;
public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new ManagementDbContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<ManagementDbContext>>()))
        {
            if (context == null || context.Tasks == null)
            {
                throw new ArgumentNullException("Null SimpleProjectManagementContext");
            }

            // Look for any movies.
            if (context.Tasks.Any())
            {
                return;   // DB has been seeded
            }

            context.Tasks.AddRange(
                new TaskTracker
                {
                    Title = "Test",
                    Description = "Test",
                    CreateDate = DateTime.Parse("1970-01-01")
                }
            );
            context.SaveChanges();
        }
    }
}
