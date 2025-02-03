using E_Shop.Domain.Models;

namespace E_Shop.Domain.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllUsersAsynce();
        Task<User> GetUserById(int id);
        Task<User> GetUserByEmail(string email);
        Task<int> CreateUserAsync(User user);
        void UpdateUserAsync(User user);
        Task DeleteUserAsync(int id);
    }
}
