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

        public async Task AddNotification(string message, int userId, string email = null)
        {
            var notification = new Notification
            {
                Message = message,
                UserId = userId
            };

            await _notificationRepository.AddNotification(notification);

            if (!string.IsNullOrEmpty(email))
            {
                await _emailService.SendEmailAsync(email, "Notification", message);
            }
        }

        public async Task<IEnumerable<Notification>> GetNotificationsByUserId(int userId)
        {
            return await _notificationRepository.GetNotificationsByUserId(userId);
        }

        public async Task MarkAsRead(int notificationId)
        {
            await _notificationRepository.MarkAsRead(notificationId);
        }

    }
}
