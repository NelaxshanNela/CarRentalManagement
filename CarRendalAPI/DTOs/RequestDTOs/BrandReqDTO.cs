namespace CarRendalAPI.DTOs.RequestDTOs
{
    public class BrandReqDTO
    {
        public string Name { get; set; } // Name of the brand (e.g., Toyota, Ford)
        public string Country { get; set; } // Country of origin
        public int FoundedYear { get; set; } // Year the brand was founded
        public string LogoUrl { get; set; }
        public string Website { get; set; }
        public string Description { get; set; }
    }
}
