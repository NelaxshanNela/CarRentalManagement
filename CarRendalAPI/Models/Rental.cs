using System.ComponentModel.DataAnnotations;

namespace CarRendalAPI.Models
{
    public class Rental
    {
        [Key]
        public int RentalId { get; set; } // Unique identifier for the rental
        public int CarId { get; set; } // Foreign key for Car
        public Car Car { get; set; } // Navigation property to Car
        public int UserId { get; set; } // Foreign key for User
        public User User { get; set; } // Navigation property to User
        public DateTime RentalStartDate { get; set; } // Start date of the rental
        public DateTime RentalEndDate { get; set; } // End date of the rental
        public decimal TotalAmount { get; set; } // Total amount for the rental
        public Status Status { get; set; } // Status (e.g., Pending, Completed, Cancelled)
        public int PickupAddressId { get; set; } // Foreign key for the pickup address
        public Address PickupAddress { get; set; } // Navigation property to Address
        public int DropoffAddressId { get; set; } // Foreign key for the dropoff address
        public Address DropoffAddress { get; set; } // Navigation property to Address

    }
}
