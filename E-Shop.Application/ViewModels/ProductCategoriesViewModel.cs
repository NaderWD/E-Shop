using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Shop.Application.ViewModels
{
    public class ProductCategoriesViewModel
    {
        [Required(ErrorMessage = "نام نمی‌تواند خالی باشد")]
        [MaxLength(100, ErrorMessage = "نام نباید بیشتر از ۱۰۰ کاراکتر باشد")]
        public string Name { get; set; }
        public string ParentName { get; set; }

        public int? ParentId { get; set; }

        public int Id { get; set; }

        public DateTime LastModifiedDate { get; set; }

        public DateTime CreateDate { get; set; }

        public bool? IsDelete { get; set; }
    }
}
