using System.ComponentModel.DataAnnotations;

namespace FarmTrack.Models;

public class Crop
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    public string Type { get; set; }

    public double TemperatureThreshold { get; set; }

    public int Month { get; set; }

    public int Duration { get; set; }

    // Parameterless constructor for framework/model binding
    public Crop() { }

    // Constructor to initialize fields
    public Crop(string name, string type, double temperatureThreshold, int month, int duration)
    {
        Name = name;
        Type = type;
        TemperatureThreshold = temperatureThreshold;
        Month = month;
        Duration = duration;
    }
}




