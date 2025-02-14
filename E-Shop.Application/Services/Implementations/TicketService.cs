using E_Shop.Application.Services.Interfaces;
using E_Shop.Application.ViewModels.TicketViewModels;
using E_Shop.Domain.Models.TiketModels;
using E_Shop.Domain.Repositories.Interfaces;

namespace E_Shop.Application.Services.Implementations
{
    public class TicketService(ITicketRepository _repository) : ITicketService
    {

        public async Task CreateTicket(CreateTicketVM ticketVM)
        {
            throw new NotImplementedException();
        }

        public async Task CreateMessage(CreateMessageVM messageVM)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Ticket>> GetAllTickets()
        {
            return await _repository.GetAllTickets();
        }

        public async Task<TicketMessage> GetMessageById(int messageId)
        {
            return await _repository.GetMessageById(messageId);
        }

        public async Task<IEnumerable<TicketMessage>> GetMessagesByTicketId(int ticketId)
        {
            return await _repository.GetMessagesByTicketId(ticketId);
        }

        public async Task<Ticket> GetTicketById(int ticketId)
        {
            return await _repository.GetTicketById(ticketId);
        }

        public async Task<IEnumerable<Ticket>> GetTicketsByUserId(int userId)
        {
            return await _repository.GetTicketsByUserId(userId);
        }

        public async Task<int> GetMessageCounts(int ticketId)
        {
            return await _repository.GetMessageCounts(ticketId);
        }

        public async Task<int> GetTicketCounts(int userId)
        {
            return await _repository.GetTicketCounts(userId);
        }

        public Task UpdateTicket(UpdateTicketVM ticketVM)
        {
            throw new NotImplementedException();
        }

        public Task UpdateMessage(UpdateMessageVM messageVM)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteMessage(int messageId)
        {
            await _repository.DeleteMessage(messageId);
        }

        public async Task DeleteTicket(int ticketId)
        {
            await _repository.DeleteTicket(ticketId);
        }

        public async Task SaveChanges()
        {
            await _repository.SaveChanges();
        }
    }
}
