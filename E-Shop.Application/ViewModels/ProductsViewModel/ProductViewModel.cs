using E_Shop.Application.ViewModels.ColorViewModels;
using E_Shop.Application.ViewModels.Common;
using E_Shop.Application.ViewModels.SpecificationViewModels;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace E_Shop.Application.ViewModels.ProductsViewModel
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "عنوان نباید خالی باشد.")]
        [StringLength(100, ErrorMessage = "عنوان باید کمتر از 100 کاراکتر باشد.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "قیمت نباید خالی باشد.")]
        [Range(0, int.MaxValue, ErrorMessage = "قیمت باید یک عدد مثبت باشد.")]
        public int Price { get; set; }

        [StringLength(500, ErrorMessage = "توضیحات باید کمتر از 500 کاراکتر باشد.")]
        public string Description { get; set; }

        [StringLength(100, ErrorMessage = "نام تصویر باید کمتر از 100 کاراکتر باشد.")]
        public string ImageName { get; set; }

        [Required(ErrorMessage = "شناسه دسته‌بندی نباید خالی باشد.")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = " دسته‌بندی نباید خالی باشد.")]
        public string CategoryName { get; set; }


        [DataType(DataType.MultilineText)]
        public string? Review { get; set; }

        [DataType(DataType.MultilineText)]
        public string? ExpertReview { get; set; }

        [Required(ErrorMessage = "موجودی نباید خالی باشد.")]
        [Range(0, int.MaxValue, ErrorMessage = "موجودی باید یک عدد مثبت باشد.")]
        public int Inventory { get; set; }

        public List<ColorViewModel> color { get; set; }
    }

    public class UpdateProductViewModel
    {
        public int Id { get; set; }

        public IFormFile? Image { get; set; }

        [Required(ErrorMessage = "عنوان نباید خالی باشد.")]
        [StringLength(100, ErrorMessage = "عنوان باید کمتر از 100 کاراکتر باشد.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "قیمت نباید خالی باشد.")]
        [Range(0, int.MaxValue, ErrorMessage = "قیمت باید یک عدد مثبت باشد.")]
        public int Price { get; set; }

        [StringLength(500, ErrorMessage = "توضیحات باید کمتر از 500 کاراکتر باشد.")]
        public string Description { get; set; }

        [StringLength(100, ErrorMessage = "نام تصویر باید کمتر از 100 کاراکتر باشد.")]
        public string? ImageName { get; set; }

        [Required(ErrorMessage = "شناسه دسته‌بندی نباید خالی باشد.")]
        public int CategoryId { get; set; }
        
        [DataType(DataType.MultilineText)]
        public string? Review { get; set; }

        [DataType(DataType.MultilineText)]
        public string? ExpertReview { get; set; }

        [Required(ErrorMessage = "موجودی نباید خالی باشد.")]
        [Range(0, int.MaxValue, ErrorMessage = "موجودی باید یک عدد مثبت باشد.")]
        public int Inventory { get; set; }

        public List<ProductCategoryViewModel>? Category { get; set; }
    }
    
    public class CreateProductViewModel
    {
        [Required(ErrorMessage = "لطفاً یک تصویر انتخاب کنید.")]
        public IFormFile Image { get; set; }

        [Required(ErrorMessage = "عنوان نباید خالی باشد.")]
        [StringLength(100, ErrorMessage = "عنوان باید کمتر از 100 کاراکتر باشد.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "قیمت نباید خالی باشد.")]
        [Range(0, long.MaxValue, ErrorMessage = "قیمت باید یک عدد مثبت باشد.")]
        public int Price { get; set; }

        [StringLength(500, ErrorMessage = "توضیحات باید کمتر از 500 کاراکتر باشد.")]
        public string Description { get; set; }

        [StringLength(100, ErrorMessage = "نام تصویر باید کمتر از 100 کاراکتر باشد.")]
        public string? ImageName { get; set; }

        [Required(ErrorMessage = "شناسه دسته‌بندی نباید خالی باشد.")]
        public int CategoryId { get; set; }
        
        [DataType(DataType.MultilineText)]
        public string? Review { get; set; }

        [DataType(DataType.MultilineText)]
        public string? ExpertReview { get; set; }

        [Required(ErrorMessage = "موجودی نباید خالی باشد.")]
        [Range(0, int.MaxValue, ErrorMessage = "موجودی باید یک عدد مثبت باشد.")]
        public int Inventory { get; set; }

        public List<ProductCategoryViewModel>? Category { get; set; }
    }

    public class ProductCategoryViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }

    public class ProductArchiveViewModel : Paging<ProductViewModel>
    {
        [Display(Name = "عنوان")]
        public string? Title { get; set; }

        [Display(Name = "دسته بندی")]
        public int CategoryId { get; set; }

        [Display(Name = "موجودی")]
        public int? Inventory { get; set; }

        public ProductCategoriesViewModel Category { get; set; }
        public List<ProductSpecVM> Specification { get; set; }
    }

    public class FilterProductViewModel : Paging<ProductViewModel>
    {

        [Display(Name = "عنوان")]
        public string? Title { get; set; }

        [Display(Name ="دسته بندی")]
        public int? CategoryId { get; set; }
        
        [Display(Name ="موجودی")]
        public int? Inventory { get; set; }

        public List<ProductCategoryViewModel>? Category { get; set; }
    }



}
