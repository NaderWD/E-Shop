using E_Shop.Domain.Models.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Shop.Domain.Models
{
    public class ProductCategories : BaseModel
    {
        [Required(ErrorMessage = "نام نمی‌تواند خالی باشد")]
        [MaxLength(100, ErrorMessage = "نام نباید بیشتر از ۱۰۰ کاراکتر باشد")] 
        public string Name { get; set; }

        public int? ParentId { get; set; }

        [ForeignKey ("ParentId")]
        ProductCategories Parent {  get; set; }
        List<ProductCategories> SubCategories { get; set; }
    }
}
