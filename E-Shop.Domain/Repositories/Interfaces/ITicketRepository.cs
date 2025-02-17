using E_Shop.Domain.Models.TiketModels;

namespace E_Shop.Domain.Repositories.Interfaces
{
    public interface ITicketRepository
    {
        Task AddTicket(Ticket ticket);
        Task<IEnumerable<Ticket>> GetAllTickets();
        Task<IEnumerable<Ticket>> GetTicketsByUserId(int userId);
        Task<Ticket> GetTicketById(int ticketId);
        Task<int> GetTicketCounts(int userId);
        Task UpdateTicket(Ticket ticket);
        Task DeleteTicket(int ticketId);
        Task SaveChanges();
    }
}
