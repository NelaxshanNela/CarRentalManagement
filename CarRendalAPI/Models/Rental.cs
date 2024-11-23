using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CarRendalAPI.Models
{
    public class Rental
    {
        [Key]
        public int RentalId { get; set; } // Unique identifier for the rental
        public DateTime RentalStartDate { get; set; } // Start date of the rental
        public DateTime RentalEndDate { get; set; } // End date of the rental
        public decimal TotalAmount { get; set; } // Total amount for the rental
        public RentalStatus RentalStatus { get; set; } // Enum: Pending, Active, Completed, Canceled
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }

        public int CarId { get; set; } // Foreign key for Car
        [JsonIgnore]
        public Car Car { get; set; } // Navigation property to Car
        public int UserId { get; set; } // Foreign key for User
        [JsonIgnore]
        public User User { get; set; } // Navigation property to User
        // Navigation property: A Rental can have multiple Payments.
        public ICollection<Payment> Payments { get; set; }

    }
    public enum RentalStatus
    {
        Pending,  // Rental is pending
        Active,   // Rental is ongoing
        Completed, // Rental is completed
        Canceled,  // Rental has been canceled
        Returned,  // Rental has been returned
        Late       // Rental is late
    }
}
