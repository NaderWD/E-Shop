using E_Shop.Domain.Models;

namespace E_Shop.Domain.Contracts.Users
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllUsers();
        Task<User> GetUserById(int id);
        Task<User> GetUserByEmail(string email);
        Task<User> GetUserByActivationCode(string code);
        Task<bool> EmailIsDuplicated(string email);
        Task<bool> ChekAdmin(int id);
        Task<bool> CreateUser(User user);
        Task<bool> UpdateUser(User user);
        Task<bool> DeleteUser(int id);
        Task Save();
    }
}
