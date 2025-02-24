using E_Shop.Domain.Models.ProductModels;

namespace E_Shop.Domain.Models.SpecificationModels
{
    public class CategorySpecification : BaseModel
    {
        public int CategoryId { get; set; }
        public int SpecificationId { get; set; }

                                                          
        public ProductCategories? Category { get; set; }
        public Specification? Specification { get; set; }
    }
}
