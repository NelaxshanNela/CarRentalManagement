using CarRendalAPI.Models;

namespace CarRendalAPI.IRepositories
{
    public interface IUserRepository
    {
        Task<User> GetUserById(int id);
        Task<User> GetUserByEmail(string email);
        Task<User> GetUserByNIC(string nic);
        Task<User> GetUserByDrivingLicense(string drivingLicenseNo);
        Task<List<User>> GetAllUsers();
        Task<User> AddUser(User user);
        Task<User> UpdateUser(User user);
        Task<bool> DeleteUser(int id);
        Task<Address> AddAddress(Address address);
        Task<Address> UpdateAddress(Address address);
        Task<Address> GetAddressByUserId(int id);
    }
}
