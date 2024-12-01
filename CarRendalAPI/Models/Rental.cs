using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CarRendalAPI.Models
{
    public class Rental
    {
        [Key]
        public int RentalId { get; set; }
        public DateTime RentalStartDate { get; set; }
        public DateTime RentalEndDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string RentalStatus { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }

        public int CarId { get; set; }
        [JsonIgnore]
        public Car Car { get; set; }
        public int UserId { get; set; }
        [JsonIgnore]
        public User User { get; set; }
        public ICollection<Payment> Payments { get; set; }

    }
}
