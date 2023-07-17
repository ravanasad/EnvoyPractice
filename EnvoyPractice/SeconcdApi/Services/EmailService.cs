using Microsoft.Extensions.Options;
using SeconcdApi.Dtos;
using SeconcdApi.Services.Interfaces;
using System.Net;
using System.Net.Mail;

namespace SeconcdApi.Services
{
    public class EmailService : IEmailService
    {
        private readonly EmailSettings _emailSettings;
        public EmailService(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }

        public async Task<ResponseDto> SendEmail(RequestDto request)
        {
            var smtpClient = new SmtpClient(_emailSettings.Host)
            {
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Port = 587,
                Credentials = new NetworkCredential(_emailSettings.Email, _emailSettings.Password),
                EnableSsl = true
            };
            Random rand = new Random();
            var mailMessage = new MailMessage()
            {
                From = new MailAddress(_emailSettings.Email),
                Subject = "Notification",
                Body = $"You registered our system. Welcome {request.Fullname}.",
                IsBodyHtml = true,
            };
            mailMessage.To.Add(new MailAddress(request.Email));
            await smtpClient.SendMailAsync(mailMessage);
            ResponseDto response = new(request.Fullname, request.Email, request.Message);
            return response;
        }
    }
}
