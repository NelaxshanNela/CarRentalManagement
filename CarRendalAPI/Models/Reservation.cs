using System.ComponentModel.DataAnnotations;

namespace CarRendalAPI.Models
{
    public class Reservation
    {
        [Key]
        public int ReservationId { get; set; } // Unique identifier for the reservation
        public int CarId { get; set; } // Foreign key for Car
        public Car Car { get; set; } // Navigation property to Car
        public int UserId { get; set; } // Foreign key for User
        public User User { get; set; } // Navigation property to User
        [Required]
        public DateTime ReservationDate { get; set; } // Date of reservation
        public DateTime EndDate { get; set; } // End date of the reservation
        public string Status { get; set; } // Reservation status (e.g., Pending, Confirmed)
    }
}
