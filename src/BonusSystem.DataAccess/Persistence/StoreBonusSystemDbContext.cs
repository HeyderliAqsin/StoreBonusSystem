using Microsoft.EntityFrameworkCore;

namespace BonusSystem.DataAccess.Persistence
{
    public class StoreBonusSystemDbContext() : DbContext()
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(StoreBonusSystemDbContext).Assembly);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Server=.\;Database=BonusSystem;Trusted_Connection=true; encrypt=false;MultipleActiveResultSets=true");

        }
    }
}
