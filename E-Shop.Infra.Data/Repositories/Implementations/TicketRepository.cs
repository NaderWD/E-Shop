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
            return await _context.Tickets.Where(t => t.IsDelete == false).ToListAsync();
        }

        public async Task<IEnumerable<Ticket>> GetDeletedTicketsByUserId(int userId)
        {
            return await _context.Tickets.Where(t => t.UserId == userId && t.IsDelete == true).ToListAsync();
        }

        public async Task<IEnumerable<Ticket>> GetTicketsByUserId(int userId)
        {
            return await _context.Tickets.Where(t => t.UserId == userId && t.IsDelete == false).ToListAsync();
        }

        public async Task<Ticket> GetTicketById(int ticketId)
        {
            return await _context.Tickets.FirstOrDefaultAsync(t => t.Id == ticketId && t.IsDelete == false);
        }

        public async Task<int> GetTicketCounts(int userId)
        {
            return await _context.Tickets.CountAsync(x => x.UserId == userId && x.IsDelete == false);
        }

        public async Task UpdateTicket(Ticket ticket)
        {
            _context.Update(ticket);
        }

        public async Task SoftDeleteTicket(int ticketId)
        {
            var ticket = await GetTicketById(ticketId) ?? throw new NullReferenceException("Ticket not found.");
            ticket.IsDelete = true;
            _context.Tickets.Update(ticket);
        }

        public async Task DeleteTicket(int ticketId)
        {
            var ticket = await GetTicketById(ticketId) ?? throw new NullReferenceException("Ticket not found.");
            _context.Tickets.Remove(ticket);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
