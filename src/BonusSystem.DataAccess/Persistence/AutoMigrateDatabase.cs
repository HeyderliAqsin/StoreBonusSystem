using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BonusSystem.DataAccess.Persistence
{
    internal static class AutoMigrateDatabase
    {
        internal static IApplicationBuilder UseAutoMigrateDatabase(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<DbContext>();
            context.Database.Migrate();
            return app;
        }   
    }
}
