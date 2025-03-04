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

        public ICollection<DiscountProductMapping> DiscountProductMappings { get; set; }
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

        public ICollection<DiscountProductMapping> DiscountProductMappings { get; set; }
    }
}
