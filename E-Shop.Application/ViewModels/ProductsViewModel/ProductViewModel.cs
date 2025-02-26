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

}
