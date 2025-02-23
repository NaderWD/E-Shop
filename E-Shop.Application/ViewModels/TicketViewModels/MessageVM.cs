using E_Shop.Domain.Models.Ticket;
using System.ComponentModel.DataAnnotations;

namespace E_Shop.Application.ViewModels.TicketViewModels
{
    public class MessageVM
    {
        [Key]
        public int? Id { get; set; }

        [Display(Name = "متن پیام")]
        [Required(ErrorMessage = " لطفا {0} را وارد کنید")]
        [MaxLength(2550, ErrorMessage = "حداکثر تعداد کاراکتر مجاز 0255 می باشد")]
        public string? Text { get; set; }

        public DateTime? CreateDate { get; set; }

        public DateTime? LastModifiedDate { get; set; }

        public int SenderId { get; set; }

        public int TicketId { get; set; }                                          

        public Ticket? Ticket { get; set; }

        public bool IsAdminReply { get; set; }

        public bool IsDelete { get; set; }

        public string? FilePath { get; set; }
    }
}
