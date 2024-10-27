using System.ComponentModel.DataAnnotations;

namespace FarmTrack.Models
{
    public class EmailList
    {
        [Key]
        public int EmailListId { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(255)]
        public string EmailAddress { get; set; }  // Correct spelling here
    }
}