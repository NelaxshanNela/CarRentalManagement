using CarRendalAPI.Database;
using CarRendalAPI.IRepositories;
using CarRendalAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRendalAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserById(int id)
        {
            return await _context.Users.Include(u => u.Address).Include(u => u.Rentals).Include(u => u.Reservations).Include(u => u.Notifications).FirstOrDefaultAsync(u => u.UserId == id);
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<User> GetUserByNIC(string nic)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.NIC == nic);
        }

        public async Task<User> GetUserByDrivingLicense(string drivingLicenseNo)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.DrivingLicenceNo == drivingLicenseNo);
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _context.Users.Include(u => u.Address).Include(u => u.Rentals).Include(u => u.Reservations).Include(u => u.Notifications).ToListAsync();
        }

        public async Task<User> AddUser(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> UpdateUser(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return user;
        }


        public async Task<bool> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<Address> AddAddress(Address address)
        {
            await _context.Addresses.AddAsync(address);
            await _context.SaveChangesAsync();
            return address;
        }

        public async Task<Address> UpdateAddress(Address address)
        {
            _context.Addresses.Update(address);
            await _context.SaveChangesAsync();
            return address;
        }

        public async Task<Address> GetAddressByUserId(int id)
        {
            return await _context.Addresses.FirstOrDefaultAsync(u => u.UserId == id);
        }
    }
}
