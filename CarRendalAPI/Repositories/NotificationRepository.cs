using CarRendalAPI.Database;
using CarRendalAPI.IRepositories;
using CarRendalAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRendalAPI.Repositories
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly ApplicationDbContext _context;
        public NotificationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Notification>> GetAllNotification()
        {
            return await _context.Notifications.ToListAsync();
        }

        public async Task<Notification> GetNotificationById(int id)
        {
            return await _context.Notifications.FirstOrDefaultAsync(n => n.NotificationId == id);
        }



        public async Task<Notification> CreateNotification(Notification notification)
        {
            await _context.AddAsync(notification);
            await _context.SaveChangesAsync();
            return notification;
        }

        public async Task<Notification> UpdateNotification(Notification notification)
        {
            _context.Notifications.Update(notification);
            await _context.SaveChangesAsync();
            return notification;
        }

        public async Task DeleteNotification(int id)
        {
            var notification = await GetNotificationById(id);
            if (notification != null)
            {
                _context.Remove(notification);
                await _context.SaveChangesAsync();
            }
        }

    }
}
