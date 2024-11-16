using CarRendalAPI.DTOs.RequestDTOs;
using CarRendalAPI.DTOs.ResponceDTOs;
using CarRendalAPI.Models;
using Microsoft.AspNetCore.Identity;

namespace CarRendalAPI.IServices
{
    public interface IUserService
    {
        Task<UserResDTO> GetUserById(int id);
        //Task<UserResDTO> GetUserByEmail(string email);
        Task<IEnumerable<UserResDTO>> GetAllUsers();
        Task<string> RegisterUser(UserReqDTO userReqDTO);
        Task<UserResDTO> UpdateUser(int id, UserUpdateDTO userUpdateDTO);
        Task<bool> DeleteUser(int id);
        Task<string> AuthenticateUser(string email, string password);
        Task<IdentityResult> ChangePassword(int userId, PasswordChangeDTO passwordChangeDTO);
        //Task<string> GetUserProfileImageUrl(int userId);
    }
}
