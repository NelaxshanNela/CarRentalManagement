using CarRendalAPI.Models;

namespace CarRendalAPI.IRepositories
{
    public interface IUserRepository
    {
        Task<User> GetUserById(int id);
        Task<User> GetUserByEmail(string email);
        Task<IEnumerable<User>> GetAllUsers();
        Task<User> AddUser(User user);
        Task<User> UpdateUser(User user);
        Task<bool> DeleteUser(int id);
        //Task<string> GetUserProfileImageUrl(int userId);
    }
}
