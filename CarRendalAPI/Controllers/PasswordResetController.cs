using CarRendalAPI.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarRendalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PasswordResetController : ControllerBase
    {
        private readonly IEmailService _emailService;

        public PasswordResetController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost("send-reset-email")]
        public async Task<IActionResult> SendPasswordResetEmail(string email)
        {
            // You should validate the email address here

            // Example: Send an email
            string resetLink = "http://yourapp.com/reset-password?token=xyz123";  // Your reset link
            string body = $"Click the following link to reset your password: {resetLink}";

            await _emailService.SendEmailAsync(email, "Password Reset", body);

            return Ok("Password reset email has been sent.");
        }

        //[HttpPost("send-reset-email")]
        //public async Task<IActionResult> SendPasswordResetEmail(string email)
        //{
        //    // Validate email, then send email
        //    string resetLink = "http://yourapp.com/reset-password?token=xyz123";
        //    string body = $"Click the following link to reset your password: {resetLink}";

        //    await _emailService.SendEmailAsync(email, "Password Reset", body);

        //    return Ok("Password reset email has been sent.");
        //}
    }

}
