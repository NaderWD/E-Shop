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
            return await _context.TicketMessages.FirstOrDefaultAsync(m => m.TicketId == ticketId && m.IsDelete == false);
        }

        public async Task<IEnumerable<TicketMessage>> GetMessagesByTicketId(int ticketId)
        {
            return await _context.TicketMessages.Where(m => m.TicketId == ticketId && m.IsDelete == false).ToListAsync();
        }

        public async Task<IEnumerable<TicketMessage>> GetDeletedMessagesByTicketId(int ticketId)
        {
            return await _context.TicketMessages.Where(m => m.TicketId == ticketId && m.IsDelete == true).ToListAsync();
        }

        public async Task<TicketMessage> GetMessageById(int messageId)
        {
            return await _context.TicketMessages.FirstOrDefaultAsync(m => m.Id == messageId && m.IsDelete == false);
        }

        public async Task<int> GetMessageCounts(int ticketId)
        {
            return await _context.TicketMessages.CountAsync(x => x.TicketId == ticketId && x.IsDelete == false);
        }

        public async Task UpdateMessage(TicketMessage message)
        {
            _context.Update(message);
        }

        public async Task SoftDeleteMessage(int messageId)
        {
            var message = await GetMessageById(messageId);
            message.IsDelete = true;
            _context.TicketMessages.Update(message);
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
