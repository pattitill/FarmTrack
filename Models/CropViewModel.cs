using System;

namespace FarmTrack.ViewModels
{
    public class CropViewModel
    {
        public int CropId { get; set; }
        public string CropName { get; set; }
        public string CropType { get; set; }
        public DateTime PlantingDate { get; set; }
        public int GrowthDurationInDays { get; set; }
        public DateTime? ExpectedHarvestDate { get; set; }
        public bool Harvested { get; set; }
        public int SecondsUntilHarvest { get; set; } // Countdown timer in seconds
    }
}