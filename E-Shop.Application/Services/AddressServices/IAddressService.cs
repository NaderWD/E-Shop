using E_Shop.Application.ViewModels.AddressViewModels;

namespace E_Shop.Application.Services.AddressServices
{
    public interface IAddressService
    {
        Task CreateAddress(AddressVM addressVM);
        Task<List<AddressVM>> GetUserAddresses(int userId);
    }
}
