using CarRendalAPI.Database;
using CarRendalAPI.IRepositories;
using CarRendalAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRendalAPI.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly ApplicationDbContext _context;

        public ReservationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // Post a reservation
        public async Task<Reservation> CreateReservation(Reservation reservation)
        {
            await _context.AddAsync(reservation);
            await _context.SaveChangesAsync();
            return reservation;
        }

        // Get a reservation by ID
        public async Task<Reservation> GetReservationById(int id)
        {
            return await _context.Reservations.Include(r => r.Car).Include(r => r.User)
                                              .FirstOrDefaultAsync(r => r.ReservationId == id);
        }

        // Get all reservation
        public async Task<IEnumerable<Reservation>> GetAllReservation()
        {
            return await _context.Reservations.ToListAsync();
        }

        // Update a reservation by ID
        public async Task<Reservation> UpdateReservation(Reservation reservation)
        {
            _context.Reservations.Update(reservation);
            await _context.SaveChangesAsync();
            return reservation;
        }

        // Delete a reservation by ID
        public async Task DeleteReservation(int id)
        {
            var reserve = await _context.Reservations.FindAsync(id);
            if (reserve == null)
            {
                throw new KeyNotFoundException($"Reservation with ID {id} not found");
            }

            _context.Reservations.Remove(reserve);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateReservationStatus(Reservation reservation)
        {
            _context.Reservations.Update(reservation);  // Updates the reservation entity
            await _context.SaveChangesAsync();     // Save changes to the database
        }


    }
}
