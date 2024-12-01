using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CarRendalAPI.Models
{
    public class ServiceRecord
    {
        [Key]
        public int ServiceRecordId { get; set; }
        public DateTime ServiceDate { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string ServiceType { get; set; }
        public string Description { get; set; }
        public decimal Cost { get; set; }
        public string ServiceCenter { get; set; }
        public int CarId { get; set; }
        [JsonIgnore]
        public Car Car { get; set; }
    }
}