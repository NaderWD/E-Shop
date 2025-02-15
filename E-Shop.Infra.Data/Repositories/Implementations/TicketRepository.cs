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

        public async Task AddMessage(TicketMessage message)
        {
            await _context.AddAsync(message);
        }

        public async Task UpdateMessage(TicketMessage message)
        {
            _context.Update(message);
        }

        public async Task<IEnumerable<Ticket>> GetAllTickets()
        {
            return await _context.Tickets.ToListAsync();
        }

        public async Task<TicketMessage> GetMessageById(int messageId)
        {
            return await _context.TicketMessages.FindAsync(messageId);
        }

        public async Task<IEnumerable<TicketMessage>> GetMessagesByTicketId(int ticketId)
        {
            return await _context.TicketMessages.Where(m => m.TicketId == ticketId).ToListAsync();
        }

        public async Task<Ticket> GetTicketById(int ticketId)
        {
            return await _context.Tickets.FindAsync(ticketId);
        }

        public async Task<IEnumerable<Ticket>> GetTicketsByUserId(int userId)
        {
            return await _context.Tickets.Where(t => t.UserId == userId).ToListAsync();
        }

        public async Task<int> GetMessageCounts(int ticketId)
        {
            return await _context.TicketMessages.CountAsync(x => x.TicketId == ticketId);
        }

        public async Task<int> GetTicketCounts(int userId)
        {
            return await _context.Tickets.CountAsync(x => x.UserId == userId);
        }

        public async Task UpdateTicket(Ticket ticket)
        {
            _context.Update(ticket);
        }

        public async Task DeleteMessage(int messageId)
        {
            var message = await GetMessageById(messageId);
            _context.TicketMessages.Remove(message);
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
