using E_Shop.Application.ViewModels;
using E_Shop.Application.ViewModels.AccountViewModels;
using E_Shop.Domain.Enum;
using E_Shop.Domain.Models;

namespace E_Shop.Application.Services.Interfaces
{
    public interface IUserService
    {
        Task<User> GetByEmail(string email);
        Task<string> ResetPassword(ResetPasswordVM userVM, string code, string password);
        Task<string> ForgetPasswordCode(ForgetPasswordVM userVM);
        Task<bool> EmailExist(string email);
        Task<string> Register(RegisterVM userVM);
        Task<string> Login(LoginVM userVM);
        Task<ValidationErrorType> CreateUser(UserViewModel userVM);
        Task<ValidationErrorType> UpdateUser(UserViewModel userVM, bool EmailCheck);
        Task<bool> DeleteUser(int id);
        Task<UserViewModel> GetUserById(int id);
        Task<IEnumerable<UserViewModel>> GetAllUsers();
        Task<bool> ConfirmEmailService(ConfirmEmailVM model);
        Task<string> ReSendCode(string email);  
    }
}
