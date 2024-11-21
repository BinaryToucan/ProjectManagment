using Microsoft.EntityFrameworkCore;
using SimpleProjectManagement.Models;

namespace SimpleProjectManagement.Data
{
    public class ManagementDbContext : DbContext
    {
        public ManagementDbContext (DbContextOptions<ManagementDbContext> options)
            : base(options)
        {
        }

        public DbSet<TaskTracker> Tasks { get; set; } = default!;

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Настройка отношения "один ко многим" между Users и Task
            modelBuilder.Entity<User>()
                .HasMany(u => u.Tasks)
                .WithOne(o => o.Assign)
                .HasForeignKey(o => o.AssignId); // Указываем внешний ключ
        }
    }
}
