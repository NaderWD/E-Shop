using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace E_Shop.Domain.Models.Common
{
    public abstract class BaseModel
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Display(Name = "تاریخ ایجاد")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public DateTime CreateDate { get; set; }

        [Display(Name = "تاریخ آخرین اصلاح")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public DateTime LastModifiedDate { get; set; }

        [Required]
        [DefaultValue(false)]
        public bool IsActive { get; set; }
    }
}
