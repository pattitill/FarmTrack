using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FarmTrack.Data;
using FarmTrack.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace FarmTrack.Services
{
    public class ReminderNotificationService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<ReminderNotificationService> _logger;

        public ReminderNotificationService(IServiceProvider serviceProvider, ILogger<ReminderNotificationService> logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    var context = scope.ServiceProvider.GetRequiredService<FarmTrackContext>();

                    try
                    {
                        var dueReminders = context.Reminders
                            .Where(r => r.ReminderTime <= DateTime.Now && r.NotificationSent == null)
                            .ToList();

                        foreach (var reminder in dueReminders)
                        {
                            var emailAddresses = context.EmailLists.Select(e => e.EmailAddress).ToList();
                            foreach (var email in emailAddresses)
                            {
                                try
                                {
                                    await EmailService.SendEmailAsync(
                                        email,
                                        $"Reminder: {reminder.ReminderType}",
                                        $"It's time for {reminder.ReminderType} of {reminder.CropName}."
                                    );
                                    _logger.LogInformation($"Email sent to {email} for reminder {reminder.ReminderType}");
                                }
                                catch (Exception ex)
                                {
                                    _logger.LogError(ex, $"Failed to send email to {email}");
                                }
                            }

                            // Update notification sent time
                            reminder.NotificationSent = DateTime.Now;
                            context.Reminders.Update(reminder);
                        }

                        await context.SaveChangesAsync();
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "An error occurred while sending reminders");
                    }
                }

                // Delay 1 minute before the next check
                await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
            }
        }
    }
}
