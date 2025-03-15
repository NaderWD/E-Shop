using E_Shop.Application.ViewModels.AddressViewModels;
using E_Shop.Domain.Contracts.AddressCont;
using E_Shop.Domain.Models.AddressModels;

namespace E_Shop.Application.Services.AddressServices
{
    public class CityServices(ICityRepository _cityRepository, IUserAddressRepository _userAddressRepository, IStateRepository _stateRepository) : ICityServices
    {
        public async Task CreateCity(CityVM cityVM)
        {
            City newCity = new()
            {
                CityName = cityVM.CityName,
                StateId = cityVM.StateId,
                CreateDate = DateTime.Now,
                LastModifiedDate = DateTime.Now,
            };
            await _cityRepository.CreateCity(newCity);
            await _userAddressRepository.Save();
        }

        public async Task<List<CityVM>> GetAllCities()
        {
            var cities = await _cityRepository.GetAllCities();
            return [.. cities.Select(c => new CityVM
            {
                CityId = c.Id,
                CityName = c.CityName,
                StateId = c.StateId,
                CreateDate = c.CreateDate,
                LastModifiedDate = c.LastModifiedDate,
            })];
        }

        public async Task<CityVM> GetCityById(int cityId)
        {
            var city = await _cityRepository.GetCityById(cityId);
            return new CityVM
            {
                CityId = city.Id,
                CityName = city.CityName,
                StateId = city.StateId,
                CreateDate = city.CreateDate,
                LastModifiedDate = city.LastModifiedDate
            };
        }

        public async Task<List<CityVM>> GetCityListByStateId(int stateId)
        {
            var citiesForState = await _cityRepository.GetCityListByStateId(stateId);
            return [.. citiesForState.Select(c => new CityVM
            {
                CityId = c.Id,
                StateId = c.StateId,
                CityName = c.CityName
            })];
        }

        //public async Task<List<CityVM>> GetSortedCityListForViewBag()
        //{
        //    var states = await _stateRepository.GetAllStates();
        //    foreach (var state in states)
        //    {
        //        await _cityRepository.GetCityListByStateId(state.Id);
        //    }

        //}

        public async Task UpdateCity(CityVM cityVM)
        {
            var city = await _cityRepository.GetCityById(cityVM.CityId);
            city.CityName = cityVM.CityName;
            city.StateId = cityVM.StateId;
            city.LastModifiedDate = DateTime.Now;
            await _cityRepository.UpdateCity(city);
            await _userAddressRepository.Save();
        }

        public async Task SoftDeleteCity(int cityId)
        {
            var city = await _cityRepository.GetCityById(cityId);
            city.IsDelete = true;
            await _cityRepository.UpdateCity(city);
            await _userAddressRepository.Save();
        }
    }
}
