using FarmTrack.Data;  // Namespace für deinen DbContext
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Füge den DbContext und die Verbindung zur SQLite-Datenbank hinzu
builder.Services.AddDbContext<FarmTrackContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));  // Verwende UseSqlite statt UseSqlServer

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts(); // The default HSTS value is 30 days. You may want to change this for production scenarios.
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Authentication & Authorization Middleware (Optional falls wir Authentifizierung hinzufügen möchten)
// app.UseAuthentication();
app.UseAuthorization();

// Endpunkt für die MVC-Routen
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
