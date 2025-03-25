using BonusSystem.API.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var app = builder.Build();
app.MapControllers();

app.AddGlobalErrorHandling();
app.Run();
