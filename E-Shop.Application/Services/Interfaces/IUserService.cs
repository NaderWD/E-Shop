using E_Shop.Application.ViewModels;
using E_Shop.Domain.Models;
using static E_Shop.Application.ViewModels.LoginVM;
using static E_Shop.Application.ViewModels.RegisterVM;
using static E_Shop.Application.ViewModels.ResetPasswordVM;

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
        public Task<ValidationErrorType> CreateUser(UserViewModel user);
        public Task<ValidationErrorType> UpdateUser(UserViewModel user);
        public bool DeleteUser(int id);
        public Task<User> GetUserById(int id);
        public Task<IEnumerable<UserViewModel>> GetAllUsers();
    }
}
