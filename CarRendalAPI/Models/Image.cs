using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace CarRendalAPI.Models
{
    public class Image
    {
        [Key]
        public int ImageId { get; set; }  // Unique identifier for the image
        public string ImageUrl { get; set; }  // URL or file path to the image
        public ImageType ImageType { get; set; }  // Type of image (e.g., Profile, DrivingLicenseFront, etc.)
        public EntityType EntityType { get; set; }  // Entity type (Car or User)
        public int EntityId { get; set; }  // Foreign key: CarId or UserId

        // Navigation properties: one-to-many relationships
        public Car Car { get; set; }
        public User User { get; set; }
    }
}
