using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CarRendalAPI.Models
{
    public class Car
    {
        [Key]
        public int CarId { get; set; }

        [Required]
        [StringLength(15)]
        public string LicensePlate { get; set; }

        [StringLength(10)]
        public string Color { get; set; }

        [Required]
        public CarStatus Status { get; set; }

        [Required]
        [Range(0.01, double.MaxValue)]
        public decimal PricePerDay { get; set; }

        [Range(0, double.MaxValue)]
        public double CurrentMileage { get; set; }

        public string RegistrationNumber { get; set; }

        [Range(1900, 2024)]
        public int YearOfManufacture { get; set; }

        [Range(0, int.MaxValue)]
        public int TankCapacity { get; set; }

        public int ViewCount { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        // Foreign key to Model
        public int ModelId { get; set; }
        [JsonIgnore]
        public Model Model { get; set; }

        // Navigation properties
        public ICollection<Review>? Reviews { get; set; }
        public ICollection<Reservation>? Reservations { get; set; }
        public ICollection<Rental>? Rentals { get; set; }
        public ICollection<CarImages>? CarImages { get; set; }
        public ICollection<ServiceRecord>? ServiceRecords { get; set; }

    }
    public enum CarStatus
    {
        Available,
        Reserved,
        Rented,
        UnderMaintenance
    }
}