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
        public string TankCapacity { get; set; }
        public string FrotView { get; set; }
        public string BackView { get; set; }
        public string SideView { get; set; }
        public string Interior { get; set; }
        public Model Model { get; set; }
    }
}
