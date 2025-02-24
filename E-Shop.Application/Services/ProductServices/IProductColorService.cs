using E_Shop.Application.ViewModels.ColorViewModels;
using E_Shop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Shop.Application.Services.Interfaces
{
    public interface IProductColorService
    {
        public List<AddColorToProductViewModel> GetAllColorForProduct(int productId);
        bool AddMapping(AddColorToProductViewModel model);
        bool RemoveColor(int Id);
        
    }
}
