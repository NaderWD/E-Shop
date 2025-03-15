using E_Shop.Application.ViewModels.ProductsViewModel;
using E_Shop.Domain.Models.DiscountsModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Shop.Application.ViewModels.DiscountsViewModels
{
    public class DiscountViewModel
    {
        public int? Id { get; set; }
        [MaxLength(50)]
        public string? Code { get; set; }

        [Range(0, 100)]
        public int? DiscountPercentage { get; set; }

        [Range(0, int.MaxValue)]
        public int? DiscountAmount { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public bool IsActive { get; set; }

        public bool IsAppliedToAll { get; set; }

        public DateTime? CreateDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }

        public ICollection<DiscountProductMapping>? DiscountProductMappings { get; set; }
    }
    public class UpdateDiscountViewModel
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string? Code { get; set; }

        [Range(0, 100)]
        public int? DiscountPercentage { get; set; }

        [Range(0, int.MaxValue)]
        public int? DiscountAmount { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public bool IsActive { get; set; }

        public DateTime? CreateDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }

        public ICollection<DiscountProductMapping>? DiscountProductMappings { get; set; }
    }
    public class AddMappingViewModel 
    {
        [Required(ErrorMessage = "شناسه محصول الزامی است")]
        [Range(1, int.MaxValue, ErrorMessage = "شناسه محصول باید یک عدد مثبت باشد")]
        [Display(Name = "شناسه محصول")]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "شناسه تخفیف الزامی است")]
        [Range(1, int.MaxValue, ErrorMessage = "شناسه تخفیف باید یک عدد مثبت باشد")]
        [Display(Name = "شناسه تخفیف")]
        public int DiscountId { get; set; }

        [Display(Name = "اعمال به همه محصولات")]
        public bool IsAppliedToAll { get; set; }
    }

    public class UpdateMappingViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "شناسه محصول الزامی است")]
        [Range(1, int.MaxValue, ErrorMessage = "شناسه محصول باید یک عدد مثبت باشد")]
        [Display(Name = "شناسه محصول")]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "شناسه تخفیف الزامی است")]
        [Range(1, int.MaxValue, ErrorMessage = "شناسه تخفیف باید یک عدد مثبت باشد")]
        [Display(Name = "شناسه تخفیف")]
        public int DiscountId { get; set; }

        [Display(Name = "اعمال به همه محصولات")]
        public bool IsAppliedToAll { get; set; }
    }
    public class DiscountsSelectViewModel 
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Code { get; set; }

        [Range(0, 100)]
        public int? DiscountPercentage { get; set; }

        [Range(0, int.MaxValue)]
        public int? DiscountAmount { get; set; }

        public string DisplayText
        {
            get
            {
                if (DiscountAmount.HasValue && DiscountPercentage.HasValue == false)
                {
                    return $"{Code} - {DiscountAmount.Value} off";
                }
                else if (DiscountPercentage.HasValue && DiscountAmount.HasValue == false)
                {
                    return $"{Code} - {DiscountPercentage.Value}% off";
                }
                else
                {
                    return $"{Code} - {DiscountPercentage!.Value}% - {DiscountAmount!.Value} off";
                }
                
            }
        }
    }
    
}
