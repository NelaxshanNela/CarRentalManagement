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
        Task<IEnumerable<Notification>> GetAllNotifications();
        Task<Notification> GetNotificationById(int id);
        Task<Notification> CreateNotification(NotificationReqDTO notificationReqDTO);
        Task<Notification> UpdateNotification(int id, NotificationReqDTO notificationReqDTO);
        Task DeleteNotification(int id);
    }
}
