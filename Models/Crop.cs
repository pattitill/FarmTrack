using System.ComponentModel.DataAnnotations;

namespace FarmTrack.Models;

public class Crop
{
    // Unique identifier for each crop
    [Key]
    public int Id { get; set; }

    // The name of the crop
    [Required]
    public string Name { get; set; }

    // A description of the crop
    public string Type { get; set; } // Renamed from Description to Type as per your requirement

    // The temperature threshold required for the crop to grow
    public double TemperatureThreshold { get; set; }

    // The month in which the crop is usually planted
    public int Month { get; set; }

    // The duration (in days) it takes for the crop to grow
    public int Duration { get; set; }

    // Parameterless constructor
    public Crop() { }

    // Constructor to initialize the crop
    public Crop(string name, string type, double temperatureThreshold, int month, int duration)
    {
        Name = name;
        Type = type;
        TemperatureThreshold = temperatureThreshold;
        Month = month;
        Duration = duration;
    }

    // Method to display crop details
    public virtual void DisplayInfo()
    {
        Console.WriteLine($"Crop: {Name}, Type: {Type}, Temperature Threshold: {TemperatureThreshold}°C, Month: {Month}, Duration: {Duration} days");
    }
}


