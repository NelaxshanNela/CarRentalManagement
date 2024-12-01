using CarRendalAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace CarRendalAPI.DTOs.ResponceDTOs
{
    public class UserResDTO
    {
        public int UserId { get; set; }
        public string NIC { get; set; }
        public string DrivingLicenceNo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string ProfileImage { get; set; }
        public string DrivingLicenseFront { get; set; }
        public string DrivingLicenseBack { get; set; }
        public string UserRole { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        public ICollection<Rental>? Rentals { get; set; }
        public ICollection<Reservation>? Reservations { get; set; }
        public ICollection<Notification>? Notifications { get; set; }
        //public ICollection<UserImages>? Images { get; set; }

        public Address Address { get; set; }
    }
}
