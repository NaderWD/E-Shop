using E_Shop.Domain.Contracts.AddressCont;
using E_Shop.Domain.Models.AddressModels;
using Microsoft.EntityFrameworkCore;

namespace E_Shop.Infra.Data.Repositories.AddressRepo
{
    public class CityRepository(ShopDbContext _context) : ICityRepository
    {
        public async Task CreateCity(City city)
            => await _context.Cities.AddAsync(city);

        public async Task<List<City>> GetAllCities()
            => await _context.Cities.Include(x => x.Address)
                                                 .Include(x => x.State)
                                                 .Where(x => !x.IsDelete)
                                                 .ToListAsync();

        public async Task<City> GetCityById(int cityId)
            => await _context.Cities.Include(x => x.Address)
                                                 .Include(x => x.State)
                                                 .FirstOrDefaultAsync(x => x.Id == cityId && !x.IsDelete);

        public async Task<List<City>> GetCityListByStateId(int stateId)
            => await _context.Cities.Include(x => x.Address)
                                                 .Include(x => x.State)
                                                 .Where(x => x.StateId == stateId && !x.IsDelete).ToListAsync();

        public async Task UpdateCity(City city)
                    => _context.Cities.Update(city);

        public async Task DeleteCity(int cityId)
            => _context.Cities.Remove(await GetCityById(cityId));
    }
}
