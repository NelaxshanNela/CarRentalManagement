namespace CarRendalAPI.DTOs.RequestDTOs
{
    public class PasswordChangeDTO
    {
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmNewPassword { get; set; }
    }
}
