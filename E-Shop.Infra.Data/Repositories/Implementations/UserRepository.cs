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

        public bool DeleteUser(int id)
        {
           var user = GetUserById(id);
            _context.Remove(user);
            return true;
        }

        public bool EmailIsDuplicated(string email)
        {
            return _context.Users.Any(u => u.EmailAddress == email);
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            List<User> users = [];
            var models = await _context.Users.ToListAsync();
            foreach (var item in models)
            {
                users.Add(new User()
                {
                    EmailAddress = item.EmailAddress,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    Id = item.Id,
                    IsActive = item.IsActive,
                    IsAdmin = item.IsAdmin,
                    ActivationCode = item.ActivationCode,
                    LastModifiedDate = item.LastModifiedDate,
                    Mobile = item.Mobile,
                    Password = item.Password,
                    IsDelete = item.IsDelete,

                });
            }
            return users;
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


        public void Save()
        {
            _context.SaveChanges();
        }

        public bool UpdateUser(User user)
        {
            _context.Users.Update(user);
            Save();
            return true;
        }


    }
}
