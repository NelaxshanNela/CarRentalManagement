using System.ComponentModel.DataAnnotations;

namespace CarRendalAPI.DTOs.RequestDTOs
{
    public class UpdateRentalReqDTO
    {
        [Required]
        public string RentalStatus { get; set; }
    }
}
