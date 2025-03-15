using E_Shop.Application.ViewModels.AddressViewModels;
using E_Shop.Domain.Contracts.AddressCont;
using E_Shop.Domain.Models.AddressModels;

namespace E_Shop.Application.Services.AddressServices
{
    public class UserAddressServices(IUserAddressRepository _userAddressRepository) : IUserAddressServices
    {
        public async Task CreateUserAddress(int userId, int addressId)
        {
            await _userAddressRepository.CreateUserAddress(new UserAddress
            {
                UserId = userId,
                AddressId = addressId,
                CreateDate = DateTime.Now,
                LastModifiedDate = DateTime.Now
            });
        }

        public async Task UpdateUserAddresses(int userId, List<int> selectedAddressIds)
        {
            var userAddresses = await _userAddressRepository.GetUserAddressListByUserId(userId);
            foreach (var userAddress in userAddresses)
                if (selectedAddressIds.Any(id => id == userAddress.AddressId)) await _userAddressRepository.DeleteUserAddress(userAddress.Id);
            foreach (var addressId in selectedAddressIds)
            {
                await CreateUserAddress(userId, addressId);
                await _userAddressRepository.Save();
            }
            await _userAddressRepository.Save();
        }
    }
}
