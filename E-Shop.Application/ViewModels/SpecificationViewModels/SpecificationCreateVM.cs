using E_Shop.Domain.Models.SpecificationModels;
using System.ComponentModel.DataAnnotations;

namespace E_Shop.Application.ViewModels.SpecificationViewModels
{

    #region For Createion
    public class SpecCreateVM
    {
        public int Id { get; set; }

        [Display(Name = "نام مشخصه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(100)]
        public string Name { get; set; }

        [Display(Name = "دسته بندی های قابل انتخاب")]
        public List<int> SelectedCategoryIds { get; set; } = [];

        // For displaying checkbox options                     
        public List<CategorySelectionVM> AvailableCategories { get; set; } = [];
    }

    public class CategorySelectionVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsSelected { get; set; }
    }
    #endregion



    #region For Display
    public class SpecDetailsVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<string> Categories { get; set; } = [];
    }

    public class SpecListVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int LinkedCategoriesCount { get; set; }
    }
    #endregion



    #region For Product Specifications
    public class ProductSpecAddVM    
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        [Display(Name = "مشخصه ی انتخاب شده")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int SelectedSpecificationId { get; set; }

        [Display(Name = "مقدار")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(100)]
        public string Value { get; set; }

        public List<SpecOptionVM>? AvailabeSpecifications { get; set; } = [];
    }

    public class SpecOptionVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class UpdateProductSpecVM
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public int ProductId { get; set; }
        public List<Specification> Specs { get; set; } = [];
    }
    #endregion

}
