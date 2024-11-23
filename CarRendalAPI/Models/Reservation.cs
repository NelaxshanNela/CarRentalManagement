using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CarRendalAPI.Models
{
    public class Reservation
    {
        [Key]
        public int ReservationId { get; set; } // Unique identifier for the reservation
        [Required]
        public DateTime ReservationDate { get; set; } // Date of reservation
        public DateTime EndDate { get; set; } // End date of the reservation
        public RentalStatus Status { get; set; } // Reservation status (e.g., Pending, Confirmed)

        public int CarId { get; set; } // Foreign key for Car
        [JsonIgnore]
        public Car Car { get; set; } // Navigation property to Car
        public int UserId { get; set; } // Foreign key for User
        [JsonIgnore]
        public User User { get; set; } // Navigation property to User
    }
}
