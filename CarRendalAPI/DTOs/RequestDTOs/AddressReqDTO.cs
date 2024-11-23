using System.ComponentModel.DataAnnotations;

namespace CarRendalAPI.DTOs.RequestDTOs
{
    public class AddressReqDTO
    {
        [Required(ErrorMessage = "Address Line 1 is required.")]
        [StringLength(100, ErrorMessage = "Address Line 1 cannot be longer than 100 characters.")]
        public string AddressLine1 { get; set; }

        [StringLength(100, ErrorMessage = "Address Line 2 cannot be longer than 100 characters.")]
        public string AddressLine2 { get; set; }

        [Required(ErrorMessage = "City is required.")]
        [StringLength(20, ErrorMessage = "City cannot be longer than 20 characters.")]
        public string City { get; set; }

        [Required(ErrorMessage = "District is required.")]
        [StringLength(20, ErrorMessage = "District cannot be longer than 20 characters.")]
        public string District { get; set; }

        [Required(ErrorMessage = "Country is required.")]
        [StringLength(20, ErrorMessage = "Country cannot be longer than 20 characters.")]
        public string Country { get; set; }
    }
}
