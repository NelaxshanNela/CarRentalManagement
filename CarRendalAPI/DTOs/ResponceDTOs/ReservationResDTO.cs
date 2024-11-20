using CarRendalAPI.Models;

namespace CarRendalAPI.DTOs.ResponceDTOs
{
    public class ReservationResDTO
    {
        // Unique identifier for the reservation
        public int ReservationId { get; set; }

        // The Date when the reservation was made
        public DateTime ReservationDate { get; set; }

        // The End date of the reservation
        public DateTime EndDate { get; set; }

        // Status of the reservation (e.g., Pending, Confirmed)
        public RentalStatus Status { get; set; }

        // The ID of the car being reserved
        public int CarId { get; set; }

        // The Car object details
        public CarResDTO Car { get; set; }

        // The ID of the user who made the reservation
        public int UserId { get; set; }

        // The User object details
        public UserResDTO User { get; set; }
    }
}
