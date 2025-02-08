using E_Shop.Domain.Models;

namespace E_Shop.Domain.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsers();
        Task<User> GetUserById(int id);
        Task<User> GetUserByEmail(string email);
        Task<bool> CheckEmailExist(string email);
        Task<bool> CreateUser(User user);
        void UpdateUser(User user);
        void DeleteUser(int id);
        void Save();
    }
}
