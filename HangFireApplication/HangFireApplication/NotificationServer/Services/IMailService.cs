using MailKit.Net.Smtp;
using MimeKit;
using NotificationServer.Configurations;
using NotificationServer.Models;


namespace NotificationServer.Services
{
    public interface IMailService
    {
        Task SendEmailAsync(EmailBody email);
    }
    public class MailService : IMailService
    {
        private readonly IConfiguration _configuration;

        public MailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendEmailAsync(EmailBody email)
        {
            var configuration = _configuration.GetSection("EmailConfiguration").Get<EmailConfiguration>();
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress(configuration.DisplayName, configuration.From));
            emailMessage.To.Add(new MailboxAddress("Kemalll", email.To));

            if (!string.IsNullOrWhiteSpace(email.Cc))
            {
                emailMessage.Cc.Add(new MailboxAddress("Ceyhun", email.Cc));
            }
            if (!string.IsNullOrWhiteSpace(email.Bcc))
            {
                emailMessage.Bcc.Add(new MailboxAddress("hesen", email.Cc));
            }
            emailMessage.Subject = email.Subject;
            var bodyBuilder = new BodyBuilder
            {
                HtmlBody = email.Body
            };

            if (email.Attachments.Count > 0)
            {
                foreach (var attachment in email.Attachments)
                {
                    bodyBuilder.Attachments.Add(attachment.FileName, attachment.FileContent);
                }
            }
            emailMessage.Body = bodyBuilder.ToMessageBody();
            using (var client = new SmtpClient())
            {
                try
                {
                    await client.ConnectAsync(configuration.SmtpServer, configuration.Port, false);
                    await client.AuthenticateAsync(configuration.UserName, configuration.Password);
                    await client.SendAsync(emailMessage);
                    await client.DisconnectAsync(true);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
    }
}
