using CarRendalAPI.DTOs.RequestDTOs;
using CarRendalAPI.DTOs.ResponceDTOs;
using CarRendalAPI.IRepositories;
using CarRendalAPI.IServices;
using CarRendalAPI.Models;
using CarRendalAPI.Repositories;
using CarRentalAPI.Models;


namespace CarRendalAPI.Services
{
    public class NotificationService : INotificationService
    {
        private readonly INotificationRepository _notificationRepository;

        public NotificationService(INotificationRepository notificationRepository)
        {
            _notificationRepository = notificationRepository;
        }

        public async Task<IEnumerable<Notification>> GetAllNotifications()
        {
            return await _notificationRepository.GetAllNotification();
        }

        public async Task<Notification> GetNotificationById(int id)
        {
            return await _notificationRepository.GetNotificationById(id);
        }

        public async Task<Notification> CreateNotification(NotificationReqDTO notificationReqDTO)
        {
            // Map NotificationReqDTO to Notification entity
            var notification = new Notification
            {
                Message = notificationReqDTO.Message,
                UserId = notificationReqDTO.UserId,
                DateCreated = DateTime.UtcNow, // Assuming the notification is created when it's saved
                IsRead = false
            };

            return await _notificationRepository.CreateNotification(notification);
        }


        public async Task<Notification> UpdateNotification(int id, NotificationReqDTO notificationReqDTO)
        {
            var existingNotification = await _notificationRepository.GetNotificationById(id);

            if (existingNotification == null)
                throw new KeyNotFoundException($"Notification with ID {id} not found");

            existingNotification.Message = notificationReqDTO.Message;
            existingNotification.UserId = notificationReqDTO.UserId;
            existingNotification.DateCreated = DateTime.UtcNow; // Or leave it as is, depending on your requirement

            return await _notificationRepository.UpdateNotification(existingNotification);
        }


        public async Task DeleteNotification(int id)
        {
            await _notificationRepository.DeleteNotification(id);
        }
    }
}
