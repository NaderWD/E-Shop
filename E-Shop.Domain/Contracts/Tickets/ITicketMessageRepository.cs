using E_Shop.Domain.Models.Ticket;

namespace E_Shop.Domain.Contracts.Tickets
{
    public interface ITicketMessageRepository
    {
        Task AddMessage(TicketMessage message);
        Task<List<TicketMessage>> GetMessagesByTicketId(int ticketId);
        Task<List<TicketMessage>> GetMessagesByUserId(int ticketId);
        Task<List<TicketMessage>> GetDeletedMessagesByTicketId(int ticketId);      
        Task<List<TicketMessage>> GetDeletedMessagesByUserId(int ticketId);
        Task UpdateMessage(TicketMessage message);
        Task SoftDeleteMessage(int messageId);
        Task DeleteMessage(int messageId);
        Task SaveChanges();
    }
}
