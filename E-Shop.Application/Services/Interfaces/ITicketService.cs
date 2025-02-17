using E_Shop.Application.ViewModels.TicketViewModels;
using E_Shop.Domain.Models.TiketModels;

namespace E_Shop.Application.Services.Interfaces
{
    public interface ITicketService
    {
        Task CreateTicket(TicketVM ticketVM);
        Task CreateMessage(MessageVM messageVM);
        Task<IEnumerable<TicketVM>> GetAllTickets();
        Task<IEnumerable<TicketVM>> GetTicketsByUserId(int userId);
        Task<TicketVM> GetTicketById(int ticketId);
        Task<IEnumerable<MessageVM>> GetMessagesByTicketId(int ticketId);
        Task<MessageVM> GetMessageById(int messageId);
        Task<int> GetMessageCounts(int ticketId);
        Task<int> GetTicketCounts(int userId);
        Task UpdateTicket(TicketVM ticketVM);
        Task UpdateMessage(MessageVM messageVM);
        Task DeleteTicket(int ticketId);
        Task DeleteMessage(int messageId);
        Task SaveChanges();
    }
}
