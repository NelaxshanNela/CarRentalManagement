using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CarRendalAPI.Models
{
    public class CarImages
    {
        [Key]
        public int ImageId { get; set; }

        [Required]
        [Url]
        public string ImageUrl { get; set; }

        [Required]
        public string ImageType { get; set; }

        // Foreign key: CarId to link image to a specific car
        public int CarId { get; set; }

        [JsonIgnore]
        public Car Car { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedAt { get; set; }
    }
    public enum CarImageType
    {
        Profile,  // User's profile image
        Exterior,  // Car exterior image
        DrivingLicenseFront,  // Front image of the driving license
        DrivingLicenseBack,  // Back image of the driving license
        FrontView,     // Front view of the car
        SideView,      // Side view of the car
        Interior,      // Interior view
        ServiceRecord, // Service record image
        Other          // Any other image type
    }
}