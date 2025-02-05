using E_Shop.Domain.Models;
using E_Shop.Domain.ServicesModels;
using E_Shop.Domain.ViewModels;
using static E_Shop.Domain.ViewModels.LoginVM;
using static E_Shop.Domain.ViewModels.RegisterVM;

namespace E_Shop.Application.Services.Interfaces
{
    public interface IUserService
    {
        Task<LoginResult> Login(LoginVM login);
        Task<User> GetByEmail(string email);
        Task<RegisterResult> Register(RegisterVM register);
        Task<string> SetActivationCode(ForgetPasswordVM model);
        void SendVerificationEmail(Email email);
    }
}
