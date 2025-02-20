using E_Shop.Application.Services.Interfaces;
using E_Shop.Application.Tools;
using E_Shop.Application.ViewModels.TicketViewModels;
using E_Shop.Domain.Models.TiketModels;
using E_Shop.Domain.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;

namespace E_Shop.Application.Services.Implementations
{
    public class TicketMessageService(ITicketMessageRepository _repository, ITicketRepository _ticketRepository) : ITicketMessageService
    {
        public async Task AddMessageToTicket(MessageVM messageVM, IFormFile? attachment, int userId)
        {
            if (messageVM.Id != userId) throw new Exception("شما مجاز به انجام این عملیات نیستید");
            if (attachment != null)
                if (!FileExtensions.IsImageOrPdf(attachment.FileName))
                    throw new Exception("فرمت فایل پشتیبانی نمیشود");
            messageVM.FilePath = SaveFile(attachment);
            TicketMessage message = new()
            {
                Text = messageVM.Text,
                CreateDate = DateTime.Now,
                TicketId = messageVM.TicketId,
                LastModifiedDate = DateTime.Now,
                IsAdminReply = messageVM.IsAdminReply,
                FilePath = messageVM.FilePath,
                SenderId = userId,
            };
            await _repository.AddMessage(message);
            await SaveChanges();
            var ticket = await _ticketRepository.GetTicketById(messageVM.TicketId);
            ticket.LastModifiedDate = DateTime.Now;
            await _ticketRepository.UpdateTicket(ticket);
            await SaveChanges();
        }

        public async Task<IEnumerable<MessageVM>> GetMessagesByTicketId(int ticketId)
        {
            IEnumerable<TicketMessage> message = await _repository.GetMessagesByTicketId(ticketId);
            List<MessageVM> messages = [];
            foreach (var item in message)
            {
                messages.Add(new MessageVM
                {
                    Id = item.Id,
                    Text = item.Text,
                    CreateDate = item.CreateDate,
                    LastModifiedDate = item.CreateDate,
                    TicketId = item.TicketId,
                    IsDelete = item.IsDelete,
                    FilePath = item.FilePath,
                    SenderId = item.SenderId
                });
            }
            return messages;
        }

        public async Task<IEnumerable<MessageVM>> GetDeletedMessagesByTicketId(int ticketId)
        {
            IEnumerable<TicketMessage> message = await _repository.GetDeletedMessagesByTicketId(ticketId);
            List<MessageVM> messages = [];
            foreach (var item in message)
            {
                messages.Add(new MessageVM
                {
                    Id = item.Id,
                    Text = item.Text,
                    CreateDate = item.CreateDate,
                    LastModifiedDate = item.CreateDate,
                    TicketId = item.TicketId,
                    IsDelete = item.IsDelete,
                    FilePath = item.FilePath,
                    SenderId = item.SenderId
                });
            }
            return messages;
        }

        public async Task SoftDeleteMessage(int messageId)
        {
            await _repository.SoftDeleteMessage(messageId);
        }

        public async Task DeleteMessage(int messageId)
        {
            await _repository.DeleteMessage(messageId);
        }

        public string SaveFile(IFormFile? attachment)
        {
            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(attachment.FileName);
            string savePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot" + FilePath.TicketFilePath, fileName);
            using var stream = new FileStream(savePath, FileMode.Create); attachment.CopyTo(stream);
            return fileName;
        }

        public async Task SaveChanges()
        {
            await _repository.SaveChanges();
        }
    }
}
