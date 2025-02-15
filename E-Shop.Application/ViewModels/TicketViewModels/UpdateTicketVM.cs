using E_Shop.Domain.Models.TiketModels;
using System.ComponentModel.DataAnnotations;
using static E_Shop.Domain.Enum.TicketsEnums;

namespace E_Shop.Application.ViewModels.TicketViewModels
{
    public class UpdateTicketVM
    {
        [Key]
        public int Id { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public Section? Section { get; set; }
        public Status? Status { get; set; }       
    }
}
