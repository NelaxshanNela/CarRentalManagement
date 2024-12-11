using CarRendalAPI.DTOs.RequestDTOs;
using CarRendalAPI.DTOs.ResponceDTOs;
using CarRendalAPI.IServices;
using CarRendalAPI.Models;
using CarRendalAPI.Services;
using CarRentalAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarRendalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _notificationService;

        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        [HttpPost]
        public async Task<IActionResult> AddNotification([FromBody] NotificationReqDTO request)
        {
            await _notificationService.AddNotification(request.Message, request.UserId, request.Email);
            return Ok(new { Success = true });
        }

        [HttpGet("{userId}")]
        public async Task<IEnumerable<Notification>> GetNotificationsByUserId(int userId)
        {
            return await _notificationService.GetNotificationsByUserId(userId);
        }

        [HttpPut("{notificationId}/mark-as-read")]
        public async Task<IActionResult> MarkAsRead(int notificationId)
        {
            await _notificationService.MarkAsRead(notificationId);
            return Ok(new { Success = true });
        }
    }
}
