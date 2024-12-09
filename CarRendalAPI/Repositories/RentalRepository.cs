using CarRendalAPI.Database;
using CarRendalAPI.IRepositories;
using CarRendalAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarRendalAPI.Repositories
{
    public class RentalRepository : IRentalRepository
    {
        private readonly ApplicationDbContext _context;

        public RentalRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // Create a new rental
        public async Task<Rental> CreateRental(Rental rental)
        {
            await _context.Rentals.AddAsync(rental);
            await _context.SaveChangesAsync();
            return rental;
        }

        // Get all rentals
        public async Task<IEnumerable<Rental>> GetAllRentals()
        {
            return await _context.Rentals
                .Include(r => r.Car)     // Include Car navigation property
                .Include(r => r.User)    // Include User navigation property
                .Include(r => r.Payments) // Include Payments navigation property
                .ToListAsync();
        }

        // Get a rental by ID
        public async Task<Rental> GetRentalById(int id)
        {
            return await _context.Rentals
                .Include(r => r.Car)     // Include Car navigation property
                .Include(r => r.User)    // Include User navigation property
                .Include(r => r.Payments) // Include Payments navigation property
                .FirstOrDefaultAsync(r => r.RentalId == id);
        }

        // Update an existing rental
        public async Task UpdateRental(Rental rental)
        {
            _context.Rentals.Update(rental);
            await _context.SaveChangesAsync();
        }

        // Delete a rental by ID
        public async Task DeleteRental(int id)
        {
            var rental = await _context.Rentals.FindAsync(id);
            if (rental == null)
            {
                throw new KeyNotFoundException($"Rental with ID {id} not found");
            }

            _context.Rentals.Remove(rental);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Rental>> GetRentalsByUserId(int userId)
        {
            return await _context.Rentals
                .Where(r => r.UserId == userId) // Filter by UserId
                .Include(r => r.Car)            // Include Car navigation property
                .Include(r => r.User)           // Include User navigation property
                .Include(r => r.Payments)       // Include Payments navigation property
                .ToListAsync();
        }

        public async Task<IEnumerable<Rental>> GetRentalsByCarId(int carId)
        {
            return await _context.Rentals
                .Where(r => r.CarId == carId) // Filter by CarId
                .Include(r => r.Car)           // Include Car navigation property
                .Include(r => r.User)          // Include User navigation property
                .Include(r => r.Payments)      // Include Payments navigation property
                .ToListAsync();
        }

        public async Task<int> GetTotalRentalsForCar(int carId)
        {
            return await _context.Rentals
                .Where(r => r.CarId == carId)  // Filter by CarId
                .CountAsync();                 // Count the number of rentals for this car
        }

        public async Task UpdateRentalStatus(Rental rental)
        {
            _context.Rentals.Update(rental);
            await _context.SaveChangesAsync();
        }
    }
}

