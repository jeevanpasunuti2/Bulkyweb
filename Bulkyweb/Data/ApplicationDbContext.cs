using Bulkyweb.Models;
using Microsoft.EntityFrameworkCore;

namespace Bulkyweb.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Category> categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Jeevan", DisplayOrder = 1 },
                new Category { Id = 2, Name = "Shvasai", DisplayOrder = 2 },
                new Category { Id = 3, Name = "Dilip", DisplayOrder = 3 });
        }

    }
}
