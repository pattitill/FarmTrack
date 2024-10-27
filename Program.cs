using FarmTrack.Data;            // Namespace for DbContext
using FarmTrack.Services;        // Namespace for WeatherService and ReminderNotificationService
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add DbContext and configure SQLite database connection
builder.Services.AddDbContext<FarmTrackContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register WeatherService with HttpClient for external API calls
builder.Services.AddHttpClient<WeatherService>();

// Register ReminderNotificationService as a background (hosted) service
builder.Services.AddHostedService<ReminderNotificationService>();

// Add controllers with views
builder.Services.AddControllersWithViews();

// Add session support with a 1-minute timeout
builder.Services.AddHttpContextAccessor(); // To access session in controllers
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(1); // Set session timeout to 1 minute
    options.Cookie.HttpOnly = true; // Enhance security
    options.Cookie.IsEssential = true; // Ensure session works even if tracking is disabled
});

var app = builder.Build();

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts(); // The default HSTS value is 30 days.
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Uncomment if using authentication/authorization in the future
// app.UseAuthentication();
app.UseAuthorization();

// Use session middleware
app.UseSession(); // Enables session management

// Configure MVC route
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();