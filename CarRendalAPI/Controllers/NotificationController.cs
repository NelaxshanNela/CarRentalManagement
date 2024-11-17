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

        [HttpGet]
        public async Task<IActionResult> GetAllNotifications()
        {
            try
            {
                var notifications = await _notificationService.GetAllNotifications();
                return Ok(notifications);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetNotificationById(int id)
        {
            try
            {
                var notification = await _notificationService.GetNotificationById(id);
                var notificationResDTO = new NotificationResDTO
                {
                    NotificationId = notification.NotificationId,
                    Message = notification.Message,
                    DateCreated = notification.DateCreated,
                    IsRead = notification.IsRead,
                    DateRead = notification.DateRead,
                    UserId = notification.UserId
                };

                return Ok(notificationResDTO);
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


        [HttpPost]
        [HttpPost]
        public async Task<IActionResult> CreateNotification(NotificationReqDTO notificationReqDTO)
        {
            try
            {
                var createdNotification = await _notificationService.CreateNotification(notificationReqDTO);

                // Map to NotificationResDTO to return
                var notificationResDTO = new NotificationResDTO
                {
                    NotificationId = createdNotification.NotificationId,
                    Message = createdNotification.Message,
                    DateCreated = createdNotification.DateCreated,
                    IsRead = createdNotification.IsRead,
                    DateRead = createdNotification.DateRead,
                    UserId = createdNotification.UserId
                };

                return CreatedAtAction(nameof(GetNotificationById), new { id = createdNotification.NotificationId }, notificationResDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }




        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateNotification(int id, NotificationReqDTO notificationReqDTO)
        {
            try
            {
                var updatedNotification = await _notificationService.UpdateNotification(id, notificationReqDTO);
                return Ok(updatedNotification);
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNotification(int id)
        {
            try
            {
                await _notificationService.DeleteNotification(id);
                return Ok("Notification Deleted Successfully.");
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
    }
}
