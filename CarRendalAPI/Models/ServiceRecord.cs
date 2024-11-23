using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CarRendalAPI.Models
{
    public class ServiceRecord
    {
        [Key]
        public int ServiceRecordId { get; set; }  // Unique identifier for the service record
        public DateTime ServiceDate { get; set; }  // Date when the service was performed
        public DateTime? UpdatedAt { get; set; }

        [Required]
        public ServiceType ServiceType { get; set; }

        public string Description { get; set; }

        [Range(0.01, double.MaxValue)]
        public decimal Cost { get; set; }

        public string ServiceCenter { get; set; }

        public int CarId { get; set; }  // Foreign key to the Car that was serviced
        [JsonIgnore]
        public Car Car { get; set; }  // Navigation property to Car
    }

    // Enum to represent different service types
    public enum ServiceType
    {
        OilChange,         // Oil change service
        TireReplacement,   // Tire replacement service
        BrakeInspection,   // Brake inspection service
        EngineRepair,      // Engine repair service
        TransmissionRepair, // Transmission repair service
        Other              // Any other type of service
    }
}