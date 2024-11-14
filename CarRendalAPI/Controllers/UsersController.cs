//using CarRendalAPI.IServices;
//using CarRendalAPI.Models;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace CarRendalAPI.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class UsersController : ControllerBase
//    {
//        private readonly IUserService _userService;

//        public UsersController(IUserService userService)
//        {
//            _userService = userService;
//        }

//        // GET: api/Users
//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
//        {
//            var users = await _userService.GetAllUsersAsync();
//            return Ok(users);
//        }

//        // GET: api/Users/5
//        [HttpGet("{id}")]
//        public async Task<ActionResult<User>> GetUser(int id)
//        {
//            var user = await _userService.GetUserByIdAsync(id);

//            if (user == null)
//            {
//                return NotFound();
//            }

//            // Optionally, fetch the user profile image URL
//            //var profileImageUrl = await _userService.GetUserProfileImageUrlAsync(id);

//            return Ok(new
//            {
//                User = user,
//                //ProfileImageUrl = profileImageUrl
//            });
//        }

//        // POST: api/Users
//        [HttpPost]
//        public async Task<ActionResult<User>> CreateUser(User user)
//        {
//            // You can include validation here (e.g., check if the email is unique)
//            await _userService.CreateUserAsync(user);
//            return CreatedAtAction(nameof(GetUser), new { id = user.UserId }, user);
//        }

//        // PUT: api/Users/5
//        [HttpPut("{id}")]
//        public async Task<IActionResult> UpdateUser(int id, User user)
//        {
//            if (id != user.UserId)
//            {
//                return BadRequest();
//            }

//            await _userService.UpdateUserAsync(user);
//            return NoContent();
//        }

//        // DELETE: api/Users/5
//        [HttpDelete("{id}")]
//        public async Task<IActionResult> DeleteUser(int id)
//        {
//            await _userService.DeleteUserAsync(id);
//            return NoContent();
//        }

//        // POST: api/Users/authenticate
//        [HttpPost("authenticate")]
//        public async Task<ActionResult<User>> Authenticate([FromBody] UserLoginModel loginModel)
//        {
//            var user = await _userService.AuthenticateUserAsync(loginModel.Email, loginModel.Password);

//            if (user == null)
//            {
//                return Unauthorized("Invalid credentials");
//            }

//            return Ok(user);
//        }
//    }

//}
