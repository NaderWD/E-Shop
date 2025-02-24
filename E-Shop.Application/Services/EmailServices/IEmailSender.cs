namespace E_Shop.Application.Services.EmailServices
{
    public interface IEmailSender
    {
        Task<bool> SendEmailAsync(string email, string subject, string message);
    }
}
