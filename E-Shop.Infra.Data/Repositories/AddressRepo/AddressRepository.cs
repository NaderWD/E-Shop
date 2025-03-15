using E_Shop.Domain.Contracts.AddressCont;
using E_Shop.Domain.Models.AddressModels;
using Microsoft.EntityFrameworkCore;

namespace E_Shop.Infra.Data.Repositories.AddressRepo
{
    public class AddressRepository(ShopDbContext _context) : IAddressRepository
    {
        public async Task CreateAddress(Address address)
            => await _context.Addresses.AddAsync(address);

        public async Task<List<Address>> GetAllAddresss()
            => await _context.Addresses.Include(x => x.City)
                                                         .Include(x => x.State)
                                                         .Where(x => !x.IsDelete)
                                                         .ToListAsync();

        public async Task<Address> GetAddressById(int addressId)
            => await _context.Addresses.Include(x => x.City)
                                                         .Include(x => x.State)
                                                         .FirstOrDefaultAsync(x => x.Id == addressId && !x.IsDelete);

        public async Task UpdateAddress(Address address)
            => _context.Addresses.Update(address);

        public async Task DeleteAddress(int addressId)
            => _context.Addresses.Remove(await GetAddressById(addressId));
    }
}
