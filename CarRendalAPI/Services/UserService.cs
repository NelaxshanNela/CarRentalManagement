﻿using CarRendalAPI.DTOs.RequestDTOs;
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
        private readonly SendmailService _emailService;

        public UserService(IUserRepository userRepository, IConfiguration configuration, SendmailService emailService)
        {
            _userRepository = userRepository;
            _configuration = configuration;
            _emailService = emailService;
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
                ProfileImage = exitingUser.ProfileImage,
                DrivingLicenseFront = exitingUser.DrivingLicenseFront,
                DrivingLicenseBack = exitingUser.DrivingLicenseBack,
                CreatedAt = exitingUser.CreatedAt,
                UpdatedAt = exitingUser.UpdatedAt,
                Address = exitingUser.Address,
            };
            return user;
        }

        public async Task<List<UserResDTO>> GetAllUsers()
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
                    ProfileImage = user.ProfileImage,
                    DrivingLicenseFront = user.DrivingLicenseFront,
                    DrivingLicenseBack = user.DrivingLicenseBack,
                    CreatedAt = user.CreatedAt,
                    UpdatedAt = user.UpdatedAt,
                    Address = user.Address
                };

                userResDTOList.Add(userResDTO);
            }

            return userResDTOList;
        }

        public async Task<string> RegisterUser(UserReqDTO userReqDTO)
        {
            var existingEmail = await _userRepository.GetUserByEmail(userReqDTO.Email);
            if (existingEmail != null)
            {
                throw new ArgumentException("This email address is already registered.");
            }
            var existingNIC = await _userRepository.GetUserByNIC(userReqDTO.NIC);
            if (existingNIC != null)
            {
                throw new ArgumentException("This NIC address is already registered.");
            }
            var existingDrivingLicenceNo = await _userRepository.GetUserByDrivingLicense(userReqDTO.DrivingLicenceNo);
            if (existingDrivingLicenceNo != null)
            {
                throw new ArgumentException("This DrivingLicenceNo address is already registered.");
            }

            var user = new User
            {
                NIC = userReqDTO.NIC,
                DrivingLicenceNo = userReqDTO.DrivingLicenceNo,
                FirstName = userReqDTO.FirstName,
                LastName = userReqDTO.LastName,
                Email = userReqDTO.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(userReqDTO.Password),
                Phone = userReqDTO.Phone,
                ProfileImage = userReqDTO.ProfileImage,
                DrivingLicenseFront = userReqDTO.DrivingLicenseFront,
                DrivingLicenseBack = userReqDTO.DrivingLicenseBack,
                UserRole = userReqDTO.UserRole,
                CreatedAt = DateTime.UtcNow
            };
            var data = await _userRepository.AddUser(user);
            var emailreq = new SendMailRequest();
            emailreq.Email = userReqDTO.Email;
            emailreq.EmailType = EmailTypes.otp;
            emailreq.Otp = userReqDTO.Password;
            emailreq.Name = "Successful Registration";
            var result = await _emailService.Sendmail(emailreq);    

            var address = new Address();
            address.AddressLine1 = userReqDTO.Address.AddressLine1;
            address.AddressLine2 = userReqDTO.Address.AddressLine2;
            address.City = userReqDTO.Address.City;
            address.District = userReqDTO.Address.District;
            address.Country = userReqDTO.Address.Country;
            address.CreatedAt = DateTime.UtcNow;
            address.UserId = data.UserId;

            await _userRepository.AddAddress(address);

            var token = CreateToken(data);
            return token;
        }

        public async Task<string> UpdateUser(int id, UserUpdateDTO userUpdateDTO)
        {
            var exitingUser = await _userRepository.GetUserById(id);
            if (exitingUser == null)
            {
                throw new KeyNotFoundException("User not found.");
            }

            exitingUser.UserId = id;
            exitingUser.NIC = userUpdateDTO.NIC;
            exitingUser.DrivingLicenceNo = userUpdateDTO.DrivingLicenceNo;
            exitingUser.FirstName = userUpdateDTO.FirstName;
            exitingUser.LastName = userUpdateDTO.LastName;
            exitingUser.Email = userUpdateDTO.Email;
            exitingUser.Phone = userUpdateDTO.Phone;
            exitingUser.DrivingLicenseFront = userUpdateDTO.DrivingLicenseFront;
            exitingUser.DrivingLicenseBack = userUpdateDTO.DrivingLicenseBack;
            exitingUser.ProfileImage = userUpdateDTO.ProfileImage;
            exitingUser.UserRole = userUpdateDTO.UserRole;
            exitingUser.UpdatedAt = DateTime.UtcNow;

            var data = await _userRepository.UpdateUser(exitingUser);

            var exitingAddress = await _userRepository.GetAddressByUserId(id);
            if (exitingAddress == null)
            {
                throw new KeyNotFoundException("Address not found.");
            }

            exitingAddress.AddressLine1 = userUpdateDTO.Address.AddressLine1;
            exitingAddress.AddressLine2 = userUpdateDTO.Address.AddressLine2;
            exitingAddress.City = userUpdateDTO.Address.City;
            exitingAddress.District = userUpdateDTO.Address.District;
            exitingAddress.UpdatedAt = DateTime.UtcNow;

            await _userRepository.UpdateAddress(exitingAddress);

            return "User Updated Successfully";
        }

        public async Task<bool> DeleteUser(int id)
        {
            var success = await _userRepository.DeleteUser(id);
            if (!success) throw new KeyNotFoundException("User not found.");
            return success;
        }

        public async Task<string> AuthenticateUser(LoginReqDTO loginReqDTO)
        {
            var user = await _userRepository.GetUserByEmail(loginReqDTO.Email);
            if (user == null)
            {
                throw new KeyNotFoundException("User not found.");
            }
            if (!BCrypt.Net.BCrypt.Verify(loginReqDTO.Password, user.PasswordHash))
            {
                throw new Exception("Wrong password.");
            }
            return CreateToken(user);
        }

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

        public async Task<IdentityResult> ChangePassword(int userId, PasswordChangeDTO passwordChangeDTO)
        {
            var user = await _userRepository.GetUserById(userId);
            if (user == null)
            {
                throw new KeyNotFoundException("User not found.");
            }
            var result = BCrypt.Net.BCrypt.Verify(passwordChangeDTO.CurrentPassword, user.PasswordHash);
            if (!result)
            {
                throw new Exception("Wrong password.");
            }
            if (passwordChangeDTO.NewPassword != passwordChangeDTO.ConfirmNewPassword)
            {
                throw new Exception("Password does not match.");
            }
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(passwordChangeDTO.NewPassword);
            user.UpdatedAt = DateTime.UtcNow;

            await _userRepository.UpdateUser(user);

            return IdentityResult.Success;
        }
    }
}
