using E_Shop.Domain.Contracts.TicketCont;
using E_Shop.Domain.Models.TicketModels;
using Microsoft.EntityFrameworkCore;

namespace E_Shop.Infra.Data.Repositories.TicketRepo
{
    public class TicketMessageRepository(ShopDbContext _context) : ITicketMessageRepository
    {
        public async Task AddMessage(TicketMessage message)
        {
            await _context.AddAsync(message);
        }

        public async Task<List<TicketMessage>> GetMessagesByTicketId(int ticketId)
        {
            return await _context.TicketMessages.Where(m => m.TicketId == ticketId && m.IsDelete == false).ToListAsync();
        }

        public async Task<List<TicketMessage>> GetMessagesByUserId(int userId)
        {
            return await _context.TicketMessages.Where(m => m.SenderId == userId && m.IsDelete == false).ToListAsync();
        }

        public async Task<List<TicketMessage>> GetDeletedMessagesByTicketId(int ticketId)
        {
            return await _context.TicketMessages.Where(m => m.TicketId == ticketId && m.IsDelete == true).ToListAsync();
        }

        public async Task<List<TicketMessage>> GetDeletedMessagesByUserId(int userId)
        {
            return await _context.TicketMessages.Where(m => m.SenderId == userId && m.IsDelete == true).ToListAsync();
        }

        public async Task<TicketMessage> GetMessageById(int messageId)
        {
            return await _context.TicketMessages.FirstOrDefaultAsync(m => m.Id == messageId && m.IsDelete == false);
        }

        public async Task UpdateMessage(TicketMessage message)
        {
            _context.Update(message);
        }

        public async Task SoftDeleteMessage(int messageId)
        {
            var message = await GetMessageById(messageId) ?? throw new NullReferenceException("پیام یافت نشد");
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
