using E_Shop.Domain.Models.TiketModels;
using E_Shop.Domain.Models;
using static E_Shop.Domain.Enum.TicketsEnums;
using System.ComponentModel.DataAnnotations;

namespace E_Shop.Application.ViewModels.TicketViewModels
{
    public class CreateTicketVM
    {
        [Key]
        public int Id { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int? UserId { get; set; }
        public User? User { get; set; }
        public ICollection<TicketMessage>? Messages { get; set; }
        public ICollection<TicketMessage>? Response { get; set; }
        public Section? Section { get; set; }
        public Status? Status { get; set; }
    }
}
