namespace CarRendalAPI.Services
{
    using SendGrid;
    using SendGrid.Helpers.Mail;
    using Microsoft.Extensions.Options;
    using System.Threading.Tasks;
    using CarRendalAPI.IServices;
    using CarRendalAPI.Models;

    public class SendGridEmailService : IEmailService
    {
        private readonly EmailSettings _emailSettings;

        public SendGridEmailService(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }

        public async Task SendEmailAsync(string toEmail, string subject, string body)
        {
            var client = new SendGridClient(_emailSettings.SendGridApiKey);
            var from = new EmailAddress(_emailSettings.FromEmail, "Your App Name");
            var to = new EmailAddress(toEmail);
            var msg = MailHelper.CreateSingleEmail(from, to, subject, body, body);

            var response = await client.SendEmailAsync(msg);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new InvalidOperationException($"Failed to send email. Status: {response.StatusCode}");
            }
        }
    }

}
