using CleanArchitecture.MVC.Contract;
using CleanArchitecture.MVC.Services;
using CleanArchitecture.MVC.Services.Base;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
var apiBaseAddress = builder.Configuration.GetSection("ApiAddress").Value;
builder.Services.AddHttpClient<IClient,Client>(c =>
{
    c.BaseAddress = new Uri(apiBaseAddress);
});
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddSingleton<ILocalStorageServiceContract, LocalStorageServiceRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
