using E_Shop.Domain.Models;
using E_Shop.Domain.ViewModels;

namespace E_Shop.Domain.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllUsers();
        Task<User> GetUserById(int id);
        Task<User> GetUserByEmail(string email);
        Task<int> CreateUser(User user);
        void UpdateUser(User user);
        Task DeleteUser(int id);
        Task Login(LoginVM login);
        Task Logout();
        Task Register(RegisterVM register);
    }
}
