using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CleanArichitecture.Application
{
    public class ApplicationServiceRegistration
    {
        public void ConfigureApplicationServices(IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }
    }
}