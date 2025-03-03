using E_Shop.Domain.Models.ProductModels;
using System.ComponentModel.DataAnnotations;

namespace E_Shop.Application.ViewModels.SpecificationViewModels
{
    public class SpecVM
    {
        public int SpecId { get; set; }
        public string Name { get; set; }
        public int CategorySpecId { get; set; }
        public int ProductSpecId { get; set; }
    }

    public class SpecCreateVM
    {
        public int SpecId { get; set; }

        [Display(Name = "نام مشخصه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(100)]
        public string Name { get; set; }

        public List<int> SelectedCategoryIds { get; set; } = [];

        public int NumberOfLinkedCategory { get; set; }

        public List<ProductCategories>? AllCategories { get; set; } = [];
    }

    public class SpecDetailsVM
    {
        public int SpecId { get; set; }
        public string Name { get; set; }
        public List<string> LinkedCategories { get; set; } = [];
    }

    public class SpecListVM
    {
        public int SpecId { get; set; }
        public string Name { get; set; }
        public int LinkedCategoriesCount { get; set; }
    }

    public class AddSpecToProductVM
    {
        public int SpecId { get; set; }
                                                                                     
        public int ProductId { get; set; }

        public List<int>? SelectedSpecificationIds { get; set; }

        public List<string> Values { get; set; }

        public List<SpecVM> AvailabeSpecifications { get; set; } = [];
    }

    public class CategorySpecVM
    {
        public int SpecId { get; set; }
        public int CategoryId { get; set; }
    }

    public class ProductSpecVM
    {
        public int SpecId { get; set; }
        public int ProductId { get; set; }
        public string Value { get; set; }
    }

    public class ProductSpecDetailVM
    {
        public int SpecId { get; set; }
        public string SpecName { get; set; }
        public string Value { get; set; }
    }

    public class ProSpecDetailsFinalVM
    {
        public int ProductId { get; set; }
        public List<ProductSpecDetailVM>? ProSpecVM { get; set; }
    }
}
