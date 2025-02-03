using E_Shop.Domain.Models.Common;

namespace E_Shop.Domain.Models
{
    public class Order : BaseModel
    {
        public Product? Product { get; set; }
    }
}
