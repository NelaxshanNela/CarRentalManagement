using CarRendalAPI.Models;

namespace CarRendalAPI.DTOs.ResponceDTOs
{
    public class CarResDTO
    {
        public int CarId { get; set; } // Unique identifier for the car
        public string LicensePlate { get; set; } // License plate number
        public string Color { get; set; } // Car color
        public CarStatus Status { get; set; } // Enum: Available, Reserved, Rented, etc.
        public decimal PricePerDay { get; set; } // Rental price per day
        public double CurrentMileage { get; set; }
        public string RegistrationNumber { get; set; }
        public int YearOfManufacture { get; set; }
        public int ViewCount { get; set; }
        public Model Model { get; set; }
        public ICollection<CarImages>? CarImages { get; set; } // One-to-many relationship with CarImage
    }
}
