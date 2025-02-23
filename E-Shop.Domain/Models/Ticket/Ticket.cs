using E_Shop.Domain.Models.Common;
using System.ComponentModel.DataAnnotations.Schema;
using static E_Shop.Domain.Enum.TicketsEnums;

namespace E_Shop.Domain.Models.Ticket
{
    public class Ticket : BaseModel
    {
        public string Title { get; set; }
        public int SenderId { get; set; }
        public int OwnerId { get; set; }
        [ForeignKey("OwnerId")]
        public User User { get; set; }
        public Section Section { get; set; }
        public Status Status { get; set; }
        public Priority Priority { get; set; }
        public string? FilePath { get; set; }
        public int? NumberOfMessages { get; set; }
        public IEnumerable<TicketMessage>? Messages { get; set; }
    }
}
