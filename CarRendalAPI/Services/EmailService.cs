using MimeKit;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using CarRendalAPI.IServices;
using CarRendalAPI.Models;

public class EmailService : IEmailService
{
    private readonly EmailSettings _emailSettings;

    public EmailService(IOptions<EmailSettings> emailSettings)
    {
        _emailSettings = emailSettings.Value;
    }

    public async Task SendEmailAsync(string toEmail, string subject, string body)
    {
        var emailMessage = new MimeMessage();

        emailMessage.From.Add(new MailboxAddress("Your App Name", _emailSettings.FromEmail));
        emailMessage.To.Add(new MailboxAddress("", toEmail));
        emailMessage.Subject = subject;

        // Set the body of the email
        emailMessage.Body = new TextPart("plain")
        {
            Text = body
        };

        using (var client = new SmtpClient())
        {
            try
            {
                // Connect to the SMTP server
                await client.ConnectAsync(_emailSettings.SmtpServer, _emailSettings.SmtpPort, false);
                await client.AuthenticateAsync(_emailSettings.SmtpUser, _emailSettings.SmtpPassword);

                // Send the email
                await client.SendAsync(emailMessage);
            }
            catch (Exception ex)
            {
                // Handle any exceptions (e.g., connection errors, authentication failures)
                throw new InvalidOperationException("Failed to send email", ex);
            }
            finally
            {
                // Disconnect the client
                await client.DisconnectAsync(true);
                client.Dispose();
            }
        }
    }
}
