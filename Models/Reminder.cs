using System;
using System.ComponentModel.DataAnnotations;

namespace FarmTrack.Models
{
    public class Reminder
    {
        [Key]
        public int ReminderId { get; set; }

        [Required]
        [StringLength(100)]
        public string CropName { get; set; }  // Store the crop name directly as a string

        [Required]
        [StringLength(50)]
        public string ReminderType { get; set; }  // Plantation, Watering, Fertilizing, etc.

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime ReminderTime { get; set; }  // When to remind

        public DateTime? NotificationSent { get; set; }  // Record when the notification was sent
    }
}