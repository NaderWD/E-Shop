using E_Shop.Application.ViewModels;
using E_Shop.Domain.Models;
using static E_Shop.Application.ViewModels.LoginVM;
using static E_Shop.Application.ViewModels.ResetPasswordVM;

namespace E_Shop.Application.Services.Interfaces
{
    public interface IUserService
    {
        Task<User> GetByEmail(string email);
        Task<UserResult> ResetPassword(ResetPasswordVM userVM, string code, string password);
        Task<bool> EmailExist(string email);
        Task<string> Register(RegisterVM userVM);
        Task<LoginResults> Login(LoginVM userVM);
        Task<bool> ActivateAccount(string code);
        Task<ValidationErrorType> CreateUser(UserViewModel user);
        Task<ValidationErrorType> UpdateUser(UserViewModel user);
        bool DeleteUser(int id);
        Task<User> GetUserById(int id);
        Task<IEnumerable<UserViewModel>> GetAllUsers();
        Task<bool> ConfirmEmailService(ConfirmEmailVM model);
    }
}
