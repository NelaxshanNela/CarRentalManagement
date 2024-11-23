using System.ComponentModel.DataAnnotations;

namespace CarRendalAPI.Models
{
    public class CarView
    {
        [Key]
        public int ViewId { get; set; } // Unique identifier for the view record
        public int CarId { get; set; } // Foreign key for the car
        public DateTime ViewedAt { get; set; } // Timestamp of the view
        public int UserId { get; set; } // Foreign key for the user (if applicable)

        public Car Car { get; set; } // Navigation property to the car
        public User User { get; set; } // Navigation property to the user (optional)
    }
}
