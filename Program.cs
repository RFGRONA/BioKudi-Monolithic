using BioKudi.Models;
using BioKudi.Repository;
using BioKudi.Services;
using BioKudi.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container. Dependency Injection
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<BiokudiDbContext>();
builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<PasswordUtility>();
builder.Services.AddScoped<UserService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
