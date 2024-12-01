using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CarRendalAPI.Models
{
    public class Model
    {
        [Key]
        public int ModelId { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public string EngineType { get; set; }
        public string FuelType { get; set; }
        public string TransmissionType { get; set; }
        public int Horsepower { get; set; }
        public int Doors { get; set; }
        public int Seats { get; set; }
        public double FuelEfficiency { get; set; }
        public string Category { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; }

        public int BrandId { get; set; }
        [JsonIgnore]
        public Brand Brand { get; set; }
        public ICollection<Car> Cars { get; set; }
    }
}

