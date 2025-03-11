using E_Shop.Application.ViewModels.UserViewModels;
using E_Shop.Domain.Enum;
using E_Shop.Domain.Models.ValidationModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Shop.Application.ViewModels.Wallet
{
    public class WalletViewModel
    {
        [Display(Name = "مبلغ")]
        [Required(ErrorMessage = "پر کردن {0} اجباری است.")]
        [Range(10000, int.MaxValue, ErrorMessage = "{0} باید حداقل 10000 ریال باشد.")]
        public int Amount { get; set; }

        [Display(Name = "شناسه کاربر")]
        [Required(ErrorMessage = "پر کردن {0} اجباری است.")]
        public int UserId { get; set; }

        [Display(Name = "نوع تراکنش")]
        [Required(ErrorMessage = "انتخاب {0} اجباری است.")]
        public TransactionType Type { get; set; }

        [Display(Name = "وضعیت تراکنش")]
        [Required(ErrorMessage = "انتخاب {0} اجباری است.")]
        public TranStatus Status { get; set; }

        [Display(Name = "کاربر")]
        public UserViewModel? User { get; set; }

        [Display(Name = "تاریخ ایجاد")]
        [DataType(DataType.DateTime)]
        public DateTime? CreateDate { get; set; }

        [Display(Name = "شناسه")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Id { get; set; }
    }
}
