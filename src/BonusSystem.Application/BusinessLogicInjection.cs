using BonusSystem.Application.Services;
using BonusSystem.Core.Services;
using BonusSystem.DataAccess;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BonusSystem.Application
{
    public static class BusinessLogicInjection
    {
        public static IServiceCollection AddBusinessLogic(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDataAccess(configuration);

            #region Register All Services
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<ISalaryService, SalaryService>();
            #endregion
            return services;
        }
        public static IApplicationBuilder UseBusinessLogic(this IApplicationBuilder app)
        {
            app.UseDataAccess();
            return app;
        }
    }
}
