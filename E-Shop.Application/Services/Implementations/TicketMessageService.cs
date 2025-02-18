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
                Text = messageVM.Text,
                FilePath = messageVM.FilePath,
                CreateDate = DateTime.Now,
                TicketId = messageVM.TicketId,
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
                    Title = item.Title,
                    Text = item.Text,
                    CreateDate = item.CreateDate,
                    FilePath = item.FilePath,
                    LastModifiedDate = item.CreateDate,
                });
            }
            return messages;
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
