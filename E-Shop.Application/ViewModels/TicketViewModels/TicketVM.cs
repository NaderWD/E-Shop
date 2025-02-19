using E_Shop.Domain.Models.TiketModels;
using E_Shop.Domain.Models;
using static E_Shop.Domain.Enum.TicketsEnums;
using System.ComponentModel.DataAnnotations;

namespace E_Shop.Application.ViewModels.TicketViewModels
{
    public class TicketVM
    {
        [Key]
        public int Id { get; set; }

        public DateTime? CreateDate { get; set; }

        public DateTime? LastModifiedDate { get; set; }

        [Display(Name = "موضوع")]
        [Required(ErrorMessage = " لطفا {0} را وارد کنید")]
        [MaxLength(255, ErrorMessage = "حداکثر تعداد کاراکتر مجاز 255 می باشد")]
        public string? Title { get; set; }


        public int UserId { get; set; }

        public User? User { get; set; }

        [Display(Name = "متن پیام")]
        [Required(ErrorMessage = " لطفا {0} را وارد کنید")]
        [MaxLength(2550, ErrorMessage = "حداکثر تعداد کاراکتر مجاز 2550 می باشد")]
        public string Message { get; set; }

        [Display(Name = "بخض")]
        [Required(ErrorMessage = " لطفا {0} را انتخاب کنید")]
        public Section? Section { get; set; }

        [Display(Name = "وضعیت")]
        public Status? Status { get; set; }

        [Display(Name = "اولویت")]
        [Required(ErrorMessage = " لطفا {0} را انتخاب کنید")]
        public Priority? Priority { get; set; }

        public string? FilePath { get; set; }

        public bool? IsAdmin { get; set; }

        public int IsDelete { get; set; }
    }
}
