using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CarRendalAPI.Models
{
    public class Model
    {
        [Key]
        public int ModelId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Range(1886, 2024)]
        public int Year { get; set; }

        [StringLength(50)]
        public EngineType EngineType { get; set; }

        [StringLength(50)]
        public FuelType FuelType { get; set; }

        [StringLength(50)]
        public TransmissionType TransmissionType { get; set; }

        [Range(0, double.MaxValue)]
        public double Mileage { get; set; }

        [Range(0, int.MaxValue)]
        public int Horsepower { get; set; }

        [Range(1, 5)]
        public int Doors { get; set; }

        [Range(1, 12)]
        public int Seats { get; set; }

        [Range(0, double.MaxValue)]
        public double FuelEfficiency { get; set; }

        [StringLength(50)]
        public string Category { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; }

        // Foreign key for Brand
        public int BrandId { get; set; }
        [JsonIgnore]
        public Brand Brand { get; set; }

        public ICollection<Car> Cars { get; set; }
    }
    public enum EngineType
    {
        Petrol,
        Diesel,
        Electric,
        Hybrid
    }

    public enum FuelType
    {
        Gasoline,
        Electric,
        Hybrid,
        Diesel
    }

    public enum TransmissionType
    {
        Manual,
        Automatic
    }
}

