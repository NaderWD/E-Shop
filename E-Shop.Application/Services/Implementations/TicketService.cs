using E_Shop.Application.Services.Interfaces;
using E_Shop.Application.ViewModels.TicketViewModels;
using E_Shop.Domain.Models.TiketModels;
using E_Shop.Domain.Repositories.Interfaces;
using static E_Shop.Domain.Enum.TicketsEnums;

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
                Priority = ticketVM.Priority,
                FilePath = ticketVM.FilePath,
            };
            await _repository.AddTicket(ticket);
            await SaveChanges();
            var ticketMessage = new TicketMessage()
            {
                TicketId = ticket.Id,
                Text = ticketVM.Message,
            };
            await _messageRepository.AddMessage(ticketMessage);
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
            Ticket ticket = new()
            {
                Title = ticketVM.Title,
                Section = ticketVM.Section,
                Status = ticketVM.Status,
                LastModifiedDate = DateTime.Now,
                Message = ticketVM.Message
            };
            await _repository.UpdateTicket(ticket);
            await SaveChanges();
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
