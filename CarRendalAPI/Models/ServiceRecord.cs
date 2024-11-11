using System.ComponentModel.DataAnnotations;

namespace CarRendalAPI.Models
{
    public class ServiceRecord
    {
        [Key]
        public int ServiceRecordId { get; set; }  // Unique identifier for the service record
        public int CarId { get; set; }  // Foreign key to the Car that was serviced
        public Car Car { get; set; }  // Navigation property to Car
        public DateTime ServiceDate { get; set; }  // Date when the service was performed
        public string ServiceType { get; set; }  // Type of service (e.g., oil change, tire replacement)
        public string Description { get; set; }  // Detailed description of the service
        public decimal Cost { get; set; }  // The cost of the service
        public string ServiceCenter { get; set; }  // The name of the service center
    }
}
