using E_Shop.Application.ViewModels.UserViewModels;

namespace E_Shop.Application.ViewModels.TicketViewModels
{
    public class ChatVM
    {
        public List<UserDetailsVM> Users { get; set; }
        public List<TicketVM> Tickets { get; set; }
        public List<MessageVM> Messages { get; set; }
        public MessageVM NewMessage { get; set; } = new MessageVM();
        public TicketVM CurrentTicket { get; set; }
        public int SelectedUserId { get; set; }
        public int SelectedTicketId { get; set; }
    }
}
