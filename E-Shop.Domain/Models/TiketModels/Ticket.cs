using E_Shop.Domain.Models.Common;
using static E_Shop.Domain.Enum.TicketsEnums;

namespace E_Shop.Domain.Models.TiketModels
{
    public class Ticket : BaseModel
    {
        public string? Title { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }          
        public string? Message { get; set; }
        public List<TicketMessage> Messages { get; set; } = [];
        public Section? Section { get; set; }
        public Status? Status { get; set; }
        public Priority? Priority { get; set; }
        public bool? IsAdmin { get; set; }
        public string? FilePath { get; set; }  
    }
}
