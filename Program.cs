using BioKudi.Models;
using BioKudi.Repository;
using BioKudi.Services;
using BioKudi.Utilities;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.DotNet.Scaffolding.Shared;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.FileProviders;
using Wkhtmltopdf.NetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container. Dependency 
builder.Services.AddDbContext<BiokudiDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AZURE_SQL_CONNECTIONSTRING")));
builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();
builder.Services.AddAuthorization();
builder.Services.AddLogging();
builder.Services.AddRazorPages();

builder.Services.AddScoped<PasswordUtility>();
builder.Services.AddScoped<EmailUtility>();
builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<ActivityRepository>();
builder.Services.AddScoped<RoleRepository>();
builder.Services.AddScoped<StateRepository>();
builder.Services.AddScoped<PlaceRepository>();
builder.Services.AddScoped<PictureRepository>();
builder.Services.AddScoped<AuditRepository>();
builder.Services.AddScoped<TicketRepository>();
builder.Services.AddScoped<ReviewRepository>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<ActivityService>();
builder.Services.AddScoped<PlacesService>();
builder.Services.AddScoped<PictureService>();
builder.Services.AddScoped<MapService>();
builder.Services.AddScoped<AuditService>();
builder.Services.AddScoped<StateService>();
builder.Services.AddScoped<RoleService>();
builder.Services.AddScoped<TicketService>();
builder.Services.AddScoped<ReviewService>();

builder.Services.AddHsts(options =>
{
    options.Preload = true;
    options.IncludeSubDomains = true;
    options.MaxAge = TimeSpan.FromDays(60);
});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(option =>
    {
        option.LoginPath = "/Home/Login";
        option.AccessDeniedPath = "/Home/AccessDenied";
        option.Cookie.HttpOnly = true;
        option.Cookie.SameSite = SameSiteMode.Strict; 
        option.Cookie.IsEssential = true; 
        option.Cookie.SecurePolicy = CookieSecurePolicy.Always;
	});

var wkhtmltopdfPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Rotativa");
builder.Services.AddWkhtmltopdf(wkhtmltopdfPath);

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
else app.UseDeveloperExceptionPage();
app.UseStatusCodePagesWithReExecute("/Home/Error", "?statusCode={0}");

app.UseHttpsRedirection();

var provider = new FileExtensionContentTypeProvider();
provider.Mappings[".geojson"] = "application/geo+json";
app.UseStaticFiles(new StaticFileOptions
{
    ContentTypeProvider = provider
});

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
