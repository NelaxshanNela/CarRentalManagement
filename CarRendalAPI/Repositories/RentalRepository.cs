//using CarRendalAPI.Database;
//using CarRendalAPI.IRepositories;
//using CarRendalAPI.Models;

//namespace CarRendalAPI.Repositories
//{
//    public class RentalRepository : IRentalRepository
//    {
//        private readonly ApplicationDbContext _context;

//        public RentalRepository(ApplicationDbContext context)
//        {
//            _context = context;
//        }

//        public async Task<Rental> GetRentalByIdAsync(int id)
//        {
//            return await _context.Rental
//                .Include(r => r.Car) // Include related Car entity
//                .Include(r => r.User) // Include related User entity
//                .FirstOrDefaultAsync(r => r.RentalId == id);
//        }

//        public async Task<IEnumerable<Rental>> GetAllRentalsAsync()
//        {
//            return await _context.Rentals
//                .Include(r => r.Car)
//                .Include(r => r.User)
//                .ToListAsync();
//        }

//        public async Task<IEnumerable<Rental>> GetRentalsByUserIdAsync(int userId)
//        {
//            return await _context.Rentals
//                .Where(r => r.UserId == userId)
//                .Include(r => r.Car)
//                .ToListAsync();
//        }

//        public async Task<IEnumerable<Rental>> GetRentalsByCarIdAsync(int carId)
//        {
//            return await _context.Rentals
//                .Where(r => r.CarId == carId)
//                .Include(r => r.User)
//                .ToListAsync();
//        }

//        public async Task AddRentalAsync(Rental rental)
//        {
//            await _context.Rentals.AddAsync(rental);
//            await _context.SaveChangesAsync();
//        }

//        public async Task UpdateRentalAsync(Rental rental)
//        {
//            _context.Rentals.Update(rental);
//            await _context.SaveChangesAsync();
//        }

//        public async Task DeleteRentalAsync(int id)
//        {
//            var rental = await _context.Rentals.FindAsync(id);
//            if (rental != null)
//            {
//                _context.Rentals.Remove(rental);
//                await _context.SaveChangesAsync();
//            }
//        }

//        public async Task<int> GetTotalRentalsForCarAsync(int carId)
//        {
//            return await _context.Rentals
//                .Where(r => r.CarId == carId)
//                .CountAsync();
//        }
//    }

//}
