using CarRendalAPI.DTOs.RequestDTOs;
using CarRendalAPI.DTOs.ResponceDTOs;
using CarRendalAPI.IRepositories;
using CarRendalAPI.IServices;
using CarRendalAPI.Models;
using CarRendalAPI.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CarRendalAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;

        public UserService(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        public async Task<UserResDTO> GetUserById(int id)
        {
            var exitingUser = await _userRepository.GetUserById(id);
            if (exitingUser == null) throw new KeyNotFoundException("User not found.");

            var user = new UserResDTO
            {
                UserId = exitingUser.UserId,
                NIC = exitingUser.NIC,
                DrivingLicenceNo = exitingUser.DrivingLicenceNo,
                FirstName = exitingUser.FirstName,
                LastName = exitingUser.LastName,
                Email = exitingUser.Email,
                Phone = exitingUser.Phone,
                UserRole = exitingUser.UserRole,
                Rentals = exitingUser.Rentals,
                Reservations = exitingUser.Reservations,
                Notifications = exitingUser.Notifications,
                Images = exitingUser.Images,
                Address = exitingUser.Address,
            };
            return user;
        }

        //public async Task<UserResDTO> GetUserByEmail(string email)
        //{
        //    var exitingUser = await _userRepository.GetUserByEmail(email);
        //    if (exitingUser == null) throw new KeyNotFoundException("User not found.");

        //    var user = new UserResDTO
        //    {
        //        UserId = exitingUser.UserId,
        //        NIC = exitingUser.NIC,
        //        DrivingLicenceNo = exitingUser.DrivingLicenceNo,
        //        FirstName = exitingUser.FirstName,
        //        LastName = exitingUser.LastName,
        //        Email = exitingUser.Email,
        //        Phone = exitingUser.Phone,
        //        UserRole = exitingUser.UserRole,
        //        Rentals = exitingUser.Rentals,
        //        Reservations = exitingUser.Reservations,
        //        Notifications = exitingUser.Notifications,
        //        Images = exitingUser.Images,
        //        Address = exitingUser.Address,
        //    };
        //    return user;
        //}

        public async Task<IEnumerable<UserResDTO>> GetAllUsers()
        {
            var users = await _userRepository.GetAllUsers();
            if (users == null || !users.Any())
            {
                throw new KeyNotFoundException("Users not available.");
            }

            var userResDTOList = new List<UserResDTO>();

            foreach (var user in users)
            {
                var userResDTO = new UserResDTO
                {
                    UserId = user.UserId,
                    NIC = user.NIC,
                    DrivingLicenceNo = user.DrivingLicenceNo,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    Phone = user.Phone,
                    UserRole = user.UserRole,
                    Rentals = user.Rentals,
                    Reservations = user.Reservations,
                    Notifications = user.Notifications,
                    Images = user.Images,
                    Address = user.Address
                };

                userResDTOList.Add(userResDTO);
            }

            return userResDTOList;
        }

        public async Task<string> RegisterUser(UserReqDTO userReqDTO)
        {
            if (string.IsNullOrEmpty(userReqDTO.Email) || string.IsNullOrEmpty(userReqDTO.Password))
            {
                throw new ArgumentException("Email and Password are required.");
            }
            // Check if email already exists
            var existingUser = await _userRepository.GetUserByEmail(userReqDTO.Email);
            if (existingUser != null)
            {
                throw new ArgumentException("This email address is already registered.");
            }

            var user = new User
            {
                UserId = userReqDTO.UserId,
                NIC = userReqDTO.NIC,
                DrivingLicenceNo = userReqDTO.DrivingLicenceNo,
                FirstName = userReqDTO.FirstName,
                LastName = userReqDTO.LastName,
                Email = userReqDTO.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(userReqDTO.Password),
                Phone = userReqDTO.Phone,
                UserRole = userReqDTO.UserRole,
                //Images = userReqDTO.Images,
                Address = userReqDTO.Address,
                CreatedAt = DateTime.UtcNow
            };

            var data = await _userRepository.AddUser(user);

            var token = CreateToken(data);
            return token;
        }

        public async Task<UserResDTO> UpdateUser(int id, UserUpdateDTO userUpdateDTO)
        {
            if (id != userUpdateDTO.UserId)
            {
                throw new ArgumentException("The ID in the URL does not match the ID in the body.");
            }

            var exitingUser = await _userRepository.GetUserById(id);
            if (exitingUser == null)
            {
                throw new KeyNotFoundException("User not found.");
            }

            var user = new User
            {
                UserId = userUpdateDTO.UserId,
                NIC = userUpdateDTO.NIC,
                DrivingLicenceNo = userUpdateDTO.DrivingLicenceNo,
                FirstName = userUpdateDTO.FirstName,
                LastName = userUpdateDTO.LastName,
                Email = userUpdateDTO.Email,
                Phone = userUpdateDTO.Phone,
                UserRole = userUpdateDTO.UserRole,
                Images = userUpdateDTO.Images,
                Address = userUpdateDTO.Address
            };

            var data = await _userRepository.UpdateUser(user);

            var responce = new UserResDTO
            {
                UserId = data.UserId,
                NIC = data.NIC,
                DrivingLicenceNo = data.DrivingLicenceNo,
                FirstName = data.FirstName,
                LastName = data.LastName,
                Email = data.Email,
                Phone = data.Phone,
                UserRole = data.UserRole,
                Images = data.Images,
                Address = data.Address,
                Rentals = data.Rentals,
                Reservations = data.Reservations,
                Notifications = data.Notifications
            };

            return responce;
        }

        public async Task<bool> DeleteUser(int id)
        {
            var success = await _userRepository.DeleteUser(id);
            if (!success) throw new KeyNotFoundException("User not found.");
            return success;
        }

        public async Task<string> AuthenticateUser(string email, string password)
        {
            var user = await _userRepository.GetUserByEmail(email);
            if (user == null)
            {
                throw new Exception("User not found.");
            }
            if (!BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
            {
                throw new Exception("Wrong password.");
            }
            return CreateToken(user);
        }

        //public async Task<string> GetUserProfileImageUrl(int userId)
        //{
        //    return await _userRepository.GetUserProfileImageUrl(userId);
        //}

        private string CreateToken(User user)
        {
            var claimsList = new List<Claim>();
            claimsList.Add(new Claim("Id", user.UserId.ToString()));
            claimsList.Add(new Claim("NIC", user.NIC));
            claimsList.Add(new Claim("DrivingLicenceNo", user.DrivingLicenceNo));
            claimsList.Add(new Claim("FirstName", user.FirstName));
            claimsList.Add(new Claim("LastName", user.LastName));
            claimsList.Add(new Claim("Email", user.Email));
            claimsList.Add(new Claim("Phone", user.Phone.ToString()));
            claimsList.Add(new Claim("UserRole", user.UserRole.ToString()));


            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]));
            var credintials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Audience"],
                claims: claimsList,
                expires: DateTime.Now.AddDays(30),
                signingCredentials: credintials
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }


        // Handle password change
        public async Task<IdentityResult> ChangePassword(int userId, PasswordChangeDTO passwordChangeDTO)
        {
            // Retrieve user by Id
            var user = await _userRepository.GetUserById(userId);
            if (user == null)
            {
                return IdentityResult.Failed(new IdentityError
                {
                    Code = "UserNotFound",
                    Description = "User not found."
                });
            }

            // Verify the current password
            var result = BCrypt.Net.BCrypt.Verify(passwordChangeDTO.CurrentPassword, user.PasswordHash);
            if (!result)
            {
                throw new Exception("Wrong password.");
            }

            // Ensure the new password matches the confirmation password
            if (passwordChangeDTO.NewPassword != passwordChangeDTO.ConfirmNewPassword)
            {
                throw new Exception("Password does not match.");
            }

            // Hash the new password
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(passwordChangeDTO.NewPassword);

            // Save changes
            await _userRepository.UpdateUser(user);

            return IdentityResult.Success;
        }
    }

}
