using E_Shop.Application.ViewModels.AccountViewModels;
using E_Shop.Domain.Models.UserModels;

namespace E_Shop.Application.Services.Interfaces
{
    public interface IAccountService
    {
        Task<User> GetByEmail(string email);
        Task<string> Login(LoginVM userVM);
        Task<string> Register(RegisterVM userVM);
        Task<bool> EmailExist(string email);
        Task<bool> ConfirmEmailService(ConfirmEmailVM model);
        Task<string> ReSendCode(string email);
        Task<string> ForgetPasswordCode(ForgetPasswordVM userVM);
        Task<string> ResetPassword(ResetPasswordVM userVM, string code, string password);
        Task<bool> AdminCheck(int userId);
    }
}
