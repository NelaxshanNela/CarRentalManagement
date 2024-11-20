using CarRendalAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace CarRendalAPI.DTOs.RequestDTOs
{
    public class UserReqDTO
    {
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
        public string Password { get; set; }
        [Required]
        public string Phone { get; set; } // Phone number of the user
        [Required]
        public Role UserRole { get; set; } // Enum: Admin, Customer
        //public ICollection<Image> Images { get; set; }
        public Address Address { get; set; } // Navigation property to Address
    }
}
