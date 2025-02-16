using E_Shop.Application.Services.Interfaces;
using E_Shop.Application.ViewModels;
using E_Shop.Domain.Models;
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
        public bool CreateproductCategory(CreatProductCategoryViewModel model)
        {
            if (productCategoriesRepository.GetAll().Any(c => c.Name == model.Name)) { return false; }
            else
            {
                var category = new ProductCategories();

                category.Name = model.Name;
                category.ParentId = model.ParentId;
                category.CreateDate = DateTime.Now;
                return productCategoriesRepository.CreateProductCategory(category);
            }

        }

        public List<ProductCategoriesViewModel> GetAll()
        {
            var category = productCategoriesRepository.GetAll();
            List<ProductCategoriesViewModel> productCategories = new List<ProductCategoriesViewModel>();

            foreach (var categoryItem in category)
            {
                if (categoryItem.ParentId != null)
                {
                    productCategories.Add(new ProductCategoriesViewModel
                    {
                        Name = categoryItem.Name,
                        Id = categoryItem.Id,
                        ParentId = categoryItem.ParentId,
                        ParentName = categoryItem.Parent.Name,

                    });
                }
                else
                {
                    productCategories.Add(new ProductCategoriesViewModel
                    {
                        Name = categoryItem.Name,
                        Id = categoryItem.Id,
                    });
                }
            }
            return productCategories;
        }

        public CreatProductCategoryViewModel GetCreatModel()
        {
            var category = productCategoriesRepository.GetAll();

            CreatProductCategoryViewModel productCategories = new CreatProductCategoryViewModel();
            productCategories.ParentList = new List<SelectListitem>();
            if (category != null)
            {
                foreach (var item in category.Where(c => c.ParentId == null))
                {
                    productCategories.ParentList.Add(new SelectListitem
                    {
                        Name = item.Name,
                        Id = item.Id,
                    });

                }
                return productCategories;
            }
            else 
                return new CreatProductCategoryViewModel();
        }
    }
}
