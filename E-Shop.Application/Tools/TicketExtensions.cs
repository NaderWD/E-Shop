using E_Shop.Application.ViewModels.TicketViewModels;
using E_Shop.Domain.Models.Ticket;

namespace E_Shop.Application.Tools
{
    public static class TicketExtensions
    {
        public static TicketVM ConvertToVM(this Ticket ticket) => new()
        {
            Id = ticket.Id,
            Title = ticket.Title,
            CreateDate = ticket.CreateDate,
            LastModifiedDate = ticket.LastModifiedDate,
            Status = ticket.Status,
            Priority = ticket.Priority,
            OwnerId = ticket.OwnerId,
            SenderId = ticket.SenderId,
            NumberOfMessages = ticket.Messages?.Count() ?? 0
        };
    }
}
