﻿using System.ComponentModel.DataAnnotations;

namespace CarRendalAPI.Models
{
    public class Address
    {
        [Key]
        public int AddressId { get; set; } // Unique identifier for the address
        public string Street { get; set; } // Street address
        public string City { get; set; } // City
        public string State { get; set; } // State or region
        public string PostalCode { get; set; } // Postal or ZIP code
        public string Country { get; set; } // Country

        // Navigation property: An Address belongs to a User.
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
