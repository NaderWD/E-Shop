using E_Shop.Domain.Models.Common;
using E_Shop.Domain.Models.Products;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Shop.Domain.Models.Color
{
    public  class ProductColorMapping : BaseModel
    {
        public int ProductId { get; set; }
        public int ColorId { get; set; }
        public int Price { get; set; }

        public bool IsDefault { get; set; }

        [ForeignKey(name:"ProductId")]
        public Product Product { get; set; }

        [ForeignKey(name:"ColorId")]
        public ColorModel Color { get; set; }


    }
}
