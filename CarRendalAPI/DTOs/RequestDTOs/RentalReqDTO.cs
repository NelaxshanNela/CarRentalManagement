using CarRendalAPI.Models;

namespace CarRendalAPI.DTOs.RequestDTOs
{
    public class RentalReqDTO
    {
        public DateTime RentalStartDate { get; set; } // Start date of the rental
        public DateTime RentalEndDate { get; set; } // End date of the rental
        public decimal TotalAmount { get; set; } // Total amount for the rental
        public RentalStatus RentalStatus { get; set; } // Enum: Pending, Active, Completed, Canceled
        public int CarId { get; set; } // Foreign key for Car
        public int UserId { get; set; } // Foreign key for User

    }
}
