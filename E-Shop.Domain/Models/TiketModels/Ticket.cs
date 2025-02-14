using E_Shop.Domain.Models.Common;

namespace E_Shop.Domain.Models.TiketModels
{
    public class Ticket : BaseModel
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Status { get; set; }
        public int? UserId { get; set; }
        public User? User { get; set; }
        public ICollection<TicketMessage>? Messages { get; set; }
    }
}
