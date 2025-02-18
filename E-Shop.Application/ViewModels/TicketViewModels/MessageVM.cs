using E_Shop.Domain.Models;
using E_Shop.Domain.Models.TiketModels;
using System.ComponentModel.DataAnnotations;

namespace E_Shop.Application.ViewModels.TicketViewModels
{
    public class MessageVM
    {
        [Key]
        public int? Id { get; set; }

        [Display(Name = "موضوع")]
        [Required(ErrorMessage = " لطفا {0} را وارد کنید")]
        [MaxLength(255, ErrorMessage = "حداکثر تعداد کاراکتر مجاز 255 می باشد")]
        public string? Title { get; set; }

        [Display(Name = "متن پیام")]
        [Required(ErrorMessage = " لطفا {0} را وارد کنید")]
        [MaxLength(2550, ErrorMessage = "حداکثر تعداد کاراکتر مجاز 0255 می باشد")]
        public string? Text { get; set; }

        public DateTime? CreateDate { get; set; }

        public DateTime? LastModifiedDate { get; set; }

        public int? TicketId { get; set; }

        public Ticket? Ticket { get; set; }

        public int? UserId { get; set; }

        public User? User { get; set; }

        public string? FilePath { get; set; }
    }
}
