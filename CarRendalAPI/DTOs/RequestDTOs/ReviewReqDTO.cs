namespace CarRendalAPI.DTOs.RequestDTOs
{
    public class ReviewReqDTO
    {
        public int Rating { get; set; }
        public string Comments { get; set; }
        public int UserId { get; set; }
        public int CarId { get; set; }
    }
}
