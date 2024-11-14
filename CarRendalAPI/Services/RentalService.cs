//using CarRendalAPI.IRepositories;
//using CarRendalAPI.IServices;
//using CarRendalAPI.Models;

//namespace CarRendalAPI.Services
//{
//    public class RentalService : IRentalService
//    {
//        private readonly IRentalRepository _rentalRepository;

//        public RentalService(IRentalRepository rentalRepository)
//        {
//            _rentalRepository = rentalRepository;
//        }

//        public async Task<Rental> GetRentalByIdAsync(int id)
//        {
//            return await _rentalRepository.GetRentalByIdAsync(id);
//        }

//        public async Task<IEnumerable<Rental>> GetAllRentalsAsync()
//        {
//            return await _rentalRepository.GetAllRentalsAsync();
//        }

//        public async Task<IEnumerable<Rental>> GetRentalsByUserIdAsync(int userId)
//        {
//            return await _rentalRepository.GetRentalsByUserIdAsync(userId);
//        }

//        public async Task<IEnumerable<Rental>> GetRentalsByCarIdAsync(int carId)
//        {
//            return await _rentalRepository.GetRentalsByCarIdAsync(carId);
//        }

//        public async Task CreateRentalAsync(Rental rental)
//        {
//            await _rentalRepository.AddRentalAsync(rental);
//        }

//        public async Task UpdateRentalAsync(Rental rental)
//        {
//            await _rentalRepository.UpdateRentalAsync(rental);
//        }

//        public async Task DeleteRentalAsync(int id)
//        {
//            await _rentalRepository.DeleteRentalAsync(id);
//        }

//        public async Task<int> GetTotalRentalsForCarAsync(int carId)
//        {
//            return await _rentalRepository.GetTotalRentalsForCarAsync(carId);
//        }
//    }

//}
