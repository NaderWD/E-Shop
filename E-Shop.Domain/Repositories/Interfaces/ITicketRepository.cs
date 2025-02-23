using E_Shop.Domain.Models.Ticket;

namespace E_Shop.Domain.Repositories.Interfaces
{
    public interface ITicketRepository
    {
        Task AddTicket(Ticket ticket);
        Task<List<Ticket>> GetAllTickets();
        Task<List<Ticket>> GetDeletedTicketsByUserId(int userId);
        Task<List<Ticket>> GetTicketsByUserId(int userId);         
        Task<Ticket> GetLastTicketByUserId(int userId);
        Task<Ticket> GetTicketById(int ticketId);
        int? GetMessagesCountByTicketId(int ticketId);
        int? GetTicketsCountByUserId(int userId);
        Task UpdateTicket(Ticket ticket);
        Task SoftDeleteTicket(int ticketId);
        Task DeleteTicket(int ticketId);
        Task SaveChanges();
    }
}
