using System;
using System.ComponentModel.DataAnnotations;

namespace FarmTrack.Models
{
    public class OptimalPlanting
    {
        [Required]
        [Range(1, 365, ErrorMessage = "Growth duration must be between 1 and 365 days.")]
        public int GrowthDurationInDays { get; set; }

        [Required]
        [Range(-30, 50, ErrorMessage = "Preferred temperature must be between -30°C and 50°C.")]
        public double PreferredTemperature { get; set; }

        [Required(ErrorMessage = "Location is required.")]
        public string Location { get; set; }  

        public DateTime? OptimalPlantingDate { get; set; }
    }
}
