using BonusSystem.Core.Attributes;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace BonusSystem.API.PipelineElements
{
    internal class DbTransactionMiddleware
    {
        private readonly RequestDelegate next;

        public DbTransactionMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext httpContext,DbContext dbContext)
        {
            if(httpContext.Request.Method.Equals("GET",StringComparison.CurrentCultureIgnoreCase))
            {
                await next(httpContext);
                return;
            }
            var endpoint = httpContext.Features.Get<IEndpointFeature>()?.Endpoint;
            var attribute= endpoint?.Metadata.GetMetadata<TransactionAttribute>();
            if (attribute is null)
            {
                await next(httpContext);
                return;
            }
            IDbContextTransaction transaction = null;
            try
            {
                transaction = await dbContext.Database.BeginTransactionAsync();
                await next(httpContext);
                await transaction.CommitAsync();
            }
            catch
            {
                if(transaction is not null)
                    await transaction.RollbackAsync();
                throw;
            }
            finally
            {
                transaction?.Dispose();
            }

        }
    }
    internal static class DbTransactionMiddlewareExtension
    {
        internal static IApplicationBuilder UseDbTransaction(this IApplicationBuilder app)
        {
            app.UseMiddleware<DbTransactionMiddleware>();
            return app;
        }
    }
}
