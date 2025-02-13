using E_Shop.Domain.Models;
using E_Shop.Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace E_Shop.Infra.Data.Repositories.Implementations
{
    public class UserRepository(ShopDbContext _context) : IUserRepository
    {

        public async Task<bool> CreateUser(User user)
        {
            user.CreateDate = DateTime.Now;
            user.LastModifiedDate = DateTime.Now;
            await _context.Users.AddAsync(user);
            return true;
        }

        public async Task<bool> DeleteUser(int id)
        {
            var user = await GetUserById(id);
            _context.Remove(user);
            return true;
        }

        public async Task<bool> EmailIsDuplicated(string email)
        {
            return _context.Users.Any(u => u.EmailAddress == email);
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();

        }

        public async Task<User> GetUserByActivationCode(string code)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.ActivationCode == code);
            return user;
        }

        public async Task<User> GetUserByEmail(string email)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.EmailAddress == email);
            return user;
        }

        public async Task<User> GetUserById(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
        }


        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateUser(User user)
        {
            _context.Users.Update(user);
            return true;
        }


    }
}
