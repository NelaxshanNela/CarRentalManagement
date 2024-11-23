using CarRendalAPI.DTOs.RequestDTOs;
using CarRendalAPI.DTOs.ResponceDTOs;
using CarRendalAPI.Models;
using Microsoft.AspNetCore.Identity;

namespace CarRendalAPI.IServices
{
    public interface IUserService
    {
        Task<UserResDTO> GetUserById(int id);
        Task<List<UserResDTO>> GetAllUsers();
        Task<string> RegisterUser(UserReqDTO userReqDTO);
        Task<string> UpdateUser(int id, UserUpdateDTO userUpdateDTO);
        Task<bool> DeleteUser(int id);
        Task<bool> DeleteImage(int id);
        Task<string> AuthenticateUser(string email, string password);
        Task<IdentityResult> ChangePassword(int userId, PasswordChangeDTO passwordChangeDTO);
    }
}
