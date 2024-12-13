using CarRendalAPI.Models;

namespace CarRendalAPI.IRepositories
{
    public interface INotificationRepository
    {
        public Task AddNotification(Notification notification);
        public Task<IEnumerable<Notification>> GetNotificationsByUserId(int userId);
        Task<Notification> GetNotificationByIdAsync(int notificationId);
        Task<IEnumerable<Notification>> GetAlNotifications();
        Task UpdateNotificationAsync(Notification notification);
    }
}