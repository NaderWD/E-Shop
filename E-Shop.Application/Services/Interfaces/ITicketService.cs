using E_Shop.Application.ViewModels.TicketViewModels;
using E_Shop.Domain.Models.TiketModels;
using Microsoft.AspNetCore.Http;
using static E_Shop.Domain.Enum.TicketsEnums;

namespace E_Shop.Application.Services.Interfaces
{
    public interface ITicketService
    {
        Task CreateTicket(TicketVM ticketVM, IFormFile? attachment, int userId);
        Task<IEnumerable<Ticket>> GetAllTickets();
        Task<IEnumerable<TicketVM>> GetDeletedTicketsByUserId(int userId);
        Task<IEnumerable<TicketVM>> GetTicketsByUserId(int userId);
        Task<TicketVM> GetTicketById(int ticketId);
        Task<int> GetUserIdByTicketId(int ticketId);
        int? GetTicketCounts(int userId);
        int? GetMessageCounts(int ticketId);
        Task UpdateTicket(TicketVM ticketVM);
        Task UpdateTicketStatus(int ticketId, Status status);
        Task SoftDeleteTicket(int ticketId);
        Task DeleteTicket(int ticketId);
        string SaveFile(IFormFile? attachment);
        Task SaveChanges();
    }
}
