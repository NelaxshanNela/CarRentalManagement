using CarRendalAPI.DTOs.RequestDTOs;
using CarRendalAPI.DTOs.ResponceDTOs;
using CarRendalAPI.IServices;
using CarRendalAPI.Models;
using CarRendalAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace CarRendalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var users = await _userService.GetAllUsers();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            try
            {
                var user = await _userService.GetUserById(id);

                if (user == null)
                {
                    return NotFound();
                }
                return Ok(user);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/Users
        [HttpPost("Register")]
        public async Task<IActionResult> RegisterUser(UserReqDTO userReqDTO)
        {
            try
            {
                var result = await _userService.RegisterUser(userReqDTO);
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, UserUpdateDTO userUpdateDTO)
        {
            try
            {
                var updatedUser = await _userService.UpdateUser(id, userUpdateDTO);
                return Ok(updatedUser);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("change-password{id}")]
        public async Task<IActionResult> ChangePassword(int id, PasswordChangeDTO passwordChangeDTO)
        {
            try
            {
                var updatedUser = await _userService.ChangePassword(id, passwordChangeDTO);
                return Ok("Password changed successfully");
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        // DELETE: api/Users/5
        [HttpDelete("User/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                await _userService.DeleteUser(id);
                return Ok("User Deleted Successfully.");
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("Image/{id}")]
        public async Task<IActionResult> DeleteImage(int id)
        {
            try
            {
                await _userService.DeleteImage(id);
                return Ok("Image Deleted Successfully.");
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/Users/authenticate
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate(string email, string password)
        {
            var user = await _userService.AuthenticateUser(email, password);

            if (user == null)
            {
                return Unauthorized("Invalid credentials");
            }

            return Ok(user);
        }

        //[HttpPost("request-password-reset")]
        //public async Task<IActionResult> RequestPasswordReset(string email)
        //{
        //    // Step 1: Check if the user exists
        //    var user = await _userRepository.GetUserByEmailAsync(email);
        //    if (user == null)
        //    {
        //        return BadRequest("User not found.");  // Return a generic error message for security
        //    }

        //    // Step 2: Generate a password reset token
        //    var token = Guid.NewGuid().ToString();  // Create a unique token
        //    var expiration = DateTime.UtcNow.AddHours(1);  // Token expiration time (1 hour)

        //    // Step 3: Store the reset token and expiration time
        //    var passwordResetToken = new PasswordResetToken
        //    {
        //        Email = email,
        //        Token = token,
        //        Expiration = expiration
        //    };

        //    await _tokenRepository.SaveResetTokenAsync(passwordResetToken);  // Save token in database

        //    // Step 4: Send the reset link to the user's email
        //    var resetLink = $"https://yourapp.com/reset-password?token={token}";
        //    await _emailService.SendEmailAsync(email, "Password Reset", $"Click the link to reset your password: {resetLink}");

        //    return Ok("Password reset link has been sent to your email.");
        //}

        //[HttpPost("reset-password")]
        //public async Task<IActionResult> ResetPassword(string token, string newPassword)
        //{
        //    // Step 1: Validate the token
        //    var passwordResetToken = await _tokenRepository.GetResetTokenAsync(token);
        //    if (passwordResetToken == null)
        //    {
        //        return BadRequest("Invalid or expired token.");
        //    }

        //    if (passwordResetToken.Expiration < DateTime.UtcNow)
        //    {
        //        return BadRequest("Token has expired.");
        //    }

        //    // Step 2: Hash the new password
        //    var hashedPassword = BCrypt.Net.BCrypt.HashPassword(newPassword);  // Using BCrypt to hash the password

        //    // Step 3: Find the user by email and update the password
        //    var user = await _userRepository.GetUserByEmailAsync(passwordResetToken.Email);
        //    if (user == null)
        //    {
        //        return BadRequest("User not found.");
        //    }

        //    user.PasswordHash = hashedPassword;
        //    await _userRepository.UpdateUserAsync(user);  // Update user password in database

        //    // Step 4: Optionally, delete the token after the password has been reset
        //    await _tokenRepository.DeleteResetTokenAsync(passwordResetToken.Id);  // Clean up the token after use

        //    return Ok("Password has been reset successfully.");
        //}

    }

}
