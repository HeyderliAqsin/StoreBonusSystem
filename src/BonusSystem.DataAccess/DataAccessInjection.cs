using BonusSystem.Core.Repositories.Special;
using BonusSystem.DataAccess.Persistence;
using BonusSystem.DataAccess.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BonusSystem.DataAccess
{
    public static class DataAccessInjection
    {
        public static IServiceCollection AddDataAccess(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddScoped<DbContext,StoreBonusSystemDbContext>();
            #region Register all repositories
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<IWarehouseRepository, WarehouseRepository>();
            services.AddScoped<IStoreRepository, StoreRepository>();
            services.AddScoped<IGradeRepository, GradeRepository>();
            services.AddScoped<IPositionRepository, PositionRepository>();
            services.AddScoped<ISalesRepository, SalesRepository>();
            #endregion
            return services;
        }

        public static IApplicationBuilder UseDataAccess(this IApplicationBuilder app)
        {
            app.UseAutoMigrateDatabase();
            return app;
        }
    }
}
