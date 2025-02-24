using E_Shop.Application.ViewModels.TicketViewModels;
using Microsoft.AspNetCore.Http;
using static E_Shop.Domain.Enum.TicketsEnums;

namespace E_Shop.Application.Services.TicketServices
{
    public interface ITicketService
    {
        Task CreateTicket(TicketVM ticketVM, IFormFile? attachment, int userId);
        Task<List<TicketVM>> GetAllTickets();
        Task<List<TicketVM>> GetDeletedTicketsByUserId(int userId);
        Task<List<TicketVM>> GetTicketsByUserId(int userId);
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
