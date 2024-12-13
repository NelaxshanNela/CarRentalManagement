using CarRendalAPI.DTOs.ResponseDTOs;
using CarRendalAPI.Models;

namespace CarRendalAPI.DTOs.ResponceDTOs
{
    public class RentalResDTO
    {
        public int RentalId { get; set; } // Unique identifier for the rental
        public DateTime RentalStartDate { get; set; } // Start date of the rental
        public DateTime RentalEndDate { get; set; } // End date of the rental
        public decimal TotalAmount { get; set; } // Total amount for the rental
        public string RentalStatus { get; set; } // Enum: Pending, Active, Completed, Canceled

        // Foreign key references
        public int CarId { get; set; } // Car identifier
        public string CarName { get; set; } // Name of the car (from Car entity)
        public int UserId { get; set; } // User identifier
        public string UserName { get; set; } // Name of the user (from User entity)
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;


        // Payments made for this rental
        public ICollection<PaymentResDTO> Payments { get; set; }
    }
}
