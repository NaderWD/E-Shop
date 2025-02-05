using E_Shop.Domain.Models;
using E_Shop.Domain.ViewModels;
using static E_Shop.Domain.ViewModels.LoginVM;
using static E_Shop.Domain.ViewModels.RegisterVM;
using static E_Shop.Domain.ViewModels.ResetPasswordVM;

namespace E_Shop.Application.Services.Interfaces
{
    public interface IUserService
    {
        Task<LoginResult> Login(LoginVM login);
        Task<User> GetByEmail(string email);
        Task<RegisterResult> Register(RegisterVM register);
        Task<UserResult> ResetPassword(ResetPasswordVM resetPassword, string code, string password);
    }
}
