using E_Shop.Domain.Contracts.AddressCont;
using E_Shop.Domain.Models.AddressModels;
using Microsoft.EntityFrameworkCore;

namespace E_Shop.Infra.Data.Repositories.AddressRepo
{
    public class StateRepository(ShopDbContext _context) : IStateRepository
    {
        public async Task CreateState(State state)
            => await _context.States.AddAsync(state);

        public async Task<List<State>> GetAllStates()
            => await _context.States.Include(x => x.Cities)
                                                   .Where(x => !x.IsDelete)
                                                   .ToListAsync();

        public async Task<State> GetStateById(int stateId)
            => await _context.States.Include(x => x.Cities)
                                                   .FirstOrDefaultAsync(x => x.Id == stateId && !x.IsDelete);

        public async Task<List<City>> GetCitiesByStateId(int stateId)
             => await _context.Cities.Include(x => x.State)
                                                  .Where(x => x.State.Id == stateId)
                                                  .ToListAsync();

        public async Task UpdateState(State state)
             => _context.States.Update(state);

        public async Task DeleteState(int stateId)
            => _context.States.Remove(await GetStateById(stateId));
    }
}
