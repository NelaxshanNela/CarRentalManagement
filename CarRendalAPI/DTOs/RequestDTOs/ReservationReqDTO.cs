using CarRendalAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace CarRendalAPI.DTOs.RequestDTOs
{
    public class ReservationReqDTO
    {
            // The Date when the reservation is made.
            [Required]
            public DateTime ReservationDate { get; set; }

            // The End date of the reservation.
            public DateTime EndDate { get; set; }

            // Status of the reservation (e.g., Pending, Confirmed).
            public string Status { get; set; }

            // ID of the car being reserved.
            [Required]
            public int CarId { get; set; }

            // ID of the user making the reservation.
            [Required]
            public int UserId { get; set; }

    }
}
