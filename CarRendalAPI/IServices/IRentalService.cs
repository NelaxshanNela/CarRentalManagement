using CarRendalAPI.DTOs.RequestDTOs;
using CarRendalAPI.DTOs.ResponceDTOs;
using CarRendalAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarRendalAPI.IServices
{
    public interface IRentalService
    {
        Task<RentalResDTO> CreateRental(RentalReqDTO rentalReqDTO);
        Task<IEnumerable<RentalResDTO>> GetAllRentals();
        Task<RentalResDTO> GetRentalById(int id);
        Task<RentalResDTO> UpdateRental(int id, RentalReqDTO rentalReqDTO);
        Task DeleteRental(int id);
        Task<IEnumerable<Rental>> GetRentalsByUserId(int userId);
        Task<IEnumerable<Rental>> GetRentalsByCarId(int carId);
        Task<int> GetTotalRentalsForCar(int carId); // Ensure this method exists
    }
}
