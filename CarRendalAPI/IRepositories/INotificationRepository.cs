using CarRendalAPI.Models;

namespace CarRendalAPI.IRepositories
{
    public interface INotificationRepository
    {
        public Task<IEnumerable<Notification>> GetAllNotification();
        public Task<Notification> GetNotificationById(int id);
        public Task<Notification> CreateNotification(Notification notification);
        public Task<Notification> UpdateNotification(Notification notification);
        public Task DeleteNotification(int id);
    }
}