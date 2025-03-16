using E_Shop.Application.ViewModels.AddressViewModels;

namespace E_Shop.Application.Services.AddressServices
{
    public interface IAddressServices
    {
        Task CreateAddress(CreateAddressVM addressVM, int userId);
        Task<AddressVM> GetAddressById(int addressId);
        Task<StateVM> GetStateByAddressId(int addressId);
        Task<CityVM> GetCityByAddressId(int addressId);
        Task<List<AddressForShowVM>> ShowAddressListByUserId(int userId);
        Task UpdateAddress(AddressVM addressVM);
        Task SoftDeleteAddress(int addressId);
    }
}
