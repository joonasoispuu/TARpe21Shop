using Microsoft.Extensions.Configuration;
using TARpe21Shop.Core.Dto;
using TARpe21Shop.Core.ServiceInterface;
using MimeKit;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;

namespace TARpe21Shop.ApplicationServices.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _config;

        public EmailService(IConfiguration config)
        {
            _config = config;
        }
        public void SendEmail(EmailDto dto)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_config.GetSection("EmailUSerName").Value));
            email.To.Add(MailboxAddress.Parse(dto.To));
            email.Subject = dto.Subject;
            email.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = dto.Body
            };

            using var smtp = new SmtpClient();

            smtp.Connect(_config.GetSection("EmailHost").Value, 587, MailKit.Security.SecureSocketOptions.StartTls);
            smtp.Authenticate(_config.GetSection("EmailUserName").Value, _config.GetSection("EmailPassword").Value);
            smtp.Send(email);
            smtp.Disconnect(true);
        }
    }
}