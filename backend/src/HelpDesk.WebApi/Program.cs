using HelpDesk.WebApi.Scope;
using HelpDesk.WebApi.Scope.Extensions;
using HelpDesk.WebApi.Scope.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCustomControllers();
builder.Services.AddCustomSwagger();
builder.Services.AddCustomAuthentication(builder.Configuration);
builder.Logging.AddCustomSerilog();

DependencyResolverService.Register(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseCustomSwagger();
}

app.UseCustomAuthentication();

app.MapControllers();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.Run();
