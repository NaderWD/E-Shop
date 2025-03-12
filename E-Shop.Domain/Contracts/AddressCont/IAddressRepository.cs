using E_Shop.Domain.Models.AddressModels;

namespace E_Shop.Domain.Contracts.AddressCont
{
    public interface IAddressRepository
    {
        Task CreateAddress(Address address);                 
        Task<List<Address>> GetAllAddresss();
        Task<Address> GetAddressById(int addressId);
        Task UpdateAddress(Address address);
        Task DeleteAddress(int addressId);
    }
}
