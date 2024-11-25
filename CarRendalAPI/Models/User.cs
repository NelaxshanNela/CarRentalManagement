using System.ComponentModel.DataAnnotations;

namespace CarRendalAPI.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [StringLength(12)]
        public string NIC { get; set; }

        [Required]
        [StringLength(8)]
        public string DrivingLicenceNo { get; set; }

        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }

        [StringLength(100)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        [Required]
        [Phone]
        [StringLength(10)]
        public string Phone { get; set; }

        [Required]
        public string UserRole { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }

        public ICollection<Rental>? Rentals { get; set; }
        public ICollection<Reservation>? Reservations { get; set; }
        public ICollection<Notification>? Notifications { get; set; }
        public ICollection<UserImages>? Images { get; set; }

        [Required]
        public Address Address { get; set; }
    }
    public enum Role
    {
        Admin,
        Customer
    }
}
