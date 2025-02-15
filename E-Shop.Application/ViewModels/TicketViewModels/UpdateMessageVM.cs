using System.ComponentModel.DataAnnotations;

namespace E_Shop.Application.ViewModels.TicketViewModels
{
    public class UpdateMessageVM
    {
        [Key]
        public int Id { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public string? Text { get; set; }  
        public string? FilePath { get; set; }
    }
}
