namespace CarRentalAPI.Models
{
    public class NotificationReqDTO
    {
        public string Message { get; set; }  // The content of the notification
        public int UserId { get; set; }  // The ID of the user receiving the notification
    }
}
