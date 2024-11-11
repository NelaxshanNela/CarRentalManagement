using System.ComponentModel.DataAnnotations;

namespace CarRendalAPI.Models
{
    public class Payment
    {
        [Key]
        public int PaymentId { get; set; } // Unique identifier for the payment
        public int RentalId { get; set; } // Foreign key for Rental
        public Rental Rental { get; set; } // Navigation property to Rental
        public decimal Amount { get; set; } // Total amount paid
        public DateTime PaymentDate { get; set; } // Date of payment
        public string PaymentMethod { get; set; } // Payment method (e.g., Credit Card, PayPal)
        public Status Status { get; set; } // Payment status (e.g., Pending, Completed)
    }
}
