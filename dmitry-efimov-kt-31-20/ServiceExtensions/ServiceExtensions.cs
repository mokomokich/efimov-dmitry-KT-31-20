using dmitry_efimov_kt_31_20.StudentInterfaces;

namespace dmitry_efimov_kt_31_20.ServiceExtensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddService(this IServiceCollection services)
        {
            services.AddScoped<IStudentService, StudentFilterService>();
            return services;
        }
    }
}
