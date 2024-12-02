using CarRendalAPI.Models;
using Microsoft.VisualBasic.FileIO;

namespace CarRendalAPI.DTOs.RequestDTOs
{
    public class ModelReqDTO
    {
        public string Name { get; set; } // Name of the model (e.g., Corolla, Mustang)
        public int Year { get; set; } // Model year
        public string EngineType { get; set; }
        public string FuelType { get; set; }
        public string TransmissionType { get; set; }
        public int Horsepower { get; set; }
        public int Doors { get; set; }
        public int Seats { get; set; }
        public double FuelEfficiency { get; set; }
        public string Category { get; set; }
        public int BrandId { get; set; }
    }
}
