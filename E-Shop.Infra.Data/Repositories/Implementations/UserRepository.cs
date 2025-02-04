using E_Shop.Domain.Models;
using E_Shop.Domain.Repositories.Interfaces;
using E_Shop.Domain.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace E_Shop.Infra.Data.Repositories.Implementations
{
    public class UserRepository(ShopDbContext context) : IUserRepository
    {

        private readonly ShopDbContext _context = context;

        public bool CreateUser(User user)
        {
            _context.Users.Add(user);
            return true;
        }

        public async void DeleteUser(int id)
        {
            var user = await GetUserById(id);
            _context.Users.Remove(user);
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            var models = await _context.Users.ToListAsync();
            return models;
        }

        public async Task<User> GetUserByEmail(string email)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.EmailAddress == email);
            return user;
        }

        public async Task<User> GetUserById(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            return user;
        }

        public Task RegisterUser(RegisterVM register)
        {
            User user = new()
            {
                EmailAddress = register.EmailAddress,
                Password = register.Password,
            };
            _context.Users.Add(user);
            return Task.CompletedTask;
        }

        public void UpdateUser(User user)
        {
            _context.Users.Update(user);
        }
    }
}
