using E_Shop.Domain.Models.AddressModels;

namespace E_Shop.Domain.Contracts.AddressCont
{
    public interface IUserAddressRepository
    {
        Task CreateUserAddress(UserAddress userAddress);
        Task<List<UserAddress>> GetAllUserAddresses();                            
        Task<List<Address>> GetAddressListByUserId(int userId);
        Task<List<UserAddress>> GetUserAddressListByUserId(int userId);
        Task<UserAddress> GetUserAddressById(int userAddressId);
        Task UpdateUserAddress(UserAddress userAddress);
        Task DeleteUserAddress(int userAddressId);
        Task Save();
    }
}
