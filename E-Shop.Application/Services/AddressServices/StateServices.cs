using E_Shop.Application.ViewModels.AddressViewModels;
using E_Shop.Domain.Contracts.AddressCont;
using E_Shop.Domain.Models.AddressModels;

namespace E_Shop.Application.Services.AddressServices
{
    public class StateServices(IStateRepository _stateRepository, IUserAddressRepository _userAddressRepository) : IStateServices
    {
        public async Task CreateState(string stateName)
        {
            State state = new()
            {
                StateName = stateName,
                CreateDate = DateTime.Now,
                LastModifiedDate = DateTime.Now,
            };
            await _stateRepository.CreateState(state);
            await _userAddressRepository.Save();
        }

        public async Task<List<StateVM>> GetAllStates()
        {
            var allStates = await _stateRepository.GetAllStates();
            return [.. allStates.Select(s => new StateVM { StateId = s.Id, StateName = s.StateName })];
        }

        public async Task<StateVM> GetStateById(int stateId)
        {
            var state = await _stateRepository.GetStateById(stateId);
            return new StateVM
            {
                StateId = state.Id,
                StateName = state.StateName
            };
        }

        public async Task<List<CityVM>> GetAllCitiesOfState(int stateId)
        {
            var allStatesCities = await _stateRepository.GetCitiesByStateId(stateId);
            return [.. allStatesCities.Select(c => new CityVM
            {
                CityId = c.Id,
                CityName = c.CityName,
                LastModifiedDate = c.LastModifiedDate,
            })];
        }

        public async Task UpdateState(StateVM stateVM)
        {
            var state = await _stateRepository.GetStateById(stateVM.StateId);
            state.StateName = stateVM.StateName;
            state.LastModifiedDate = DateTime.Now;
            await _stateRepository.UpdateState(state);
            await _userAddressRepository.Save();
        }

        public async Task SoftDeleteState(int stateId)
        {
            var state = await _stateRepository.GetStateById(stateId);
            state.IsDelete = true;
            await _stateRepository.UpdateState(state);
            await _userAddressRepository.Save();
        }
    }
}
