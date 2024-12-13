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
        private readonly IEmailService _emailService;

        public NotificationService(INotificationRepository notificationRepository, IEmailService emailService)
        {
            _notificationRepository = notificationRepository;
            _emailService = emailService;
        }

        public async Task AddNotification(NotificationReqDTO notificationReqDTO)
        {
            var notification = new Notification
            {
                Message = notificationReqDTO.Message,
                Type = notificationReqDTO.Type,
                UserId = notificationReqDTO.UserId,
                DateCreated = DateTime.UtcNow,
                IsRead = false
            };

            await _notificationRepository.AddNotification(notification);

            //if (!string.IsNullOrEmpty(notificationReqDTO.Email))
            //{
            //    await _emailService.SendEmailAsync(notificationReqDTO.Email, "Notification", notificationReqDTO.Message);
            //}
        }

        public async Task<IEnumerable<Notification>> GetNotificationsByUserId(int userId)
        {
            return await _notificationRepository.GetNotificationsByUserId(userId);
        }

        public async Task<Notification> GetNotificationByIdAsync(int notificationId)
        {
            return await _notificationRepository.GetNotificationByIdAsync(notificationId);
        }

        public async Task<IEnumerable<Notification>> GetAlNotifications()
        {
            return await _notificationRepository.GetAlNotifications();
        }

        public async Task UpdateNotificationAsync(Notification notification)
        {
            await _notificationRepository.UpdateNotificationAsync(notification);
        }

    }
}
