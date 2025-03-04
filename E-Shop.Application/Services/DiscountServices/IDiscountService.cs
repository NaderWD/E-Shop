using E_Shop.Application.ViewModels.DiscountsViewModels;
using E_Shop.Domain.Models.DiscountsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Shop.Application.Services.DiscountServices
{
    public interface IDiscountService
    {
        public List<DiscountViewModel> GetAll();
        public DiscountViewModel GetById(int Id);
        public bool CreateDiscount(DiscountViewModel discount);
        public bool UpdateDiscount(UpdateDiscountViewModel discount);
    }
}
