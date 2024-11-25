using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using FarmTrack.Models;

namespace FarmTrack.Data
{
    public class FarmTrackContext : IdentityDbContext
    {
        public FarmTrackContext(DbContextOptions<FarmTrackContext> options) 
            : base(options) // Pass options to base class
        {
        }

        public DbSet<Crop> Crops { get; set; }
        public DbSet<Reminder> Reminders { get; set; }
        public DbSet<EmailList> EmailLists { get; set; }
    }
}