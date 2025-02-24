using E_Shop.Application.Services.Interfaces;
using E_Shop.Application.Tools;
using E_Shop.Application.ViewModels.TicketViewModels;
using E_Shop.Domain.Contracts.TicketCont;
using E_Shop.Domain.Contracts.UserCont;
using E_Shop.Domain.Models.TicketModels;
using Microsoft.AspNetCore.Http;
using static E_Shop.Domain.Enum.TicketsEnums;

namespace E_Shop.Application.Services.Implementations
{
    public class TicketService(ITicketRepository _ticketRepository, ITicketMessageRepository _messageRepository, IUserRepository _userRepository) : ITicketService
    {

        public async Task CreateTicket(TicketVM ticketVM, IFormFile? attachment, int userId)
        {
            var user = await _userRepository.GetUserById(userId);
            if (attachment != null && attachment.Length > 0)
            {
                if (!FileExtensions.IsImageOrPdf(attachment.FileName)) throw new Exception("فرمت فایل پشتیبانی نمیشود");
                ticketVM.FilePath = SaveFile(attachment);
            }
            Ticket ticket = new()
            {
                Title = ticketVM.Title,
                Section = ticketVM.Section,
                Status = Status.InProgress,
                CreateDate = DateTime.Now,
                LastModifiedDate = DateTime.Now,
                Priority = ticketVM.Priority,
                FilePath = ticketVM.FilePath,
                OwnerId = userId,
                IsDelete = false,

            };
            await _ticketRepository.AddTicket(ticket);
            await SaveChanges();
            TicketMessage ticketMessage = new()
            {
                TicketId = ticket.Id,
                Text = ticketVM.Message,
                FilePath = ticketVM.FilePath,
                CreateDate = DateTime.Now,
                LastModifiedDate = ticketVM.LastModifiedDate,
                SenderId = ticketVM.SenderId,
                IsDelete = false,
            };
            await _messageRepository.AddMessage(ticketMessage);
            ticket.NumberOfMessages = GetMessageCounts(ticketVM.Id);
            await _ticketRepository.UpdateTicket(ticket);
            await SaveChanges();
        }

        public async Task<List<TicketVM>> GetAllTickets()
        {
            var ticket = await _ticketRepository.GetAllTickets();

            return [.. ticket.Select(item => new TicketVM()
            {
                Id = item.Id,
                Title = item.Title,
                Priority = item.Priority,
                Section = item.Section,
                Status = item.Status,
                CreateDate = item.CreateDate,
                FilePath = item.FilePath,
                LastModifiedDate = item.CreateDate,
                NumberOfMessages = GetMessageCounts(item.Id),
                OwnerId = item.OwnerId
            })];
        }

        public async Task<List<TicketVM>> GetTicketsByUserId(int userId)
        {
            var tickets = await _ticketRepository.GetTicketsByUserId(userId);
            return [.. tickets.Select(item => new TicketVM()
            {
                Id = item.Id,
                Title = item.Title,
                Priority = item.Priority,
                Section = item.Section,
                Status = item.Status,
                CreateDate = item.CreateDate,
                FilePath = item.FilePath,
                LastModifiedDate = item.CreateDate,
                NumberOfMessages = GetMessageCounts(item.Id)  ,
                OwnerId = item.OwnerId,
                SenderId = userId,
            })];
        }

        public async Task<List<TicketVM>> GetDeletedTicketsByUserId(int userId)
        {
            IEnumerable<Ticket> ticket = await _ticketRepository.GetDeletedTicketsByUserId(userId);
            List<TicketVM> tickets = [];
            foreach (var item in ticket)
            {
                tickets.Add(new TicketVM
                {
                    Id = item.Id,
                    Title = item.Title,
                    Priority = item.Priority,
                    Section = item.Section,
                    Status = item.Status,
                    CreateDate = item.CreateDate,
                    FilePath = item.FilePath,
                    LastModifiedDate = item.CreateDate,
                    NumberOfMessages = GetMessageCounts(item.Id)
                });
            }
            return tickets;
        }

        public async Task<TicketVM> GetTicketById(int ticketId)
        {
            var ticket = await _ticketRepository.GetTicketById(ticketId);
            if (ticket == null) return null;
            var messages = await _messageRepository.GetMessagesByTicketId(ticketId);

            var model = new TicketVM
            {
                Messages = [],

                Id = ticket.Id,
                Title = ticket.Title,
                Priority = ticket.Priority,
                Section = ticket.Section,
                Status = ticket.Status,
                CreateDate = ticket.CreateDate,
                LastModifiedDate = ticket.LastModifiedDate,
                OwnerId = ticket.OwnerId
            };

            foreach (var message in messages)
            {
                model.Messages.Add(new MessageVM
                {
                    Id = message.Id,
                    Text = message.Text,
                    CreateDate = message.CreateDate,
                    LastModifiedDate = message.LastModifiedDate,
                    IsAdminReply = message.IsAdminReply,
                    TicketId = message.TicketId,
                    FilePath = message.FilePath,
                    SenderId = message.SenderId
                });
            }
            return model;
        }

        public async Task<int> GetUserIdByTicketId(int ticketId)
        {
            var ticket = await GetTicketById(ticketId);
            return ticket.OwnerId;
        }

        public int? GetTicketCounts(int userId)
        {
            return _ticketRepository.GetTicketsCountByUserId(userId);
        }

        public int? GetMessageCounts(int ticketId)
        {
            return _ticketRepository.GetMessagesCountByTicketId(ticketId);
        }

        public async Task UpdateTicket(TicketVM ticketVM)
        {
            var ticket = await _ticketRepository.GetTicketById(ticketVM.Id);
            if (ticket == null) return;

            ticket.Title = ticketVM.Title;
            ticket.Section = ticketVM.Section;
            ticket.Status = ticketVM.Status;
            ticket.LastModifiedDate = DateTime.Now;
            ticket.Priority = ticketVM.Priority;
            ticket.FilePath = ticketVM.FilePath;
            ticket.OwnerId = ticketVM.OwnerId;
            ticket.NumberOfMessages = GetMessageCounts(ticketVM.Id);
            ticket.IsDelete = ticketVM.IsDelete;
            await _ticketRepository.UpdateTicket(ticket);
            await _ticketRepository.SaveChanges();
        }

        public async Task UpdateTicketStatus(int ticketId, Status status)
        {
            var ticket = await _ticketRepository.GetTicketById(ticketId) ?? throw new Exception("تیکت پیدا نشد");
            ticket.Status = status;
            ticket.LastModifiedDate = DateTime.Now;
            await _ticketRepository.UpdateTicket(ticket);
            await SaveChanges();
        }

        public async Task SoftDeleteTicket(int ticketId)
        {
            var messages = await _messageRepository.GetMessagesByTicketId(ticketId);
            foreach (var item in messages) item.IsDelete = true;
            await _ticketRepository.SoftDeleteTicket(ticketId);
            await SaveChanges();
        }

        public async Task DeleteTicket(int ticketId)
        {
            var messages = await _messageRepository.GetMessagesByTicketId(ticketId);
            foreach (var message in messages) await _messageRepository.DeleteMessage(message.Id);
            await _ticketRepository.DeleteTicket(ticketId);
            await SaveChanges();
        }

        public string SaveFile(IFormFile? attachment)
        {
            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(attachment.FileName);
            string savePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot" + FilePath.TicketFilePath, fileName);
            using (var stream = new FileStream(savePath, FileMode.Create))
            {
                attachment.CopyTo(stream);
            }
            return fileName;
        }

        public async Task SaveChanges()
        {
            await _ticketRepository.SaveChanges();
        }
    }
}
