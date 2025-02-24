using E_Shop.Application.Tools;
using E_Shop.Application.ViewModels.TicketViewModels;
using E_Shop.Domain.Contracts.TicketCont;
using E_Shop.Domain.Contracts.UserCont;
using E_Shop.Domain.Models.TicketModels;
using Microsoft.AspNetCore.Http;

namespace E_Shop.Application.Services.TicketServices
{
    public class TicketMessageService(ITicketMessageRepository _repository, ITicketRepository _ticketRepository, IUserRepository _userRepository) : ITicketMessageService
    {
        public async Task AddMessageToTicket(MessageVM messageVM, IFormFile? attachment, int userId)
        {
            //if (messageVM.SenderId != userId) throw new Exception("شما مجاز به انجام این عملیات نیستید");
            if (attachment != null && attachment.Length > 0)
            {
                if (!FileExtensions.IsImageOrPdf(attachment.FileName)) throw new Exception("فرمت فایل پشتیبانی نمیشود");
                messageVM.FilePath = SaveFile(attachment);
            }
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
            var user = await _userRepository.GetUserById(userId);
            if (user.IsAdmin) message.IsAdminReply = true;
            await _repository.AddMessage(message);
            await SaveChanges();
            var ticket = await _ticketRepository.GetTicketById(messageVM.TicketId);
            ticket.LastModifiedDate = DateTime.Now;
            await _ticketRepository.UpdateTicket(ticket);
            await SaveChanges();
        }

        public async Task<List<MessageVM>> GetMessagesByTicketId(int ticketId)
        {
            List<TicketMessage> message = await _repository.GetMessagesByTicketId(ticketId);
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

        public async Task<List<MessageVM>> GetDeletedMessagesByTicketId(int ticketId)
        {
            List<TicketMessage> message = await _repository.GetDeletedMessagesByTicketId(ticketId);
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
