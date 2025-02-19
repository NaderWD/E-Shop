using E_Shop.Application.Services.Interfaces;
using E_Shop.Application.ViewModels.TicketViewModels;
using E_Shop.Domain.Models.TiketModels;
using E_Shop.Domain.Repositories.Interfaces;

namespace E_Shop.Application.Services.Implementations
{
    public class TicketMessageService(ITicketMessageRepository _repository) : ITicketMessageService
    {

        public async Task CreateMessage(MessageVM messageVM)
        {
            TicketMessage message = new()
            {
                Title = messageVM.Title,
                Text = messageVM.Text,
                FilePath = messageVM.FilePath,
                CreateDate = DateTime.Now,
                TicketId = messageVM.TicketId,
                LastModifiedDate = DateTime.Now,
            };
            await _repository.AddMessage(message);
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
                    Title = item.Title,
                    Text = item.Text,
                    CreateDate = item.CreateDate,
                    FilePath = item.FilePath,
                    LastModifiedDate = item.CreateDate,
                    TicketId = item.TicketId,
                    UserId = item.UserId,
                    IsDelete = item.IsDelete
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
                    Title = item.Title,
                    Text = item.Text,
                    CreateDate = item.CreateDate,
                    FilePath = item.FilePath,
                    LastModifiedDate = item.CreateDate,
                    TicketId = item.TicketId,
                    UserId = item.UserId,
                    IsDelete = item.IsDelete
                });
            }
            return messages;
        }

        public async Task<MessageVM> GetMessageById(int messageId)
        {
            var item = await _repository.GetMessageById(messageId);
            var model = new MessageVM
            {
                Id = item.Id,
                Title = item.Title,
                Text = item.Text,
                CreateDate = item.CreateDate,
                FilePath = item.FilePath,
                LastModifiedDate = item.CreateDate,
                TicketId = item.TicketId,
                UserId = item.UserId,
                IsDelete = item.IsDelete
            };
            return model;
        }

        public async Task<int> GetMessageCounts(int ticketId)
        {
            return await _repository.GetMessageCounts(ticketId);
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

        public async Task SoftDeleteMessage(int messageId)
        {
            await _repository.SoftDeleteMessage(messageId);
        }

        public async Task DeleteMessage(int messageId)
        {
            await _repository.DeleteMessage(messageId);
        }

        public async Task SaveChanges()
        {
            await _repository.SaveChanges();
        }
    }
}
