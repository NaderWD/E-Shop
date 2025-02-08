using E_Shop.Domain.Models;
using E_Shop.Domain.ViewModels;
using static E_Shop.Domain.ViewModels.LoginVM;
using static E_Shop.Domain.ViewModels.RegisterVM;
using static E_Shop.Domain.ViewModels.ResetPasswordVM;

namespace E_Shop.Application.Services.Interfaces
{
    public interface IUserService
    {
        Task<User> GetByEmail(string email);
        Task<UserResult> ResetPassword(ResetPasswordVM userVM, string code, string password);
        Task<bool> EmailExist(string email);
        Task<RegisterResults> Register(RegisterVM userVM);
        Task<LoginResults> Login(LoginVM userVM);
        Task<bool> ActivateAccount(ForgetPasswordVM userVM, string code);
    }
}
