using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using School.Modules.Student.BO.Contracts;
using School.Modules.Student.Infraestructure.Data;
using School.Modules.Student.Infraestructure.Repository;

namespace School.Modules.Student.Infraestructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDependencyInfraestructure (this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IUoWConfig, UnitOfWorkConfig>();

            var connectionString = configuration["ConnectionStrings:DefaultConnection"];

            services.AddDbContext<SchoolDbContext>(o =>
                o.UseSqlServer(connectionString, option =>
                    option.MigrationsAssembly(typeof(SchoolDbContext).Assembly.GetName().Name)
                )
            );

            return services;
        }
    }
}
