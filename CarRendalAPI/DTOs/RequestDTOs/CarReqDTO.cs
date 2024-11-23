using CarRendalAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace CarRendalAPI.DTOs.RequestDTOs
{
    public class CarReqDTO
    {
        [Required]
        [StringLength(10, ErrorMessage = "License Plate must be less than 10 characters.")]
        public string LicensePlate { get; set; }

        [Required]
        [StringLength(10, ErrorMessage = "Car color must be less than 10 characters.")]
        public string Color { get; set; }

        [Required]
        public CarStatus Status { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price per day must be a positive value.")]
        public decimal PricePerDay { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Mileage must be a positive value.")]
        public double CurrentMileage { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "Registration Number must be less than 20 characters.")]
        public string RegistrationNumber { get; set; }

        [Required]
        [Range(1800, 2024, ErrorMessage = "Year of Manufacture must be a valid year.")]
        public int YearOfManufacture { get; set; }

        public int ViewCount { get; set; }

        [Required]
        public int ModelId { get; set; }

        public ICollection<CarImageReqDTO> CarImages { get; set; } = new List<CarImageReqDTO>();
    }
}
