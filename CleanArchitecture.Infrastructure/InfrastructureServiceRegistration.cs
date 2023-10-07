using CleanArchitecture.Infrastructure.Mail;
using CleanArichitecture.Application.Infrastracture;
using CleanArichitecture.Application.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection ConfigureInfrastractureServiceRegistration(this IServiceCollection services , IConfiguration configuration)
        {
            services.Configure<EmailSettingModel>(configuration.GetSection("EmailSettings"));
            services.AddTransient<IEmailSender, EmailSender>();
            return services;
        }
    }
}
