using E_Shop.Application.Services.Interfaces;
using E_Shop.Application.ViewModels.TicketViewModels;
using E_Shop.Domain.Models.TiketModels;
using E_Shop.Domain.Repositories.Interfaces;
using static E_Shop.Domain.Enum.TicketsEnums;

namespace E_Shop.Application.Services.Implementations
{
    public class TicketService(ITicketRepository _repository) : ITicketService
    {

        public async Task CreateTicket(CreateTicketVM ticketVM)
        {
            Ticket ticket = new()
            {
                Id = ticketVM.Id,
                Title = ticketVM.Title,
                Description = ticketVM.Description,
                Section = ticketVM.Section,
                Status = Status.Open,
                Messages = ticketVM.Messages,
                CreateDate = DateTime.Now,

            };
            await _repository.AddTicket(ticket);
            await SaveChanges();
        }

        public async Task CreateMessage(CreateMessageVM messageVM)
        {
            TicketMessage message = new()
            {
                Id = messageVM.Id,
                Text = messageVM.Text,
                FilePath = messageVM.FilePath,
                CreateDate = DateTime.Now,
                TicketId = messageVM.TicketId,
                UserId = messageVM.UserId
            };
            await _repository.AddMessage(message);
            await SaveChanges();
        }

        public async Task<IEnumerable<Ticket>> GetAllTickets()
        {
            return await _repository.GetAllTickets();
        }

        public async Task<TicketMessage> GetMessageById(int messageId)
        {
            return await _repository.GetMessageById(messageId);
        }

        public async Task<IEnumerable<TicketMessage>> GetMessagesByTicketId(int ticketId)
        {
            return await _repository.GetMessagesByTicketId(ticketId);
        }

        public async Task<Ticket> GetTicketById(int ticketId)
        {
            return await _repository.GetTicketById(ticketId);
        }

        public async Task<IEnumerable<Ticket>> GetTicketsByUserId(int userId)
        {
            return await _repository.GetTicketsByUserId(userId);
        }

        public async Task<int> GetMessageCounts(int ticketId)
        {
            return await _repository.GetMessageCounts(ticketId);
        }

        public async Task<int> GetTicketCounts(int userId)
        {
            return await _repository.GetTicketCounts(userId);
        }

        public async Task UpdateTicket(UpdateTicketVM ticketVM)
        {
            Ticket ticket = new()
            {
                Id = ticketVM.Id,
                Title = ticketVM.Title,
                Description = ticketVM.Description,
                Section = ticketVM.Section,
                Status = ticketVM.Status,
                LastModifiedDate = DateTime.Now,
            };
            await _repository.UpdateTicket(ticket);
            await SaveChanges();
        }

        public async Task UpdateMessage(UpdateMessageVM messageVM)
        {
            TicketMessage message = new()
            {
                Id = messageVM.Id,
                Text = messageVM.Text,
                FilePath = messageVM.FilePath,
                LastModifiedDate = DateTime.Now,
            };
            await _repository.UpdateMessage(message);
            await SaveChanges();
        }

        public async Task DeleteMessage(int messageId)
        {
            await _repository.DeleteMessage(messageId);
        }

        public async Task DeleteTicket(int ticketId)
        {
            await _repository.DeleteTicket(ticketId);
        }

        public async Task SaveChanges()
        {
            await _repository.SaveChanges();
        }
    }
}
