using E_Shop.Application.Services.Interfaces;
using E_Shop.Application.ViewModels;
using E_Shop.Application.ViewModels.ProductsViewModel;
using E_Shop.Domain.Contracts.Products;
using E_Shop.Domain.Models.Products;
using E_Shop.Infra.Data.Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Shop.Application.Services.Implementations
{
    public class ProductService(IProductsRepository productsRepository , IProductCategoriesRepository productCategoriesRepository) : IProductsService
    {

        #region Product CRUD
        public bool CreateProduct(CreateProductViewModel product)
        {
            Product model = new Product();

            model.Title = product.Title;
            model.Description = product.Description;
            model.Review = product.Review;
            model.ExpertReview = product.ExpertReview;
            model.Inventory = product.Inventory;
            model.ImageName = product.ImageName;
            model.Price = product.Price;
            model.CategoryId = product.CategoryId;

            return productsRepository.CreateProduct(model);
        }

        public bool DeleteProduct(int Id)
        {
            var product = productsRepository.GetById(Id);
            product.IsDelete = true;
            productsRepository.UpdateProduct(product);
            return true;
        }

        public bool UpdateProduct(UpdateProductViewModel product)
        {
            var model = productsRepository.GetById(product.Id);

            model.Title = product.Title;
            model.Description = product.Description;
            model.Review = product.Review;
            model.ExpertReview = product.ExpertReview;
            model.Inventory = product.Inventory;
            
            if (product.ImageName != null)
            {
                model.ImageName = product.ImageName;
            }
            
            model.Price = product.Price;
            model.CategoryId = product.CategoryId;

            return productsRepository.UpdateProduct(model);
        }
        #endregion Product CRUD
        
        public List<ProductViewModel> GetAll()
        {
            var products = productsRepository.GetAll().Where(p => p.IsDelete == false);
            List<ProductViewModel> model = new List<ProductViewModel>();

            foreach (var product in products)
            {
                model.Add(new ProductViewModel 
                {
                    Id = product.Id,
                    Title = product.Title,
                    Description = product.Description,
                    Review = product.Review,
                    ExpertReview = product.ExpertReview,
                    Inventory = product.Inventory,
                    ImageName = product.ImageName,
                    Price = product.Price,
                    CategoryId = product.CategoryId,
                    CategoryName = product.Category.Name,
                });
            }
            return model;
        }

        public ProductViewModel GetById(int Id)
        {
            var products = productsRepository.GetById(Id);
            ProductViewModel model = new ProductViewModel();

            model.Title = products.Title;
            model.Description = products.Description;
            model.Review = products.Review;
            model.ExpertReview = products.ExpertReview;
            model.Inventory = products.Inventory;
            model.ImageName = products.ImageName;
            model.Price = products.Price;
            model.CategoryId = products.CategoryId;
            
            return model;
        }

        public CreateProductViewModel GetProductCreateModel()
        {
            var productCategories = productCategoriesRepository.GetAll();

            CreateProductViewModel model = new CreateProductViewModel();
            model.Category = new List<ProductCategoryViewModel>();

            foreach (var item in productCategories)
            {
                model.Category.Add(new ProductCategoryViewModel
                {
                    Name = item.Name,
                    Id = item.Id,
                });
            }
            return model;
        }

        public UpdateProductViewModel GetProductUpdateModel(int Id)
        {
            var product = productsRepository.GetById(Id);

            UpdateProductViewModel model = new UpdateProductViewModel();
           
            model.Title = product.Title;
            model.Description = product.Description;
            model.Review = product.Review;
            model.ExpertReview = product.ExpertReview;
            model.Inventory = product.Inventory;
            model.ImageName = product.ImageName;
            model.Price = product.Price;
            model.CategoryId = product.CategoryId;
            model.Id = product.Id;
            model.Price = product.Price;


            model.Category = new List<ProductCategoryViewModel>();
            var selectlist = GetSelectItems();
            foreach (var item in selectlist)
            {
                model.Category.Add(new ProductCategoryViewModel
                {
                    Name = item.Name,
                    Id = item.Id,
                });
            }
            return model;
        }

        public List<SelectListitem> GetSelectItems()
        {
            var category = productsRepository.GetAll();
            List<SelectListitem> selectListitems = new List<SelectListitem>();

            foreach (var item in category)
            {
                selectListitems.Add(new SelectListitem
                {
                    Name = item.Category.Name,
                    Id = item.CategoryId,
                });

            }
            return selectListitems;
        }
    }
}
