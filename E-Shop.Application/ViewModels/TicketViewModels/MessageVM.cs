using E_Shop.Domain.Models.TiketModels;
using System.ComponentModel.DataAnnotations;

namespace E_Shop.Application.ViewModels.TicketViewModels
{
    public class MessageVM
    {
        [Key]
        public int? Id { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public string? Text { get; set; }
        public int? TicketId { get; set; }
        public Ticket? Ticket { get; set; }
        public string? FilePath { get; set; }
        public string? Title { get; set; }
        public IEnumerable<TicketMessage> Messages { get; set; }
    }
}
