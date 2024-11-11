using System.ComponentModel.DataAnnotations;

namespace CarRendalAPI.Models
{
    public class CarImage
    {
        [Key]
        public int CarImageId { get; set; } // Unique identifier for the image
        public int CarId { get; set; } // Foreign key for Car
        public Car Car { get; set; } // Navigation property to Car
        public string ImageUrl { get; set; } // URL or path to the image
        public string Description { get; set; } // Image description (optional)
        public bool IsPrimary { get; set; } // Whether the image is the primary one
    }
}
