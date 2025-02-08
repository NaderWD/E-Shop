using E_Shop.Domain.Models;

namespace E_Shop.Domain.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsers();
        Task<User?> GetUserById(int id);
        Task<User> GetUserByEmail(string email);
        Task<User> GetUserByActivationCode(string code);
        bool EmailIsDuplicated(string email);
        bool CreateUser(User user);
        bool UpdateUser(User user);
        Task<bool> DeleteUser(int id);
        void Save();
    }
}
