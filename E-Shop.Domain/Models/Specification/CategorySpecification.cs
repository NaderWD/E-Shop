using E_Shop.Domain.Models.Common;
using E_Shop.Domain.Models.Products;

namespace E_Shop.Domain.Models.Specification
{
    public class CategorySpecification : BaseModel
    {
        public int CategoryId { get; set; }
        public int SpecificationId { get; set; }

                                                          
        public ProductCategories? Category { get; set; }
        public Specification? Specification { get; set; }
    }
}
