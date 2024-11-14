namespace CarRendalAPI.DTOs.RequestDTOs
{
    public class ModelReqDTO
    {
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
        public string Category { get; set; }
        public int BrandId { get; set; }
    }
}
