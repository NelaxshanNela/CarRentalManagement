//using CarRendalAPI.Database;
//using CarRendalAPI.IRepositories;
//using CarRendalAPI.Models;
//using Microsoft.EntityFrameworkCore;

//namespace CarRendalAPI.Repositories
//{
//    public class UserRepository : IUserRepository
//    {
//        private readonly ApplicationDbContext _context;

//        public UserRepository(ApplicationDbContext context)
//        {
//            _context = context;
//        }

//        public async Task<User> GetUserByIdAsync(int id)
//        {
//            return await _context.Users
//                .Include(u => u.Address)  // Assuming the user has an address
//                .Include(u => u.Images)  // Assuming a related ProfileImage entity
//                .FirstOrDefaultAsync(u => u.UserId == id);
//        }

//        public async Task<User> GetUserByEmailAsync(string email)
//        {
//            return await _context.Users
//                .Include(u => u.Address)
//                .FirstOrDefaultAsync(u => u.Email == email);
//        }

//        public async Task<IEnumerable<User>> GetAllUsersAsync()
//        {
//            return await _context.Users.ToListAsync();
//        }

//        public async Task AddUserAsync(User user)
//        {
//            await _context.Users.AddAsync(user);
//            await _context.SaveChangesAsync();
//        }

//        public async Task UpdateUserAsync(User user)
//        {
//            _context.Users.Update(user);
//            await _context.SaveChangesAsync();
//        }

//        public async Task DeleteUserAsync(int id)
//        {
//            var user = await _context.Users.FindAsync(id);
//            if (user != null)
//            {
//                _context.Users.Remove(user);
//                await _context.SaveChangesAsync();
//            }
//        }

//        public async Task<User> AuthenticateUserAsync(string email, string password)
//        {
//            return await _context.Users
//                .FirstOrDefaultAsync(u => u.Email == email && u.PasswordHash == password); // Assuming plaintext password (use hashing in production)
//        }

//        //public async Task<string> GetUserProfileImageUrlAsync(int userId)
//        //{
//        //    var user = await _context.Users
//        //        .Include(u => u.Images)
//        //        .FirstOrDefaultAsync(u => u.UserId == userId);

//        //    return user?.Images?.Url; // Assuming you have a ProfileImage related entity
//        //}
//    }

//}
