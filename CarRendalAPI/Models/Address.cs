using System.ComponentModel.DataAnnotations;

namespace CarRendalAPI.Models
{
    public class Address
    {
        [Key]
        public int AddressId { get; set; } // Unique identifier for the address
        public string AddressLine1 { get; set; } // AddressLine1 
        public string AddressLine2 { get; set; } // AddressLine2 
        public string City { get; set; } // City
        public string District { get; set; } // District
    }
}
