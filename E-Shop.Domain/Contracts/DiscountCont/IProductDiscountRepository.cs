using E_Shop.Domain.Models.DiscountsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Shop.Domain.Contracts.DiscountCont
{
    public interface IProductDiscountRepository
    {

        List<DiscountProductMapping> GetDiscountForProduct(int productId);
        int GetProductPrice(int productId);

        List<DiscountProductMapping> GetAllForProduct(int productId);
        List<DiscountProductMapping> GetAll();
        DiscountProductMapping GetLastPublicDiscount();

        bool AddMapping(DiscountProductMapping model);
        bool UpdateMapping(DiscountProductMapping model);
        DiscountProductMapping GetByID(int discountId , int productId);
        DiscountProductMapping GetByMappingID(int mappingId);
    }
}
