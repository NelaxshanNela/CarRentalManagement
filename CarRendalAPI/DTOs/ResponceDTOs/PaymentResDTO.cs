using System;

namespace CarRendalAPI.DTOs.ResponseDTOs
{
    public class PaymentResDTO
    {
        public int PaymentId { get; set; } // Unique identifier for the payment
        public decimal Amount { get; set; } // Total amount paid
        public DateTime PaymentDate { get; set; } // Date of payment
        public string PaymentMethod { get; set; } // Enum as string (e.g., CreditCard, PayPal)
        public string PaymentStatus { get; set; } // Enum as string (e.g., Pending, Completed)
        public int RentalId { get; set; } // Foreign key for the Rental
    }
}
