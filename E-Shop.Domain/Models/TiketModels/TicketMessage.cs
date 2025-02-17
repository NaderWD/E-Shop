using E_Shop.Domain.Models.Common;

namespace E_Shop.Domain.Models.TiketModels
{
    public class TicketMessage : BaseModel
    {
        public string? Title { get; set; }
        public string? Text { get; set; }
        public int? TicketId { get; set; }
        public Ticket? Ticket { get; set; }
        public string? FilePath { get; set; }
    }
}
