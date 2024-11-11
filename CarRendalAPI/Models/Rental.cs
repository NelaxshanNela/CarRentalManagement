using System.ComponentModel.DataAnnotations;

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

        public int CarId { get; set; } // Foreign key for Car
        public Car Car { get; set; } // Navigation property to Car
        public int UserId { get; set; } // Foreign key for User
        public User User { get; set; } // Navigation property to User
        // Navigation property: A Rental can have multiple Payments.
        public ICollection<Payment> Payments { get; set; }

    }
}
