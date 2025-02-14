using E_Shop.Domain.Models.TiketModels;

namespace E_Shop.Domain.Repositories.Interfaces
{
    public interface ITicketRepository
    {
        Task AddTicket(Ticket ticket);
        Task AddMessage(TicketMessage message);
        Task<IEnumerable<Ticket>> GetAllTickets();
        Task<IEnumerable<Ticket>> GetTicketsByUserId(int userId);
        Task<Ticket> GetTicketById(int ticketId);
        Task<IEnumerable<TicketMessage>> GetMessagesByTicketId(int ticketId);
        Task<TicketMessage> GetMessageById(int messageId);
        Task UpdateTicket(Ticket ticket);
        Task UpdateMessage(TicketMessage message);
        Task DeleteTicket(int ticketId);
        Task DeleteMessage(int messageId);
    }
}
