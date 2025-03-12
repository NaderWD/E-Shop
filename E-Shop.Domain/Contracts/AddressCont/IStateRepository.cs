using E_Shop.Domain.Models.AddressModels;

namespace E_Shop.Domain.Contracts.AddressCont
{
    public interface IStateRepository
    {
        Task CreateState(State state);
        Task<List<State>> GetAllStates();
        Task<State> GetStateById(int stateId);
        Task UpdateState(State state);
        Task DeleteState(int stateId);
    }
}
