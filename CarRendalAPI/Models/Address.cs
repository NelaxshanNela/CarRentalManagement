using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CarRendalAPI.Models
{
    public class Address
    {
        [Key]
        public int AddressId { get; set; }
        [Required]
        [StringLength(100)]
        public string AddressLine1 { get; set; }
        [StringLength(100)]
        public string AddressLine2 { get; set; }
        [Required]
        [StringLength(20)]
        public string City { get; set; }
        [StringLength(20)]
        public string District { get; set; }
        [StringLength(20)]
        public string Country { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }

        public int UserId { get; set; }
        [JsonIgnore]
        public User User { get; set; }
    }
}
