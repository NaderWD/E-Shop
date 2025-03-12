using E_Shop.Domain.Contracts.AddressCont;

namespace E_Shop.Application.Services.AddressServices
{
    public class AddressService(IStateRepository _stateRepository, 
                                                 ICityRepository _cityRepository, 
                                                 IAddressRepository _addressRepository, 
                                                 IUserAddressRepository _userAddressRepository) : IAddressService
    {

    }
}
