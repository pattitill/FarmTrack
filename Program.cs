using FarmTrack.Data;  // Namespace for your DbContext
using FarmTrack.Services;  // Namespace for your WeatherService
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add DbContext and the connection to the SQLite database
builder.Services.AddDbContext<FarmTrackContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));  // Use SQLite instead of SQL Server

// Add WeatherService with HttpClient to enable external API calls
builder.Services.AddHttpClient<WeatherService>();
builder.Services.AddSingleton<WeatherService>();

// Add services to the container
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();  // The default HSTS value is 30 days. You may want to change this for production scenarios.
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Authentication & Authorization Middleware (optional if you plan to add authentication)
// app.UseAuthentication();
app.UseAuthorization();

// MVC route configuration
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
