using E_Shop.Application.ViewModels.AddressViewModels;
using E_Shop.Domain.Contracts.AddressCont;
using E_Shop.Domain.Models.AddressModels;

namespace E_Shop.Application.Services.AddressServices
{
    public class AddressServices(IAddressRepository _addressRepository,
                                                   IUserAddressRepository _userAddressRepository,
                                                   IStateServices _stateServices,
                                                   ICityServices _cityServices) : IAddressServices
    {
        public async Task CreateAddress(AddressVM addressVM)
        {
            Address newAddress = new()
            {
                FullAddress = addressVM.FullAddress,
                CityId = (await _cityServices.GetCityById(addressVM.CityId)).CityId,
                StateId = (await _stateServices.GetStateById(addressVM.StateId)).StateId,
            };
            await _addressRepository.CreateAddress(newAddress);
            await _userAddressRepository.Save();
        }

        public async Task<AddressVM> GetAddressById(int addressId)
        {
            var address = await _addressRepository.GetAddressById(addressId);
            return new AddressVM
            {
                AddressId = address.Id,
                FullAddress = address.FullAddress,
                CityId = address.CityId,
                StateId = address.StateId,
                CreateDate = address.CreateDate,
                LastModifiedDate = address.LastModifiedDate,
            };
        }

        public async Task<StateVM> GetStateByAddressId(int addressId)
        {
            var state = (await _addressRepository.GetAddressById(addressId)).City.State;
            return new StateVM
            {
                StateId = state.Id,
                StateName = state.StateName
            };
        }

        public async Task<CityVM> GetCityByAddressId(int addressId)
        {
            var city = (await _addressRepository.GetAddressById(addressId)).City;
            return new CityVM
            {
                CityId = city.Id,
                CityName = city.CityName
            };
        }

        public async Task<List<AddressVM>> GetUsersAddressesByUserId(int userId)
        {
            var addresses = (await _userAddressRepository.GetAddressListByUserId(userId));
            return [.. addresses.Select(a => new AddressVM
            {
                AddressId = a.Id,
                CityId = a.CityId,
                StateId = a.StateId,
                FullAddress = a.FullAddress,
                CreateDate = a.CreateDate,
                LastModifiedDate = a.LastModifiedDate
            })];
        }

        public async Task UpdateAddress(AddressVM addressVM)
        {
            var address = await _addressRepository.GetAddressById(addressVM.AddressId);
            address.FullAddress = addressVM.FullAddress;
            address.CityId = addressVM.CityId;
            address.StateId = addressVM.StateId;
            address.LastModifiedDate = DateTime.Now;
            await _addressRepository.UpdateAddress(address);
            await _userAddressRepository.Save();
        }

        public async Task SoftDeleteAddress(int addressId)
        {
            var address = await _addressRepository.GetAddressById(addressId);
            address.IsDelete = true;
            await _addressRepository.UpdateAddress(address);
            await _userAddressRepository.Save();
        }
    }
}
