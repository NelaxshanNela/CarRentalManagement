using CarRendalAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace CarRendalAPI.DTOs.RequestDTOs
{
    public class UpdateReservationStatusDTO
    {
        [Required]
        public RentalStatus Status { get; set; }
    }
}
