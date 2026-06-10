using Microsoft.EntityFrameworkCore;

namespace DB
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) 
        : DbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(
                typeof(AppDbContext).Assembly);
        }
    }
}
