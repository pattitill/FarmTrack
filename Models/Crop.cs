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

        public Boolean Harvested { get; set; }

        [DataType(DataType.Date)]
        public DateTime? HarvestDate { get; set; }

        // Methods to calculate harvest date
        public void CalculateHarvestDate()
        {
            if (PlantingDate != null && GrowthDurationInDays > 0)
            {
                ExpectedHarvestDate = PlantingDate.AddDays(GrowthDurationInDays);
            }
        }

        public void RealHarvestDate()
        {
            HarvestDate = DateTime.Now;
        }

    }
}

