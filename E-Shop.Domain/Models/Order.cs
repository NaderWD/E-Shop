using E_Shop.Domain.Models.Common;
using System.ComponentModel.DataAnnotations;

namespace E_Shop.Domain.Models
{
    public class Order : BaseModel
    {
        [Display(Name = "محصول")]
        [Required]
        public Product? Product { get; set; }
    }
}
