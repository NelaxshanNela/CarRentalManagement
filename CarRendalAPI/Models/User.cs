﻿using System.ComponentModel.DataAnnotations;

namespace CarRendalAPI.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; } // Unique identifier for the user
        [Required]
        public string NIC { get; set; }
        [Required]
        public string DrivingLicenceNo { get; set; }
        [Required]
        public string FirstName { get; set; } // First name of the user
        public string LastName { get; set; } // Last name of the user
        [Required]
        public string Email { get; set; } // Email address of the user
        [Required]
        public string PasswordHash { get; set; }
        [Required]
        public string Phone { get; set; } // Phone number of the user
        [Required]
        public Role UserRole { get; set; } // Enum: Admin, Customer
        public DateTime CreatedAt { get; set; }

        // Navigation properties:
        public ICollection<Rental> Rentals { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
        public ICollection<Notification> Notifications { get; set; }
        // Navigation property: Images associated with the user
        public ICollection<Image> Images { get; set; }
        public int AddressId { get; set; } // Foreign key for Address
        public Address Address { get; set; } // Navigation property to Address
    }
}
