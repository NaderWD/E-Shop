using E_Shop.Domain.Models;
using E_Shop.Domain.Models.TiketModels;
using System.ComponentModel.DataAnnotations;
using static E_Shop.Domain.Enum.TicketsEnums;

namespace E_Shop.Application.ViewModels.TicketViewModels
{
    public class TicketVM
    {
        [Key]
        [Display(Name = "شناسه")]
        public int Id { get; set; }

        [Display(Name = "زمان ایجاد")]
        public DateTime? CreateDate { get; set; }

        [Display(Name = "آخرین بروز رسانی")]
        public DateTime? LastModifiedDate { get; set; }

        public bool IsDelete { get; set; }

        [Display(Name = "موضوع")]
        [Required(ErrorMessage = " لطفا {0} را وارد کنید")]
        [MaxLength(255, ErrorMessage = "حداکثر تعداد کاراکتر مجاز 255 می باشد")]
        public string? Title { get; set; }

        public int SenderId { get; set; }       
                                             
        public int OwnerId { get; set; }    

        public User? User { get; set; }

        [Display(Name = "بخض")]
        [Required(ErrorMessage = " لطفا {0} را انتخاب کنید")]
        public Section Section { get; set; }

        [Display(Name = "وضعیت")]
        public Status Status { get; set; }

        [Display(Name = "اولویت")]
        [Required(ErrorMessage = " لطفا {0} را انتخاب کنید")]
        public Priority Priority { get; set; }

        public string? FilePath { get; set; }

        public string? Message { get; set; }

        [Display(Name = "تعداد پیام ها")]
        public int? NumberOfMessages { get; set; }

        public IEnumerable<MessageVM>? Messages { get; set; }
    }
}
