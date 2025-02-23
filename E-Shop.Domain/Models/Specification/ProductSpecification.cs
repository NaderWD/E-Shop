using E_Shop.Domain.Models.Common;
using E_Shop.Domain.Models.Products;

namespace E_Shop.Domain.Models.Specification
{
    public class ProductSpecification : BaseModel
    {
        public int ProductId { get; set; }
        public int SpecificationId { get; set; }
        public string Value { get; set; }


        public Product? Product { get; set; }
        public Specification? Specification { get; set; }
    }
}
