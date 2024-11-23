namespace CarRendalAPI.Models
{
    public class PasswordResetToken
    {
        public int Id { get; set; }
        public string Email { get; set; }  // The email of the user who requested the reset
        public string Token { get; set; }  // A unique token generated for the reset
        public DateTime Expiration { get; set; }  // Expiration time of the token
    }

}
