using BonusSystem.Core.Exceptions;
using BonusSystem.Models.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Net;

namespace BonusSystem.API.PipelineElements
{
    public class GlobalErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public GlobalErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {

            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                var response = ex switch
                {
                    NotFoundException => ApiResponse.Fail(ex.Message, HttpStatusCode.NotFound),
                    UnhandledException => ApiResponse.Fail(ex.Message, HttpStatusCode.InternalServerError),
                    BadRequestException badRequestException => ApiResponse.Fail(badRequestException.Errors,ex.Message, HttpStatusCode.BadRequest),
                    _ => ApiResponse.Fail("An error occurred. Please try again later.", HttpStatusCode.InternalServerError),
                };
                context.Response.ContentType = "application/json";
                context.Response.StatusCode =(int)response.StatusCode;
                await context.Response.WriteAsync(JsonConvert.SerializeObject(response,new JsonSerializerSettings
                {
                    ContractResolver= new DefaultContractResolver
                    {
                        NamingStrategy = new CamelCaseNamingStrategy()
                    },
                    NullValueHandling = NullValueHandling.Ignore
                }));

            }
        }
    }

    internal static class GlobalErrorHandlingMiddlewareExtension
    {
        internal static IApplicationBuilder UseGlobalErrorHandling(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<GlobalErrorHandlingMiddleware>();
            return builder;
        }
    }
}
