using E_Shop.Application.Services.Interfaces;
using E_Shop.Application.ViewModels;
using E_Shop.Domain.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Shop.Application.Services.Implementations
{
    public class ProductCategoriesService(IProductCategoriesRepository productCategoriesRepository) : IProductCategoriesService
    {
        public List<ProductCategoriesViewModel> GetAll()
        {
            var category = productCategoriesRepository.GetAll();
            List<ProductCategoriesViewModel> productCategories = new List<ProductCategoriesViewModel>();

            foreach (var categoryItem in category)
            {
                productCategories.Add(new ProductCategoriesViewModel
                {
                    Name = categoryItem.Name,
                    Id = categoryItem.Id,
                    ParentName = categoryItem.Parent.Name,
                    
                });
            }
            return productCategories;
        }
    }
}
