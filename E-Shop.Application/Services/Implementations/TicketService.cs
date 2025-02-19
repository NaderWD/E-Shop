using E_Shop.Application.Services.Interfaces;
using E_Shop.Application.ViewModels.TicketViewModels;
using E_Shop.Domain.Models;
using E_Shop.Domain.Models.TiketModels;
using E_Shop.Domain.Repositories.Interfaces;
using static E_Shop.Domain.Enum.TicketsEnums;
using static E_Shop.Application.Tools.UserExtensions;
using E_Shop.Application.Tools;

namespace E_Shop.Application.Services.Implementations
{
    public class TicketService(ITicketRepository _repository, ITicketMessageRepository _messageRepository) : ITicketService
    {
        public async Task CreateTicket(TicketVM ticketVM)
        {
            Ticket ticket = new()
            {
                Title = ticketVM.Title,
                Section = ticketVM.Section,
                Status = Status.Open,
                CreateDate = DateTime.Now,
                LastModifiedDate = DateTime.Now,
                Priority = ticketVM.Priority,
                FilePath = ticketVM.FilePath,
                UserId = ticketVM.UserId,
                IsAdmin = ticketVM.IsAdmin,
            };
            await _repository.AddTicket(ticket);
            await SaveChanges();
            var ticketMessage = new TicketMessage()
            {
                TicketId = ticket.Id,
                Text = ticketVM.Message,
                CreateDate = DateTime.Now,
                Title = ticketVM.Title,
                FilePath = ticketVM.FilePath,
                LastModifiedDate = ticketVM.LastModifiedDate,
                UserId = ticketVM.UserId,
            };
            await _messageRepository.AddMessage(ticketMessage);
            ticket.Message = ticketMessage.Text;
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
                    Id = item.Id,
                    Title = item.Title,
                    Message = item.Message,
                    Priority = item.Priority,
                    Section = item.Section,
                    Status = item.Status,
                    CreateDate = item.CreateDate,
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
                    Id = item.Id,
                    Title = item.Title,
                    Message = item.Message,
                    Priority = item.Priority,
                    Section = item.Section,
                    Status = item.Status,
                    CreateDate = item.CreateDate,
                    FilePath = item.FilePath,
                    LastModifiedDate = item.CreateDate,
                });
            }
            return tickets;
        }

        public async Task<IEnumerable<TicketVM>> GetDeletedTicketsByUserId(int userId)
        {
            IEnumerable<Ticket> ticket = await _repository.GetDeletedTicketsByUserId(userId);
            List<TicketVM> tickets = [];
            foreach (var item in ticket)
            {
                tickets.Add(new TicketVM
                {
                    Id = item.Id,
                    Title = item.Title,
                    Message = item.Message,
                    Priority = item.Priority,
                    Section = item.Section,
                    Status = item.Status,
                    CreateDate = item.CreateDate,
                    FilePath = item.FilePath,
                    LastModifiedDate = item.CreateDate,
                });
            }
            return tickets;
        }

        public async Task<TicketVM> GetTicketById(int ticketId)
        {
            var item = await _repository.GetTicketById(ticketId);
            var model = new TicketVM
            {
                Title = item.Title,
                Message = item.Message,
                Priority = item.Priority,
                Section = item.Section,
                Status = item.Status,
                CreateDate = item.CreateDate,
                FilePath = item.FilePath,
                LastModifiedDate = item.CreateDate,
            };
            return model;
        }

        public async Task<int> GetTicketCounts(int userId)
        {
            return await _repository.GetTicketCounts(userId);
        }

        public async Task UpdateTicket(TicketVM ticketVM)
        {
            var ticket = await _repository.GetTicketById(ticketVM.Id);
            if (ticket == null) return;

            ticket.Title = ticketVM.Title;
            ticket.Section = ticketVM.Section;
            ticket.Status = ticketVM.Status;
            ticket.LastModifiedDate = DateTime.Now;
            ticket.Priority = ticketVM.Priority;
            ticket.FilePath = ticketVM.FilePath;
            ticket.UserId = ticketVM.UserId;
            ticket.IsAdmin = ticketVM.IsAdmin;

            await _repository.UpdateTicket(ticket);
            await _repository.SaveChanges();
        }

        public async Task SoftDeleteTicket(int ticketId)
        {
            var messages = await _messageRepository.GetMessagesByTicketId(ticketId);
            foreach (var item in messages) item.IsDelete = true;
            await _repository.SoftDeleteTicket(ticketId);
            await SaveChanges();
        }

        public async Task DeleteTicket(int ticketId)
        {
            var message = await _messageRepository.GetMessageByTicketId(ticketId);
            await _messageRepository.DeleteMessage(message.Id);
            await _repository.DeleteTicket(ticketId);
            await SaveChanges();
        }

        public async Task SaveChanges()
        {
            await _repository.SaveChanges();
        }
    }
}
