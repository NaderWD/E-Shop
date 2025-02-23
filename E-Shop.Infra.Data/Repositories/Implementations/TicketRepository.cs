using E_Shop.Domain.Contracts.Tickets;
using E_Shop.Domain.Models.Ticket;
using Microsoft.EntityFrameworkCore;
using static E_Shop.Domain.Enum.TicketsEnums;

namespace E_Shop.Infra.Data.Repositories.Implementations
{
    public class TicketRepository(ShopDbContext _context) : ITicketRepository
    {
        public async Task AddTicket(Ticket ticket)
        {
            await _context.AddAsync(ticket);
        }

        public async Task<List<Ticket>> GetAllTickets()
        {
            return await _context.Tickets.Where(t => t.IsDelete == false)
                                         .Include(m => m.User)
                                         .Include(n => n.Messages)
                                         .ToListAsync();
        }

        public async Task<List<Ticket>> GetDeletedTicketsByUserId(int userId)
        {
            return await _context.Tickets.Where(t => t.OwnerId == userId && t.IsDelete == true)
                                         .ToListAsync();
        }

        public async Task<List<Ticket>> GetTicketsByUserId(int userId)
        {
            return await _context.Tickets.Where(t => t.OwnerId == userId
                                                  && t.IsDelete == false)
                                    .Include(t => t.Messages)
                                    .OrderByDescending(t => t.LastModifiedDate)
                                    .ToListAsync();
        }

        public async Task<Ticket> GetLastTicketByUserId(int userId)
        {

            return await _context.Tickets.Where(t => t.OwnerId == userId &&
                                                    !t.IsDelete &&
                                                     t.Status != Status.Closed)
                                         .FirstOrDefaultAsync();
        }

        public async Task<Ticket> GetTicketById(int ticketId)
        {
            return await _context.Tickets.FirstOrDefaultAsync(t => t.Id == ticketId && t.IsDelete == false);
        }

        public int? GetMessagesCountByTicketId(int ticketId)
        {
            return _context.TicketMessages.Count(m => m.TicketId == ticketId);
        }

        public int? GetTicketsCountByUserId(int userId)
        {
            return _context.Tickets.Count(t => t.OwnerId == userId);
        }

        public async Task UpdateTicket(Ticket ticket)
        {
            _context.Update(ticket);
        }

        public async Task SoftDeleteTicket(int ticketId)
        {
            var ticket = await GetTicketById(ticketId) ?? throw new NullReferenceException("تیکت یافت نشد");
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
