using E_Shop.Application.ViewModels.TicketViewModels;
using Microsoft.AspNetCore.Http;

namespace E_Shop.Application.Services.Interfaces
{
    public interface ITicketMessageService
    {
        Task AddMessageToTicket(MessageVM messageVM, IFormFile? attachment, int userId);
        Task<List<MessageVM>> GetMessagesByTicketId(int ticketId);
        Task<List<MessageVM>> GetDeletedMessagesByTicketId(int ticketId);
        Task SoftDeleteMessage(int messageId);
        Task DeleteMessage(int messageId);
        string SaveFile(IFormFile? attachment);
        Task SaveChanges();
    }
}
