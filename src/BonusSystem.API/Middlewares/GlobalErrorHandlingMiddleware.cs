using BonusSystem.Core.Exceptions;
using System.Net;
using System.Text.Json;

namespace BonusSystem.API.Middlewares
{
    public class GlobalErrorHandlingMiddleware
    {
        private readonly RequestDelegate next;

        public GlobalErrorHandlingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {

            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                string jsonRaw = "";
                HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
                switch (ex)
                {
                    case NotFoundException:
                        jsonRaw = JsonSerializer.Serialize(new { error = true, message=ex.Message });
                        statusCode = HttpStatusCode.NotFound;
                        break;
                    case UnhandledException:
                        jsonRaw = JsonSerializer.Serialize(new { error = true, message = ex.Message });
                        statusCode = HttpStatusCode.InternalServerError;
                        break;
                    case BadRequestException:
                        jsonRaw = JsonSerializer.Serialize(new { error = true, message = ex.Message });
                        statusCode = HttpStatusCode.BadRequest;
                        break;
                    default:
                        jsonRaw = JsonSerializer.Serialize(new { error= true,message= "An error occurred. Please try again later." });
                        statusCode = HttpStatusCode.InternalServerError;
                        break;
                }

                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)statusCode;
                await context.Response.WriteAsync(jsonRaw);
            }
        }
    }

    internal static class GlobalErrorHandlingMiddlewareExtension
    {
        internal static IApplicationBuilder AddGlobalErrorHandling(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<GlobalErrorHandlingMiddleware>();
            return builder;
        }
    }
}
