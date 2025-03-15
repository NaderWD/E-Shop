namespace E_Shop.Application.Services.AddressServices
{
    public interface IUserAddressServices
    {
        Task CreateUserAddress(int userId, int addressId);
        Task UpdateUserAddresses(int userId, List<int> selectedAddressIds);
    }
}
