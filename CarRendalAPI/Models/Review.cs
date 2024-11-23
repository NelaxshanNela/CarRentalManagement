using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CarRendalAPI.Models
{
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }

        [Range(1, 5)]
        public int Rating { get; set; }

        public string Comments { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedAt { get; set; }


        public int CarId { get; set; } // Foreign key for Car
        [JsonIgnore]
        public Car Car { get; set; } // Navigation property to Car
    }
}
