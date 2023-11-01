using CleanArchitecture.Identity.Models;

using CleanArichitecture.Application.Models.Idnetity;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

using System.Text;

namespace CleanArchitecture.Identity
{
    public static class IDentityRegistrationServices
    {
        public static IServiceCollection ConfigurationIdentityService(this IServiceCollection services , IConfiguration configuration)
        {
            services.Configure<JwtSetting>(configuration.GetSection("jwtSettings"));
            services.AddDbContext<CleanArchitectureIdentityDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString(""),
                    b => b.MigrationsAssembly(typeof(CleanArchitectureIdentityDbContext).Assembly.FullName));
            });

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<CleanArchitectureIdentityDbContext>().AddDefaultTokenProviders();

            services.AddTransient<IAuthenticationService, AuthenticationService>();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
            {
                o.TokenValidationParameters = new
               TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ClockSkew = System.TimeSpan.Zero,
                    ValidIssuer = configuration["jwtSettings:issure"],
                    ValidAudience = configuration["jwtSettings:audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["jwtSettings:key"]))
                };
            });

            return services;
        }
    }
}
