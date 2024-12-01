using CarRendalAPI.Models;

namespace CarRendalAPI.DTOs.ResponceDTOs
{
    public class CarResDTO
    {
        public string Name { get; set; }
        public int CarId { get; set; }
        public string LicensePlate { get; set; }
        public string Color { get; set; }
        public string Status { get; set; }
        public decimal PricePerDay { get; set; }
        public double CurrentMileage { get; set; }
        public string RegistrationNumber { get; set; }
        public int YearOfManufacture { get; set; }
        public int ViewCount { get; set; }
        public Model Model { get; set; }
        public ICollection<CarImages>? CarImages { get; set; }
    }
}
