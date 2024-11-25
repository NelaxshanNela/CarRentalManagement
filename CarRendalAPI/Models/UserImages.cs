using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CarRendalAPI.Models
{
    public class UserImages
    {
        [Key]
        public int ImageId { get; set; }

        public string ImageUrl { get; set; }

        public string ImageType { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedAt { get; set; }

        // Foreign key for the User
        public int UserId { get; set; }

        [JsonIgnore]
        public User User { get; set; }  // Navigation property to User
    }
    // Enum to represent different image types
    public enum UserImageType
    {
        Profile,             // Profile image type
        DrivingLicenseFront, // Driving license front image
        DrivingLicenseBack,  // Driving license back image
        IDCardFront,         // ID card front image
        IDCardBack,          // ID card back image
        Other                // Any other image type
    }
}
