using CleanArchitecture.MVC3;
using CleanArchitecture.MVC3.Contract;
using CleanArchitecture.MVC3.Services;
using CleanArchitecture.MVC3.Services.Base;
using CleanArchitecture.MVC3.Services.Weblog;
using Microsoft.AspNetCore.Authentication.Cookies;
using MVC3.Contract;
using MVC3.Services;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpContextAccessor();
// Add services to the container.
builder.Services.AddControllersWithViews();
var apiBaseAddress = builder.Configuration.GetSection("ApiAddress").Value;
builder.Services.AddHttpClient<IClient, Client>(c =>
{
    c.BaseAddress = new Uri(apiBaseAddress);
});
builder.Services.Configure<CookiePolicyOptions>(option =>
{
    option.MinimumSameSitePolicy = SameSiteMode.None;
});
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).
    AddCookie(option =>
    {
        option.LoginPath = "/User/Login";
    });
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddSingleton<ILocalStorageServiceContract, LocalStorageServiceRepository>();
builder.Services.AddScoped<IWeblogServiceContract, WeblogServiceRespository>();
builder.Services.AddScoped<IAuthenticationsServiceContract, AuthenticationRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseCookiePolicy();
app.UseAuthentication();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
