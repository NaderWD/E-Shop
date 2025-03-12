using E_Shop.Application.ViewModels.AddressViewModels;
using E_Shop.Domain.Contracts.AddressCont;

namespace E_Shop.Application.Services.AddressServices
{
    public class AddressService(IStateRepository _stateRepository,
                                                 ICityRepository _cityRepository,
                                                 IAddressRepository _addressRepository,
                                                 IUserAddressRepository _userAddressRepository) : IAddressService
    {
        public Task CreateAddress(AddressVM addressVM)
        {
            throw new NotImplementedException();
        }

        public Task<List<AddressVM>> GetUserAddresses(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
