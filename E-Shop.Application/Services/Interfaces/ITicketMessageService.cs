using E_Shop.Application.ViewModels.TicketViewModels;

namespace E_Shop.Application.Services.Interfaces
{
    public interface ITicketMessageService
    {
        Task CreateMessage(MessageVM messageVM);
        Task<IEnumerable<MessageVM>> GetMessagesByTicketId(int ticketId);
        Task<IEnumerable<MessageVM>> GetDeletedMessagesByTicketId(int ticketId);
        Task<MessageVM> GetMessageById(int messageId);     
        Task<int> GetMessageCounts(int ticketId);
        Task UpdateMessage(MessageVM messageVM);
        Task SoftDeleteMessage(int messageId);
        Task DeleteMessage(int messageId);
        Task SaveChanges();
    }
}
