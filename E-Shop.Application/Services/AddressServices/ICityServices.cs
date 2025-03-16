using E_Shop.Application.ViewModels.AddressViewModels;

namespace E_Shop.Application.Services.AddressServices
{
    public interface ICityServices
    {
        Task CreateCity(string cityName, int stateId);
        Task<List<CityVM>> GetAllCities();
        Task<CityVM> GetCityById(int cityId);
        Task<List<CityVM>> GetCityListByStateId(int stateId);
        Task UpdateCity(CityVM cityVM);
        Task SoftDeleteCity(int cityId);
    }
}
