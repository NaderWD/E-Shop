using E_Shop.Application.ViewModels.TicketViewModels;
using Microsoft.AspNetCore.Http;

namespace E_Shop.Application.Services.Interfaces
{
    public interface ITicketMessageService
    {
        Task AddMessageToTicket(MessageVM messageVM, IFormFile? attachment, int userId);
        Task<IEnumerable<MessageVM>> GetMessagesByTicketId(int ticketId);
        Task<IEnumerable<MessageVM>> GetDeletedMessagesByTicketId(int ticketId);
        Task SoftDeleteMessage(int messageId);
        Task DeleteMessage(int messageId);
        string SaveFile(IFormFile? attachment);
        Task SaveChanges();
    }
}
