using E_Shop.Domain.Models.TiketModels;
using E_Shop.Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace E_Shop.Infra.Data.Repositories.Implementations
{
    public class TicketMessageRepository(ShopDbContext _context) : ITicketMessageRepository
    {
        public async Task AddMessage(TicketMessage message)
        {
            await _context.AddAsync(message);
        }

        public async Task<TicketMessage> GetMessageByTicketId(int ticketId)
        {
            return await _context.TicketMessages.FirstOrDefaultAsync(m => m.TicketId == ticketId);
        }

        public async Task<IEnumerable<TicketMessage>> GetMessagesByTicketId(int ticketId)
        {
            return await _context.TicketMessages.Where(m => m.TicketId == ticketId).ToListAsync();
        }

        public async Task<TicketMessage> GetMessageById(int messageId)
        {
            return await _context.TicketMessages.FindAsync(messageId);
        }

        public async Task<int> GetMessageCounts(int ticketId)
        {
            return await _context.TicketMessages.CountAsync(x => x.TicketId == ticketId);
        }

        public async Task UpdateMessage(TicketMessage message)
        {
            _context.Update(message);
        }

        public async Task DeleteMessage(int messageId)
        {
            var message = await GetMessageById(messageId);
            _context.TicketMessages.Remove(message);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
