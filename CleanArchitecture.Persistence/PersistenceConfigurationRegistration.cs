using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using CleanArichitecture.Application.Persistance.ServiceContract;
using CleanArchitecture.Persistence.Repositories;

namespace CleanArchitecture.Persistence
{
    public static class PersistenceConfigurationRegistration
    {
        public static IServiceCollection PersistenceConfigurationServiceRegistration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CleanArchitecture_DBContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString(""));
            });

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IWeblogCategoryRepository, WeblogCategoryRepository>();
            services.AddScoped<IWeblogRepository, WeblogRepository>();
            return services;
        }
    }
}
