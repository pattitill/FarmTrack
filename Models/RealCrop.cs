using System.ComponentModel.DataAnnotations;

namespace FarmTrack.Models
{
    public class RealCrop : Crop
    {
        // The date the crop was planted
        public DateTime Planting { get; set; }

        // The expected harvest date
        public DateTime ExpectedHarvestDate { get; set; }

        // The actual date the crop was harvested
        public DateTime? ActualHarvestDate { get; set; } // Nullable to handle cases where it hasn't been harvested yet

        // The amount of crop harvested
        public double Amount { get; set; }

        // Parameterless constructor
        public RealCrop() { }

        // Constructor that includes the base crop attributes and new ones
        public RealCrop(string name, string description, double temperatureThreshold, int month, int duration,
                        DateTime planting, double amount) : base(name, description, temperatureThreshold, month, duration)
        {
            Planting = planting;
            ExpectedHarvestDate = Planting.AddDays(duration); // Automatically set based on duration
            Amount = amount;
        }

        // Method to update the actual harvest date
        public void SetActualHarvestDate(DateTime harvestDate)
        {
            ActualHarvestDate = harvestDate;
        }

        // Override method to display more detailed crop info
        public override void DisplayInfo()
        {
            base.DisplayInfo(); // Call the base class method
            Console.WriteLine($"Planting Date: {Planting.ToShortDateString()}, Expected Harvest: {ExpectedHarvestDate.ToShortDateString()}, Actual Harvest: {(ActualHarvestDate.HasValue ? ActualHarvestDate.Value.ToShortDateString() : "Not harvested yet")}, Amount: {Amount} units");
        }
    }
}
