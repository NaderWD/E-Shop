using E_Shop.Domain.Models;
using E_Shop.Domain.Repositories.Interfaces;
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

        public bool EmailIsDuplicated(string email)
        {
            var user = _context.Users.Where(u => u.EmailAddress == email);
            if (user.Any()) { return false; }
            else { return true; }

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

        public void Save()
        {
            _context.SaveChanges();
        }

        public bool UpdateUser(User user)
        {
            _context.Users.Update(user);
            return true;
        }
    }
}
