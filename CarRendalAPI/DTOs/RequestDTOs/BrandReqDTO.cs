using System.ComponentModel.DataAnnotations;

namespace CarRendalAPI.DTOs.RequestDTOs
{
    public class BrandReqDTO
    {
        [Required(ErrorMessage = "Brand name is required.")]
        [StringLength(20, ErrorMessage = "Brand name cannot be longer than 20 characters.")]
        public string Name { get; set; }

        [StringLength(20, ErrorMessage = "Country name cannot be longer than 20 characters.")]
        public string Country { get; set; }

        [Range(1800, 2024, ErrorMessage = "Founded year must be between 1800 and 2024.")]
        public int FoundedYear { get; set; }

        [Url(ErrorMessage = "Invalid Logo URL format.")]
        public string LogoUrl { get; set; }

        [Url(ErrorMessage = "Invalid Website URL format.")]
        public string Website { get; set; }

        [StringLength(500, ErrorMessage = "Description cannot be longer than 500 characters.")]
        public string Description { get; set; }
    }
}
