using E_Shop.Domain.Models.DiscountsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Shop.Domain.Contracts.DiscountCont
{
    public interface IDiscountRepository
    {
        List<Discount> GetAll();
        Discount GetById(int Id);
        bool CreateDiscount(Discount discount);
        bool UpdateDiscount(Discount discount);
        
        
    }
}
