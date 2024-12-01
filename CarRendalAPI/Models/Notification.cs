using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CarRendalAPI.Models
{
    public class Notification
    {
        [Key]
        public int NotificationId { get; set; }
        public string Message { get; set; }
        public DateTime DateCreated { get; set; }
        public bool IsRead { get; set; }
        public DateTime? DateRead { get; set; }

        public int UserId { get; set; }
        [JsonIgnore]
        public User User { get; set; }
    }
}
