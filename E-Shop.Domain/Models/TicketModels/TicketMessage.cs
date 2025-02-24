using System.ComponentModel.DataAnnotations.Schema;

namespace E_Shop.Domain.Models.TicketModels
{
    public class TicketMessage : BaseModel
    {
        public string Text { get; set; }
        public int TicketId { get; set; }
        [ForeignKey("TicketId")]
        public Ticket Ticket { get; set; }                 
        public int SenderId { get; set; }
        public bool IsAdminReply { get; set; }
        public string? FilePath { get; set; }
    }
}
