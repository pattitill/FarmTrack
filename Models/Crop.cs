namespace FarmTrack.Models;

public class Crop
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime PlantingDate { get; set; }
    public DateTime HarvestDate { get; set; }
}