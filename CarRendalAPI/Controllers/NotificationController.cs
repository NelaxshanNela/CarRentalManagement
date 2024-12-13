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
        public async Task<IActionResult> AddNotification(NotificationReqDTO notificationReqDTO)
        {
            await _notificationService.AddNotification(notificationReqDTO);
            return Ok(new { Success = true });
        }

        [HttpGet("{userId}")]
        public async Task<IEnumerable<Notification>> GetNotificationsByUserId(int userId)
        {
            return await _notificationService.GetNotificationsByUserId(userId);
        }

        [HttpGet]
        public async Task<IEnumerable<Notification>> GetAllNotifications()
        {
            return await _notificationService.GetAlNotifications();
        }

        // PUT api/Notification/{notificationId}
        [HttpPut("{notificationId}")]
        public async Task<IActionResult> MarkAsRead(int notificationId, [FromBody] NotificationUpdateRequest request)
        {
            if (request == null)
            {
                return BadRequest("Invalid data.");
            }

            var notification = await _notificationService.GetNotificationByIdAsync(notificationId);
            if (notification == null)
            {
                return NotFound($"Notification with ID {notificationId} not found.");
            }

            // Mark the notification as read
            notification.IsRead = request.IsRead;
            await _notificationService.UpdateNotificationAsync(notification);

            return NoContent(); // HTTP 204 No Content, meaning the update was successful
        }
    }
}

