using E_Shop.Domain.Models.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace E_Shop.Domain.Models
{
    public class Cart : BaseModel
    {
        [Display(Name = "سفارشات")]
        [Required]
        public Order? Order { get; set; }

        [Display(Name = "کابر")]
        [Required]
        public User? User { get; set; }

        [Display(Name = "وضعیت پرداخت")]
        [DefaultValue(false)]
        public bool IsPaid { get; set; }
    }
}
