using System.ComponentModel.DataAnnotations;

namespace CarRendalAPI.Models
{
    public class Payment
    {
        [Key]
        public int PaymentId { get; set; } // Unique identifier for the payment
        public decimal Amount { get; set; } // Total amount paid
        public DateTime PaymentDate { get; set; } // Date of payment
        public PaymentMethod PaymentMethod { get; set; } // Enum: CreditCard, PayPal, etc.
        public PaymentStatus PaymentStatus { get; set; } // Enum: Pending, Completed, Failed

        public int RentalId { get; set; } // Foreign key for Rental
        public Rental Rental { get; set; } // Navigation property to Rental
    }
    public enum PaymentMethod
    {
        CreditCard,
        PayPal,
        BankTransfer,  // Example: Adding another payment method
        Cash
    }

    public enum PaymentStatus
    {
        Pending,
        Completed,
        Failed,
        Refunded  // Example: Adding a "Refunded" status for completed payments
    }
}
