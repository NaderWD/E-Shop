using System.ComponentModel.DataAnnotations;

namespace E_Shop.Application.ViewModels.SpecificationViewModels
{

    #region For Createion
    public class SpecificationCreateVM
    {
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
    public class SpecificationDetailsVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<string> Categories { get; set; } = [];
    }

    public class SpecificationListVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int LinkedCategoriesCount { get; set; }
    }
    #endregion



    #region For Product Specifications
    public class ProductSpecificationAddVM
    {
        public int ProductId { get; set; }

        [Display(Name = "مشخصه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int SelectedSpecificationId { get; set; }

        [Display(Name = "مقدار")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(100)]
        public string Value { get; set; }

        public List<SpecificationOptionVM> AvailabeSpecifications { get; set; } = [];
    }

    public class SpecificationOptionVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    #endregion

}
