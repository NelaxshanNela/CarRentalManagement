using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CarRendalAPI.Models
{
    public class Reservation
    {
        [Key]
        public int ReservationId { get; set; }
        public DateTime ReservationDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; }
        public int CarId { get; set; }
        [JsonIgnore]
        public Car Car { get; set; }
        public int UserId { get; set; }
        [JsonIgnore]
        public User User { get; set; }
    }
}
