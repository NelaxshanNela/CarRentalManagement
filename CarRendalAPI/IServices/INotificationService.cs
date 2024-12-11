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
        Task AddNotification(string message, int userId, string email = null);
        Task<IEnumerable<Notification>> GetNotificationsByUserId(int userId);
        Task MarkAsRead(int notificationId);
    }
}
