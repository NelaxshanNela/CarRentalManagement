using CarRendalAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarRendalAPI.IRepositories
{
    public interface IRentalRepository
    {
        Task<Rental> CreateRental(Rental rental);
        Task<IEnumerable<Rental>> GetAllRentals();
        Task<Rental> GetRentalById(int id);
        Task UpdateRental(Rental rental);
        Task DeleteRental(int id);
        Task<IEnumerable<Rental>> GetRentalsByUserId(int userId);
        Task<IEnumerable<Rental>> GetRentalsByCarId(int carId);
        Task<int> GetTotalRentalsForCar(int carId);
        Task UpdateRentalStatus(Rental rental);
    }
}
