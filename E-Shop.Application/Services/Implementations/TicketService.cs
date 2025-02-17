using E_Shop.Application.Services.Interfaces;
using E_Shop.Application.ViewModels.TicketViewModels;
using E_Shop.Domain.Models.TiketModels;
using E_Shop.Domain.Repositories.Interfaces;
using static E_Shop.Domain.Enum.TicketsEnums;

namespace E_Shop.Application.Services.Implementations
{
    public class TicketService(ITicketRepository _repository) : ITicketService
    {

        public async Task CreateTicket(TicketVM ticketVM)
        {
            Ticket ticket = new()
            {
                Title = ticketVM.Title,
                Description = ticketVM.Description,
                Section = ticketVM.Section,
                Status = Status.Open,
                Messages = ticketVM.Messages,
                CreateDate = DateTime.Now,
                Priority = ticketVM.Priority,
                FilePath = ticketVM.FilePath,
            };
            await _repository.AddTicket(ticket);
            await SaveChanges();
        }

        public async Task CreateMessage(MessageVM messageVM)
        {
            TicketMessage message = new()
            {
                Text = messageVM.Text,
                FilePath = messageVM.FilePath,
                CreateDate = DateTime.Now,
                TicketId = messageVM.TicketId,
            };
            await _repository.AddMessage(message);
            await SaveChanges();
        }

        public async Task<IEnumerable<TicketVM>> GetAllTickets()
        {
            IEnumerable<Ticket> ticket = await _repository.GetAllTickets();
            List<TicketVM> tickets = [];
            foreach (var item in ticket)
            {
                tickets.Add(new TicketVM
                {
                    Title = item.Title,
                    Messages = item.Messages,
                    Priority = item.Priority,
                    Section = item.Section,
                    Status = item.Status,
                    CreateDate = item.CreateDate,
                    Description = item.Description,
                    FilePath = item.FilePath,
                    LastModifiedDate = item.CreateDate,
                });
            }
            return tickets;
        }

        public async Task<IEnumerable<TicketVM>> GetTicketsByUserId(int userId)
        {
            IEnumerable<Ticket> ticket = await _repository.GetTicketsByUserId(userId);
            List<TicketVM> tickets = [];
            foreach (var item in ticket)
            {
                tickets.Add(new TicketVM
                {
                    Title = item.Title,
                    Messages = item.Messages,
                    Priority = item.Priority,
                    Section = item.Section,
                    Status = item.Status,
                    CreateDate = item.CreateDate,
                    Description = item.Description,
                    FilePath = item.FilePath,
                    LastModifiedDate = item.CreateDate,
                });
            }
            return tickets;
        }

        public async Task<IEnumerable<MessageVM>> GetMessagesByTicketId(int ticketId)
        {
            IEnumerable<TicketMessage> message = await _repository.GetMessagesByTicketId(ticketId);
            List<MessageVM> messages = [];
            foreach (var item in message)
            {
                messages.Add(new MessageVM
                {
                    Title = item.Title,
                    Messages = item.Messages,
                    Text = item.Text,
                    CreateDate = item.CreateDate,
                    FilePath = item.FilePath,
                    LastModifiedDate = item.CreateDate,
                });
            }
            return messages;
        }

        public async Task<TicketVM> GetTicketById(int ticketId)
        {
            var item = await _repository.GetTicketById(ticketId);
            var model = new TicketVM
            {
                Title = item.Title,
                Messages = item.Messages,
                Priority = item.Priority,
                Section = item.Section,
                Status = item.Status,
                CreateDate = item.CreateDate,
                Description = item.Description,
                FilePath = item.FilePath,
                LastModifiedDate = item.CreateDate,
            };
            return model;
        }

        public async Task<MessageVM> GetMessageById(int messageId)
        {
            var message = await _repository.GetMessageById(messageId);
            var model = new MessageVM
            {
                Title = message.Title,
                Text = message.Text,
                CreateDate = message.CreateDate,
                FilePath = message.FilePath,
                LastModifiedDate = message.LastModifiedDate,
                Messages = message.Messages,
            };
            return model;
        }

        public async Task<int> GetTicketCounts(int userId)
        {
            return await _repository.GetTicketCounts(userId);
        }

        public async Task<int> GetMessageCounts(int ticketId)
        {
            return await _repository.GetMessageCounts(ticketId);
        }

        public async Task UpdateTicket(TicketVM ticketVM)
        {
            Ticket ticket = new()
            {
                Title = ticketVM.Title,
                Description = ticketVM.Description,
                Section = ticketVM.Section,
                Status = ticketVM.Status,
                LastModifiedDate = DateTime.Now,
                Messages = ticketVM.Messages
            };
            await _repository.UpdateTicket(ticket);
            await SaveChanges();
        }

        public async Task UpdateMessage(MessageVM messageVM)
        {
            TicketMessage message = new()
            {
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
