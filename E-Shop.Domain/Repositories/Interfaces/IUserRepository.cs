using E_Shop.Domain.Models;
using E_Shop.Domain.ViewModels;
using static E_Shop.Domain.ViewModels.RegisterVM;

namespace E_Shop.Domain.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsers();
        Task<User> GetUserById(int id);
        Task<User> GetUserByEmail(string email);
        bool CreateUser(User user);
        bool UpdateUser(User user);
        void DeleteUser(int id);
        void Save();
        
        bool EmailIsDuplicated(string email);
    }
}
