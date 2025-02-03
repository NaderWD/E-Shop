using E_Shop.Domain.Models;
using E_Shop.Domain.Repositories.Interfaces;
using E_Shop.Infra.Data;

namespace E_Shop.Infra.IOC.Repositories.Implementation
{
    public class UserRepository(ShopDbContext context) : IUserRepository
    {
        private readonly ShopDbContext _context = context;


        public Task<int> CreateUserAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task DeleteUserAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<User>> GetAllUsersAsynce()
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateUserAsync(User user)
        {
            throw new NotImplementedException();
        }
    }
}
