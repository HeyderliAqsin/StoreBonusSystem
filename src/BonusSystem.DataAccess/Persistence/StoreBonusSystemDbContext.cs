using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BonusSystem.DataAccess.Persistence
{
    public class StoreBonusSystemDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public StoreBonusSystemDbContext(DbContextOptions<StoreBonusSystemDbContext> options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(StoreBonusSystemDbContext).Assembly);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = _configuration.GetConnectionString("BonusSystemDb");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
    }
}
