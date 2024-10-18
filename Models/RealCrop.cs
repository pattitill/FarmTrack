using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FarmTrack.Models
{
    public class RealCrop
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int CropId { get; set; }

        [ForeignKey("CropId")]
        public Crop Crop { get; set; }

        [Required]
        public DateTime Planting { get; set; }

        public DateTime ExpectedHarvestDate { get; set; }

        public DateTime? ActualHarvestDate { get; set; } // Nullable, because the crop may not have been harvested yet

        public double? Amount { get; set; } // Nullable, because the crop may not be harvested yet

        // Parameterless constructor for framework/model binding
        public RealCrop() { }

        // Constructor to initialize and calculate ExpectedHarvestDate
        public RealCrop(int cropId, DateTime planting, int duration)
        {
            CropId = cropId;
            Planting = planting;
            ExpectedHarvestDate = planting.AddDays(duration); // Calculate based on planting date and crop's duration
        }
    }

}
