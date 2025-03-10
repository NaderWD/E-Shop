﻿using System.ComponentModel.DataAnnotations;

namespace E_Shop.Application.ViewModels.ProductsViewModel
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

    public class CreatProductCategoryViewModel 
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "نام نمی‌تواند خالی باشد")]
        [MaxLength(100, ErrorMessage = "نام نباید بیشتر از ۱۰۰ کاراکتر باشد")]
        public string Name { get; set; }

        public int? ParentId { get; set; }
        public string? ParentName { get; set; }


        public List<SelectListitem>? ParentList { get; set; }
    }

    public class SelectListitem 
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

}
