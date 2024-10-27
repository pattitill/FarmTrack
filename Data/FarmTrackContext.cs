using Microsoft.EntityFrameworkCore;
using FarmTrack.Models;  // Ersetze YourNamespace durch den tatsächlichen Namespace deiner Modelle

namespace FarmTrack.Data
{
    public class FarmTrackContext : DbContext
    {
        public FarmTrackContext(DbContextOptions<FarmTrackContext> options) : base(options) { }

        public DbSet<Crop> Crops { get; set; }
        public DbSet<Reminder> Reminders { get; set; } 
        public DbSet<EmailList> EmailLists { get; set; } 
    }
}