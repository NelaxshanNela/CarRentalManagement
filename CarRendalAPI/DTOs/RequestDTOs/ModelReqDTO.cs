using CarRendalAPI.Models;
using Microsoft.VisualBasic.FileIO;

namespace CarRendalAPI.DTOs.RequestDTOs
{
    public class ModelReqDTO
    {
        public string Name { get; set; } // Name of the model (e.g., Corolla, Mustang)
        public int Year { get; set; } // Model year
        public EngineType EngineType { get; set; }
        public FuelType FuelType { get; set; }
        public TransmissionType TransmissionType { get; set; }
        public double Mileage { get; set; }
        public int Horsepower { get; set; }
        public int Doors { get; set; }
        public int Seats { get; set; }
        public double FuelEfficiency { get; set; }
        public string Category { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string? UpdatedBy { get; set; }
        public int BrandId { get; set; }
    }
}
