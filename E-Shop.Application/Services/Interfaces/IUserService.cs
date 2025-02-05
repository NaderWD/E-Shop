using E_Shop.Application.ViewModels;
using E_Shop.Domain.Models;
using E_Shop.Domain.ViewModels;
using static E_Shop.Domain.ViewModels.LoginVM;
using static E_Shop.Domain.ViewModels.RegisterVM;

namespace E_Shop.Application.Services.Interfaces
{
    public interface IUserService
    {
        public Task<LoginResult> Login(LoginVM login);
        public Task<User> GetByEmail(string email);
        public Task<RegisterResult> Register(RegisterVM register);
        public Task<ValidationErrorType> CreateUser(UserViewModel user);
        public Task<ValidationErrorType> UpdateUser(UserViewModel user);
        public bool DeleteUser(int id);
        public Task<User> GetUserById(int id);
        public Task<IEnumerable<UserViewModel>> GetAllUsers();
    }
}
