using CarRendalAPI.Models;

namespace CarRendalAPI.DTOs.ResponceDTOs
{
    public class ModelResDTO
    {
        public int ModelId { get; set; } // Unique identifier for the model
        public string Name { get; set; } // Name of the model (e.g., Corolla, Mustang)
        public int Year { get; set; } // Model year
        public string Color { get; set; }
        public string EngineType { get; set; }
        public string FuelType { get; set; }
        public string TransmissionType { get; set; }
        public double Mileage { get; set; }
        public int Horsepower { get; set; }
        public int Doors { get; set; }
        public int Seats { get; set; }
        public bool IsElectric { get; set; }
        public double FuelEfficiency { get; set; }
        public string Category { get; set; } // e.g., SUV, Sedan, Hatchback
        public Brand Brand { get; set; } // Foreign key for Brand
        public ICollection<Car> Cars { get; set; }
    }
}
