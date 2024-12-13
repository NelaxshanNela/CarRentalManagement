using CarRendalAPI.DTOs.RequestDTOs;
using CarRendalAPI.DTOs.ResponceDTOs;
using CarRendalAPI.Models;
using CarRentalAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarRendalAPI.IServices
{
    public interface INotificationService
    {
        Task AddNotification(NotificationReqDTO notificationReqDTO);
        Task<IEnumerable<Notification>> GetNotificationsByUserId(int userId);
        Task<Notification> GetNotificationByIdAsync(int notificationId);
        Task<IEnumerable<Notification>> GetAlNotifications();
        Task UpdateNotificationAsync(Notification notification);
    }
}
