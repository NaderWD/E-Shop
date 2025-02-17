using E_Shop.Domain.Models.Common;

namespace E_Shop.Domain.Models.TiketModels
{
    public class TicketMessage : BaseModel
    {
        public string? Text { get; set; }
        public int? TicketId { get; set; }
        public Ticket? Ticket { get; set; }
        public string? FilePath { get; set; }
        public string? Title { get; set; }
        public IEnumerable<TicketMessage> Messages { get; set; }
    }
}
