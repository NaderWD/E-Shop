using E_Shop.Domain.Models.TiketModels;

namespace E_Shop.Domain.Repositories.Interfaces
{
    public interface ITicketMessageRepository
    {
        Task AddMessage(TicketMessage message);
        Task<TicketMessage> GetMessageByTicketId(int ticketId);
        Task<IEnumerable<TicketMessage>> GetMessagesByTicketId(int ticketId);
        Task<IEnumerable<TicketMessage>> GetDeletedMessagesByTicketId(int ticketId);
        Task<TicketMessage> GetMessageById(int messageId);
        Task<int> GetMessageCounts(int ticketId);
        Task UpdateMessage(TicketMessage message);
        Task SoftDeleteMessage(int messageId);
        Task DeleteMessage(int messageId);
        Task SaveChanges();
    }
}
