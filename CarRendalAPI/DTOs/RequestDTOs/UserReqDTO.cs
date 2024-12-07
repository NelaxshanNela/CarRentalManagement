using CarRendalAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace CarRendalAPI.DTOs.RequestDTOs
{
    public class UserReqDTO
    {
        [Required]
        public string FirstName { get; set; }

        public string LastName { get; set; }

        [Required]
        public string NIC { get; set; }

        [Required]
        public string DrivingLicenceNo { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }

        [Required]
        [Phone]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Image URL is required.")]
        [Url(ErrorMessage = "Please provide a valid URL for the image.")]
        public string DrivingLicenseFront { get; set; }

        [Required(ErrorMessage = "Image URL is required.")]
        [Url(ErrorMessage = "Please provide a valid URL for the image.")]
        public string DrivingLicenseBack { get; set; }
        
        [Url(ErrorMessage = "Please provide a valid URL for the image.")]
        public string ProfileImage { get; set; }

        [Required]
        public string UserRole { get; set; }

        //public ICollection<UserImageReqDTO>? Images { get; set; }

        [Required]
        public AddressReqDTO Address { get; set; }
    }
}
