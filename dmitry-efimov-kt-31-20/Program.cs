using dmitry_efimov_kt_31_20.Database;
using dmitry_efimov_kt_31_20.Interfaces.StudentsInterfaces;
using dmitry_efimov_kt_31_20.Middlewares;
using dmitry_efimov_kt_31_20.ServiceExtensions;
using Microsoft.EntityFrameworkCore;
using NLog;
using NLog.Web;

var builder = WebApplication.CreateBuilder(args);

var logger = LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();



try
{
    // Add services to the container.
    builder.Services.Configure<StudentDbContext>(
        builder.Configuration.GetSection(nameof(StudentDbContext)));
    builder.Services.AddDbContext<StudentDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

    builder.Services.AddScoped<IStudentService, StudentService>();
    builder.Services.AddServices();
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
