using System;

namespace CarRendalAPI.DTOs.RequestDTOs
{
    public class PaymentReqDTO
    {
        public decimal Amount { get; set; } // Total amount paid
        public DateTime PaymentDate { get; set; } // Date of payment
        public int PaymentMethod { get; set; } // Enum value for payment method (e.g., CreditCard, PayPal)
        public int PaymentStatus { get; set; } // Enum value for payment status (e.g., Pending, Completed)
        public int RentalId { get; set; } // Foreign key for the Rental
    }
}
