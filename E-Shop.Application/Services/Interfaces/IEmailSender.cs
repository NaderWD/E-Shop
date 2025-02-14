namespace E_Shop.Application.Services.Interfaces
{
    public interface IEmailSender
    {
        Task<bool> SendEmailAsync(string email, string subject, string message);
    }
}
