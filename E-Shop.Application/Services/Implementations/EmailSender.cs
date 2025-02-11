using E_Shop.Application.Services.Interfaces;
using System.Net;
using System.Net.Mail;

namespace E_Shop.Application.Services.Implementations
{
    public class EmailSender : IEmailSender
    {
        public async Task SendEmailAsync(string email, string subject, string message)
        {
            MailMessage mailMessage = new();
            SmtpClient smtpClient = new("smtp.gmail.com");
            mailMessage.From = new MailAddress("NaderTempEmail@gmail.com");
            mailMessage.To.Add(email);
            mailMessage.Subject = subject;
            mailMessage.Body = message;
            mailMessage.IsBodyHtml = true;

            smtpClient.Port = 587;
            smtpClient.Credentials = new NetworkCredential("NaderTempEmail@gmail.com", "kagu fpev fqjz iiqe");
            smtpClient.EnableSsl = true;

            await smtpClient.SendMailAsync(mailMessage);
        }
    }
}
