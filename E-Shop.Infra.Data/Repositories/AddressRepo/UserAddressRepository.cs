using E_Shop.Domain.Contracts.AddressCont;
using E_Shop.Domain.Models.AddressModels;
using Microsoft.EntityFrameworkCore;

namespace E_Shop.Infra.Data.Repositories.UserAddressRepo
{
    public class UserAddressRepository(ShopDbContext _context) : IUserAddressRepository
    {
        public async Task CreateUserAddress(UserAddress userAddress)
            => await _context.UserAddresses.AddAsync(userAddress);
                                                                                                                  
        public async Task<List<UserAddress>> GetAllUserAddresses()
            => await _context.UserAddresses.Include(x => x.Address)
                                                                .ThenInclude(x => x.City)
                                                                .ThenInclude(x => x.State)
                                                                .Where(x => !x.IsDelete)
                                                                .ToListAsync();

        public async Task<List<Address>> GetAddressListByUserId(int userId)
            => await _context.UserAddresses.Include(x => x.Address)
                                                                 .Include(x => x.User)
                                                                 .Where(x => x.UserId == userId)
                                                                 .Select(x => x.Address!)
                                                                 .ToListAsync();

        public async Task<List<UserAddress>> GetUserAddressListByUserId(int userId)
            => await _context.UserAddresses.Include(x => x.Address)
                                                                         .Include(x => x.User)
                                                                         .Where(x => x.UserId == userId)
                                                                         .ToListAsync();

        public async Task<UserAddress> GetUserAddressById(int userAddressId)
            => await _context.UserAddresses.Include(x => x.Address)
                                                                         .ThenInclude(x => x.City)
                                                                         .ThenInclude(x => x.State)
                                                                         .FirstOrDefaultAsync(x => x.Id == userAddressId && !x.IsDelete);

        public async Task UpdateUserAddress(UserAddress userAddress)
            => _context.UserAddresses.Update(userAddress);

        public async Task DeleteUserAddress(int userAddressId)
            => _context.UserAddresses.Remove(await GetUserAddressById(userAddressId));

        public async Task Save() => await _context.SaveChangesAsync();
    }
}
