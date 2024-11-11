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
        public int ModelId { get; set; } // Foreign key for Model
        public Model Model { get; set; } // Navigation property to Model
        public bool IsAvailable { get; set; } // Availability status (true or false)
        public decimal PricePerDay { get; set; } // Rental price per day
        public double CurrentMileage { get; set; }
        public string RegistrationNumber { get; set; }
        public DateTime ManufactureDate { get; set; }
        public int ViewCount { get; set; }
        public ICollection<CarImage> CarImages { get; set; } // One-to-many relationship with CarImage
        public int LocationAddressId { get; set; } // Foreign key for the location address
        public Address LocationAddress { get; set; } // Navigation property to Address
        public ICollection<ServiceRecord> ServiceRecords { get; set; }  // One-to-many relationship
    }
}
