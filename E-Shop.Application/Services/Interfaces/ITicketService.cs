using E_Shop.Application.ViewModels.TicketViewModels;
using E_Shop.Domain.Models.TiketModels;

namespace E_Shop.Application.Services.Interfaces
{
    public interface ITicketService
    {
        Task CreateTicket(CreateTicketVM ticketVM);
        Task CreateMessage(CreateMessageVM messageVM);
        Task<IEnumerable<Ticket>> GetAllTickets();
        Task<IEnumerable<Ticket>> GetTicketsByUserId(int userId);
        Task<Ticket> GetTicketById(int ticketId);
        Task<IEnumerable<TicketMessage>> GetMessagesByTicketId(int ticketId);
        Task<TicketMessage> GetMessageById(int messageId);
        Task<int> GetMessageCounts(int ticketId);
        Task<int> GetTicketCounts(int userId);
        Task UpdateTicket(UpdateTicketVM ticketVM);
        Task UpdateMessage(UpdateMessageVM messageVM);
        Task DeleteTicket(int ticketId);
        Task DeleteMessage(int messageId);
        Task SaveChanges();
    }
}
