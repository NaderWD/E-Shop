using E_Shop.Application.ViewModels;
using E_Shop.Domain.Enum;
using E_Shop.Domain.Models;
using static E_Shop.Application.ViewModels.LoginVM;
using static E_Shop.Application.ViewModels.RegisterVM;
using static E_Shop.Application.ViewModels.ResetPasswordVM;

namespace E_Shop.Application.Services.Interfaces
{
    public interface IUserService
    {
        Task<User> GetByEmail(string email);
        Task<RegisterResult> Register(RegisterVM register);
        Task<UserResult> ResetPassword(ResetPasswordVM resetPassword, string code, string password);
        public Task<LoginResult> Login(LoginVM login);
        public Task<ValidationErrorType> CreateUser(UserViewModel user);
        public Task<ValidationErrorType> UpdateUser(UserViewModel user , bool EmailCheck);
        Task<bool> DeleteUser(int id);
        public bool EmailIsDuplicated(string Email);
        public Task<UserViewModel> GetUserById(int id);
        public Task<IEnumerable<UserViewModel>> GetAllUsers();
    }
}
