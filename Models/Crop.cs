using System.ComponentModel.DataAnnotations;

namespace FarmTrack.Models;

public class Crop
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public string Type { get; set; }
}