using CleanArchitecture.Identity.Models;
using CleanArchitecture.Identity.Services;

using CleanArichitecture.Application.Models.Idnetity;
using CleanArichitecture.Application.Persistence.ServiceContract.Identity;

using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

using System;
using System.Text;

namespace CleanArchitecture.Identity
{
    public static class IDentityRegistrationServices
    {
        public static IServiceCollection ConfigurationIdentityService(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<JwtSetting>(configuration.GetSection("jwtSettings"));
            services.AddDbContext<CleanArchitectureIdentityDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("CleanArchitectureIdentityConnectionString"),
                    b => b.MigrationsAssembly(typeof(CleanArchitectureIdentityDbContext).Assembly.FullName));
            });

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<CleanArchitectureIdentityDbContext>().AddDefaultTokenProviders();

            services.AddTransient<IAuthenticationsService, AuthenticationsService>();

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
            }).AddCookie(options =>
                {
                    options.LoginPath = "/User/Login";
                    options.LogoutPath = "/User/LogOut";
                    options.ExpireTimeSpan = TimeSpan.FromMinutes(5);
                }).AddGoogle(options =>
               {
                   options.ClientId = "827321804290-h782qne630emp0hresbjec29s6j1vjg2.apps.googleusercontent.com";
                   options.ClientSecret = "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";
                   options.CallbackPath = "/User/External";
               });

            return services;
        }
    }
}
//.AddJwtBearer(o =>
// {
//     o.TokenValidationParameters = new
//    TokenValidationParameters
//     {
//         ValidateIssuerSigningKey = true,
//         ValidateIssuer = true,
//         ValidateAudience = true,
//         ValidateLifetime = true,
//         ClockSkew = System.TimeSpan.Zero,
//         ValidIssuer = configuration["jwtSettings:issure"],
//         ValidAudience = configuration["jwtSettings:audience"],
//         IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["jwtSettings:key"]))
//     };
// })