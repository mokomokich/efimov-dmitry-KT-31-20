using dmitry_efimov_kt_31_20.Data;
using dmitry_efimov_kt_31_20.Middleware;
using dmitry_efimov_kt_31_20.ServiceExtensions;
using dmitry_efimov_kt_31_20.StudentInterfaces;
using Microsoft.EntityFrameworkCore;
using NLog;
using NLog.Web;

var builder = WebApplication.CreateBuilder(args);

var logger = LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();

// Add services to the container.
builder.Services.Configure<Academic_performanceDbContext>(
    builder.Configuration.GetSection(nameof(Academic_performanceDbContext)));
builder.Services.AddDbContext<Academic_performanceDbContext>(options =>
options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IStudentService, StudentFilterService>();
builder.Services.AddService();

try
{

    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
    app.UseMiddleware<ExceptionHandlerMiddleware>();
    app.UseAuthorization();
    app.MapControllers();
    app.Run();
}

catch (Exception ex)
{
    logger.Error(ex, "Stopped program because of exception");
}
finally
{
    LogManager.Shutdown();
}
