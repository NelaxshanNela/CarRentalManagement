using System.ComponentModel.DataAnnotations;

namespace CarRendalAPI.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; } // Unique identifier for the user
        [Required]
        public string Name { get; set; } // Full name of the user
        [Required]
        public string Email { get; set; } // Email address of the user
        [Required]
        public string Phone { get; set; } // Phone number of the user
        [Required]
        public string UserType { get; set; } // Type of user (e.g., Customer, Admin)
        public int AddressId { get; set; } // Foreign key for Address
        public Address Address { get; set; } // Navigation property to Address

    }
}
