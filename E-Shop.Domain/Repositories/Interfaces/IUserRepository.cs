using E_Shop.Domain.Models;
using E_Shop.Domain.ViewModels;

namespace E_Shop.Domain.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsers();
        Task<User> GetUserById(int id);
        Task<User> GetUserByEmail(string email);
        bool CreateUser(User user);
        void UpdateUser(User user);
        void DeleteUser(int id);
        Task LoginUser(LoginVM login);
        Task LogoutUser();
        Task RegisterUser(RegisterVM register);
    }
}
