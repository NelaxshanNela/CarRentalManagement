﻿//using CarRendalAPI.IRepositories;
//using CarRendalAPI.IServices;
//using CarRendalAPI.Models;

//namespace CarRendalAPI.Services
//{
//    public class UserService : IUserService
//    {
//        private readonly IUserRepository _userRepository;

//        public UserService(IUserRepository userRepository)
//        {
//            _userRepository = userRepository;
//        }

//        public async Task<User> GetUserByIdAsync(int id)
//        {
//            return await _userRepository.GetUserByIdAsync(id);
//        }

//        public async Task<User> GetUserByEmailAsync(string email)
//        {
//            return await _userRepository.GetUserByEmailAsync(email);
//        }

//        public async Task<IEnumerable<User>> GetAllUsersAsync()
//        {
//            return await _userRepository.GetAllUsersAsync();
//        }

//        public async Task CreateUserAsync(User user)
//        {
//            await _userRepository.AddUserAsync(user);
//        }

//        public async Task UpdateUserAsync(User user)
//        {
//            await _userRepository.UpdateUserAsync(user);
//        }

//        public async Task DeleteUserAsync(int id)
//        {
//            await _userRepository.DeleteUserAsync(id);
//        }

//        public async Task<User> AuthenticateUserAsync(string email, string password)
//        {
//            return await _userRepository.AuthenticateUserAsync(email, password);
//        }

//        //public async Task<string> GetUserProfileImageUrlAsync(int userId)
//        //{
//        //    return await _userRepository.GetUserProfileImageUrlAsync(userId);
//        //}
//    }

//}
