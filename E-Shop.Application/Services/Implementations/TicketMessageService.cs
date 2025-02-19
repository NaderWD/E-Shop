using E_Shop.Application.Services.Interfaces;
using E_Shop.Application.ViewModels.TicketViewModels;
using E_Shop.Domain.Models.TiketModels;
using E_Shop.Domain.Repositories.Interfaces;

namespace E_Shop.Application.Services.Implementations
{
    public class TicketMessageService(ITicketMessageRepository _repository) : ITicketMessageService
    {
        public async Task AddMessageToTicket(MessageVM messageVM)
        {
            TicketMessage message = new()
            {
                Text = messageVM.Text,
                CreateDate = DateTime.Now,
                TicketId = messageVM.TicketId,
                LastModifiedDate = DateTime.Now,
                IsAdminReply = messageVM.IsAdminReply
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
                    Text = item.Text,
                    CreateDate = item.CreateDate,
                    LastModifiedDate = item.CreateDate,
                    TicketId = item.TicketId,
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
                    Text = item.Text,
                    CreateDate = item.CreateDate,
                    LastModifiedDate = item.CreateDate,
                    TicketId = item.TicketId,
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
                Text = item.Text,
                CreateDate = item.CreateDate,
                LastModifiedDate = item.CreateDate,
                TicketId = item.TicketId,
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
