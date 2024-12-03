using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CarRendalAPI.Models
{
    public class Car
    {
        [Key]
        public int CarId { get; set; }
        public string LicensePlate { get; set; }
        public string Color { get; set; }
        public string Status { get; set; }
        public decimal PricePerDay { get; set; }
        public double CurrentMileage { get; set; }
        public string RegistrationNumber { get; set; }
        public int YearOfManufacture { get; set; }
        public string TankCapacity { get; set; }
        public string FrotView { get; set; }
        public string? BackView { get; set; }
        public string? SideView { get; set; }
        public string? Interior { get; set; }

        public int ViewCount { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public int ModelId { get; set; }
        [JsonIgnore]
        public Model Model { get; set; }

        public ICollection<Review>? Reviews { get; set; }
        public ICollection<Reservation>? Reservations { get; set; }
        public ICollection<Rental>? Rentals { get; set; }
        public ICollection<ServiceRecord>? ServiceRecords { get; set; }
    }
}