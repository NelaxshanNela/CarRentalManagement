using CarRendalAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace CarRendalAPI.DTOs.ResponceDTOs
{
    public class UserResDTO
    {
        public int UserId { get; set; }

        [Required]
        public string NIC { get; set; }

        [Required]
        public string DrivingLicenceNo { get; set; }

        [Required]
        public string FirstName { get; set; }

        public string? LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Phone]
        public string Phone { get; set; }

        public Role UserRole { get; set; }

        public ICollection<Rental>? Rentals { get; set; }
        public ICollection<Reservation>? Reservations { get; set; }
        public ICollection<Notification>? Notifications { get; set; }
        public ICollection<UserImages>? Images { get; set; }

        public Address Address { get; set; }
    }
}
