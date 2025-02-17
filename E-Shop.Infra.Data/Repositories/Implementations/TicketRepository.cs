using E_Shop.Domain.Models.TiketModels;
using E_Shop.Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace E_Shop.Infra.Data.Repositories.Implementations
{
    public class TicketRepository(ShopDbContext _context) : ITicketRepository
    {
        public async Task AddTicket(Ticket ticket)
        {
            await _context.AddAsync(ticket);
        }

        public async Task<IEnumerable<Ticket>> GetAllTickets()
        {
            return await _context.Tickets.ToListAsync();
        }

        public async Task<IEnumerable<Ticket>> GetTicketsByUserId(int userId)
        {
            return await _context.Tickets.Where(t => t.UserId == userId).ToListAsync();
        }

        public async Task<Ticket> GetTicketById(int ticketId)
        {
            return await _context.Tickets.FindAsync(ticketId);
        }

        public async Task<int> GetTicketCounts(int userId)
        {
            return await _context.Tickets.CountAsync(x => x.UserId == userId);
        }

        public async Task UpdateTicket(Ticket ticket)
        {
            _context.Update(ticket);
        }

        public async Task DeleteTicket(int ticketId)
        {
            var ticket = await GetTicketById(ticketId);
            _context.Tickets.Remove(ticket);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
