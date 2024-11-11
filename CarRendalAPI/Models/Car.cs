using System.ComponentModel.DataAnnotations;

namespace CarRendalAPI.Models
{
    public class Car
    {
        [Key]
        public int CarId { get; set; } // Unique identifier for the car
        [Required]
        public string LicensePlate { get; set; } // License plate number
        public string Color { get; set; } // Car color
        public CarStatus Status { get; set; } // Enum: Available, Reserved, Rented, etc.
        public decimal PricePerDay { get; set; } // Rental price per day
        public double CurrentMileage { get; set; }
        public string RegistrationNumber { get; set; }
        public int YearOfManufacture { get; set; }
        public int ViewCount { get; set; }

        public int ModelId { get; set; } // Foreign key for Model
        public Model Model { get; set; } // Navigation property to Model
        public ICollection<Review> Reviews { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
        public ICollection<Image> CarImages { get; set; } // One-to-many relationship with CarImage
        public ICollection<ServiceRecord> ServiceRecords { get; set; }  // One-to-many relationship
    }
}
