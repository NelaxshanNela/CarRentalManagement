using CarRendalAPI.Models;

namespace CarRendalAPI.DTOs.RequestDTOs
{
    public class CarReqDTO
    {
        public string LicensePlate { get; set; } // License plate number
        public string Color { get; set; } // Car color
        public CarStatus Status { get; set; } // Enum: Available, Reserved, Rented, etc.
        public decimal PricePerDay { get; set; } // Rental price per day
        public double CurrentMileage { get; set; }
        public string RegistrationNumber { get; set; }
        public int YearOfManufacture { get; set; }
        public int ViewCount { get; set; }
        public int ModelId { get; set; } // Foreign key for Model
    }
}
