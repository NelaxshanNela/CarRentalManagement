using System.ComponentModel.DataAnnotations;

namespace CarRendalAPI.Models
{
    public class Review
    {
        [Key]
        public int ReviewId { get; set; } // Unique identifier for the review
        public int Rating { get; set; } // Rating (e.g., 1 to 5 stars)
        public string Comments { get; set; }
        public DateTime ReviewDate { get; set; } // Date of the review

        public int CarId { get; set; } // Foreign key for Car
        public Car Car { get; set; } // Navigation property to Car
        public int UserId { get; set; } // Foreign key for User
        public User User { get; set; } // Navigation property to User
    }
}
