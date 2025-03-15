using E_Shop.Application.ViewModels.AddressViewModels;

namespace E_Shop.Application.Services.AddressServices
{
    public interface IStateServices
    {
        Task CreateState(string stateName);
        Task<List<StateVM>> GetAllStates();
        Task<StateVM> GetStateById(int stateId);
        Task<List<CityVM>> GetAllCitiesOfState(int stateId);
        Task UpdateState(StateVM stateVM);
        Task SoftDeleteState(int stateId);
    }
}
