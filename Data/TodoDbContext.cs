using Microsoft.EntityFrameworkCore;
using TodoAppEFCore.Model;

namespace TodoAppEFCore.Data
{
    public class TodoDbContext : DbContext
    {
        public TodoDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Todo> Todos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Todo>().HasKey(t => t.Id);
        }
    }
}
