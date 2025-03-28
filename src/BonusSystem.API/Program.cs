using BonusSystem.API.PipelineElements;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;
using BonusSystem.Application;
using FluentValidation;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddNewtonsoftJson(cfg =>
{
    cfg.SerializerSettings.DateFormatString = "yyyy-MM-dd";
    cfg.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
    cfg.SerializerSettings.ContractResolver = new DefaultContractResolver()
    {
        NamingStrategy = new CamelCaseNamingStrategy()
    };
});

builder.Services.AddSwaggerGen(cfg =>
{
    cfg.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "BonusSystem API",
        Description = "Store Bonus System",
        TermsOfService = new Uri("https://github.com/HeyderliAqsin"),
        Contact = new OpenApiContact
        {
            Name = "Aqsin Heyderli",
            Email = "heyderliaqsin94@gmail.com"
        },
        License = new OpenApiLicense
        {
            Name = "Document",
            Url = new Uri("https://github.com/HeyderliAqsin/readme.md")
        }
    });
    cfg.EnableAnnotations();
});

builder.Services.AddBusinessLogic(builder.Configuration);
builder.Services.AddValidatorInterceptor();

var app = builder.Build();

if (!builder.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI(cfg =>
    {
        cfg.SwaggerEndpoint("/swagger/v1/swagger.json", "BonusSystem API V1");
        cfg.RoutePrefix = string.Empty;
    });
}

app.MapControllers();

app.UseGlobalErrorHandling();
app.UseDbTransaction();
app.UseBusinessLogic();

app.Run();
