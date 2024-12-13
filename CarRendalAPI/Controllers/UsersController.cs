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
                return Ok(new { success = true, message = "User added successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = "Error adding User", error = ex.Message });
            }
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, UserUpdateDTO userUpdateDTO)
        {
            try
            {
                var updatedUser = await _userService.UpdateUser(id, userUpdateDTO);
                return Ok(new { success = true, message = "User updated successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = "Error updating User", error = ex.Message });
            }
        }

        // PUT: api/Users/changePassword/5
        [HttpPut("changePassword/{id}")]
        public async Task<IActionResult> ChangePassword(int id, PasswordChangeDTO passwordChangeDTO)
        {
            try
            {
                var updatedUser = await _userService.ChangePassword(id, passwordChangeDTO);
                return Ok(new { success = true, message = "Password changed successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = "Error changing password", error = ex.Message });
            }
        }


        // DELETE: api/Users/5
        [HttpDelete("User/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                await _userService.DeleteUser(id);
                return Ok(new { success = true, message = "User Deleted Successfully." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = "Error Deleting User", error = ex.Message });
            }
        }

        // DELETE: api/Users/Image/5
        //[HttpDelete("Image/{id}")]
        //public async Task<IActionResult> DeleteImage(int id)
        //{
        //    try
        //    {
        //        await _userService.DeleteImage(id);
        //        return Ok(new { success = true, message = "Image Deleted Successfully." });
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(new { success = false, message = "Error Deleting image", error = ex.Message });
        //    }
        //}

        // POST: api/Users/authenticate
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate(LoginReqDTO loginReqDTO)
        {
            try
            {
                var user = await _userService.AuthenticateUser(loginReqDTO);

                if (user == null)
                {
                    return Unauthorized("Invalid credentials");
                }

                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
