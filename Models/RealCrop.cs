using System.ComponentModel.DataAnnotations;

namespace FarmTrack.Models
{
    public class RealCrop
    {
        [Key]
        public int RealCropId { get; set; }                //Primary Key

        [Required]
        public DateTime PlantingDate { get; set; }         // When the crop was planted
        public DateTime? ExpectedHarvestDate { get; set; } // Optional: Predicted harvest date
        public DateTime? HarvestDate { get; set; }         // Optional: Actual harvest date
        public int? QuantityHarvested { get; set; }        // Optional: Quantity harvested

        // Foreign Key for the crop model & Navigation
        [Required]
        public int CropId { get; set; }
        public Crop Crop { get; set; }
    }
}
