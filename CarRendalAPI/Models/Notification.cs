using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CarRendalAPI.Models
{
    public class Notification
    {
        [Key]
        public int NotificationId { get; set; }
        public string Message { get; set; }
        public string Type { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
        public bool IsRead { get; set; } = false;
        public DateTime? DateRead { get; set; }

        public int UserId { get; set; }
        [JsonIgnore]
        public User User { get; set; }
    }
}
