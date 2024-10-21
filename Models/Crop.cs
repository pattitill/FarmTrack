using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FarmTrack.Models
{
    public class Crop
    {
        [Key]
        public int CropId { get; set; }

        [Required]
        [StringLength(100)]
        public string CropName { get; set; }  // Name of the crop (e.g., "Wheat", "Corn")

        [Required]
        [StringLength(50)]
        public string CropType { get; set; }  // Crop category (e.g., "Vegetable", "Fruit", "Grain")

        [Required]
        [DataType(DataType.Date)]
        public DateTime PlantingDate { get; set; }  // Date when the crop was planted

        [Required]
        [Range(1, 365)]
        public int GrowthDurationInDays { get; set; }  // Expected growth duration (in days)

        [DataType(DataType.Date)]
        public DateTime? ExpectedHarvestDate { get; set; }  // Automatically calculated based on PlantingDate and GrowthDurationInDays

        [NotMapped]
        public int DaysUntilHarvest => (ExpectedHarvestDate.HasValue) ? (ExpectedHarvestDate.Value - DateTime.Now).Days : 0;  // Days remaining for the harvest

        // Optional: Additional fields for tracking reminders and alerts (fertilizing, watering, pest control)
        public bool RequiresFertilizing { get; set; }  // Is fertilizing required?
        public DateTime? FertilizingReminder { get; set; }  // Reminder for fertilizing date

        public bool RequiresWatering { get; set; }  // Is watering required?
        public DateTime? WateringReminder { get; set; }  // Reminder for watering date

        public bool RequiresPestControl { get; set; }  // Is pest control required?
        public DateTime? PestControlReminder { get; set; }  // Reminder for pest control date

        // Historical data (optional)
        public List<GrowthHistory> GrowthHistories { get; set; } = new List<GrowthHistory>();

        // Methods to calculate harvest date
        public void CalculateHarvestDate()
        {
            if (PlantingDate != null && GrowthDurationInDays > 0)
            {
                ExpectedHarvestDate = PlantingDate.AddDays(GrowthDurationInDays);
            }
        }

        // Alerts and notifications based on upcoming tasks (fertilizing, watering, pest control)
        public bool IsFertilizingDue => FertilizingReminder.HasValue && FertilizingReminder.Value.Date == DateTime.Today;
        public bool IsWateringDue => WateringReminder.HasValue && WateringReminder.Value.Date == DateTime.Today;
        public bool IsPestControlDue => PestControlReminder.HasValue && PestControlReminder.Value.Date == DateTime.Today;
    }

    public class GrowthHistory
    {
        public int GrowthHistoryId { get; set; }
        public DateTime RecordDate { get; set; }  // Date of logging the record
        public string Notes { get; set; }  // Any notes regarding the crop’s progress
        public int CropId { get; set; }
        public Crop Crop { get; set; }
    }
}

