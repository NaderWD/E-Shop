using E_Shop.Domain.Models.Common;

namespace E_Shop.Domain.Models.TiketModels
{
    public class TicketMessage : BaseModel
    {
        public string? Message { get; set; }
        public DateTime? SentAt { get; set; }
        public int? TicketId { get; set; }
        public Ticket? Ticket { get; set; }
        public int? UserId { get; set; }
        public User? User { get; set; }
        public string? FileDir { get; set; }
    }
}
