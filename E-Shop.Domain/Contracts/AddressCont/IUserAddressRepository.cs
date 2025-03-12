using E_Shop.Domain.Models.AddressModels;

namespace E_Shop.Domain.Contracts.AddressCont
{
    public interface IUserAddressRepository
    {
        Task CreateUserAddress(UserAddress userAddress);
        Task<List<UserAddress>> GetAllUserAddresss();
        Task<UserAddress> GetUserAddressById(int userAddressId);
        Task UpdateUserAddress(UserAddress userAddress);
        Task DeleteUserAddress(int userAddressId);
        Task Save();
    }
}
