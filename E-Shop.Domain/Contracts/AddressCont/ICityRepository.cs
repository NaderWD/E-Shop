using E_Shop.Domain.Models.AddressModels;

namespace E_Shop.Domain.Contracts.AddressCont
{
    public interface ICityRepository
    {
        Task CreateCity(City city);
        Task<List<City>> GetAllCities();
        Task<City> GetCityById(int cityId);
        Task<List<City>> GetCityListByStateId(int stateId);
        Task UpdateCity(City city);
        Task DeleteCity(int cityId);
    }
}
