using CarRendalAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace CarRendalAPI.DTOs.RequestDTOs
{
    public class UserUpdateDTO
    {
        public string NIC { get; set; }
        public string DrivingLicenceNo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        public string Phone { get; set; }
        public string DrivingLicenseFront { get; set; }
        public string DrivingLicenseBack { get; set; }
        public string UserRole { get; set; }
        //public ICollection<UserImageReqDTO> Images { get; set; }
        public AddressReqDTO Address { get; set; }
    }
}
