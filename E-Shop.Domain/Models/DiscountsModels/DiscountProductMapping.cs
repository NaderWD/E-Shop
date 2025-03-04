using E_Shop.Domain.Models.ProductModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Shop.Domain.Models.DiscountsModels
{
    public class DiscountProductMapping : BaseModel
    {
        public int ProductId { get; set; }
        public int DiscountId { get; set; }
        public bool IsAppliedToAll { get; set; }


        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; }


        [ForeignKey(nameof(DiscountId))]
        public Discount Discount { get; set; }
    }
}
