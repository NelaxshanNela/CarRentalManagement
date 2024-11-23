using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CarRendalAPI.Models
{
    public class Notification
    {
        [Key]
        public int NotificationId { get; set; }  // Unique identifier for the notification
        public string Message { get; set; }  // The content of the notification
        public DateTime DateCreated { get; set; }  // When the notification was created
        public bool IsRead { get; set; }  // Whether the notification has been read by the user
        public DateTime? DateRead { get; set; }  // When the notification was read (nullable)

        public int UserId { get; set; }  // The ID of the user receiving the notification
        [JsonIgnore]
        public User User { get; set; }  // Navigation property to the User entity
    }
}
