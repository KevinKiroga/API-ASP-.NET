using Microsoft.Extensions.DependencyInjection;
using School.Modules.Student.Logic.Interfaces;
using School.Modules.Student.Logic.Services;

namespace School.Modules.Student.Logic
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDependencyLogic (this IServiceCollection services)
        {
            services.AddScoped<IStudentService, StudentService>();

            return services;
        }
    }
}
