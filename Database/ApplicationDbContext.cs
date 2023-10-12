using Entities;
using Microsoft.EntityFrameworkCore;

namespace Database
{
    class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<TodoTask> TodoTasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TodoTask>().HasKey(t => t.Id);
        }
    }
}