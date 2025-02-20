using E_Shop.Domain.Models;
using E_Shop.Domain.Models.TiketModels;

namespace E_Shop.Domain.Repositories.Interfaces
{
    public interface ITicketRepository
    {
        Task AddTicket(Ticket ticket);
        Task<IEnumerable<Ticket>> GetAllTickets();
        Task<IEnumerable<Ticket>> GetDeletedTicketsByUserId(int userId);
        Task<IEnumerable<Ticket>> GetTicketsByUserId(int userId);
        Task<Ticket> GetTicketById(int ticketId);
        int? GetMessagesCountByTicketId(int ticketId);
        int? GetTicketsCountByUserId(int userId);
        Task UpdateTicket(Ticket ticket);
        Task SoftDeleteTicket(int ticketId);
        Task DeleteTicket(int ticketId);
        Task SaveChanges();
    }
}
