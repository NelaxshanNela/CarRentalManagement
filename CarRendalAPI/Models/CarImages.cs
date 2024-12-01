using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CarRendalAPI.Models
{
    public class CarImages
    {
        [Key]
        public int ImageId { get; set; }
        public string ImageUrl { get; set; }
        public string ImageType { get; set; }

        public int CarId { get; set; }

        [JsonIgnore]
        public Car Car { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
    }
}