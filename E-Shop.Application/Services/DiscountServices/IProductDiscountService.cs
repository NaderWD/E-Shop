using E_Shop.Application.ViewModels.DiscountsViewModels;
using E_Shop.Application.ViewModels.ProductsViewModel;
using E_Shop.Domain.Models.DiscountsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Shop.Application.Services.DiscountServices
{
    public interface IProductDiscountService
    {
        public int ApplyDiscount(List<DiscountsViewModel> query, int price);
        public int ApplypublicDiscount(DiscountProductMapping discount, int price);
        List<DiscountViewModel> GetDiscountForProduct(int productId);
        
        List<DiscountViewModel> GetAllForProduct(int productId);

        DiscountViewModel GetById(int discountId, int productId);
        UpdateMappingViewModel GetByMappingID(int mappingId);

        List<DiscountsSelectViewModel> GetAllSelect();
        bool AddMapping(AddMappingViewModel mapping);
        bool UpdateMapping(UpdateMappingViewModel mapping);
        bool DeleteMapping(int mappingId);

    }
}
