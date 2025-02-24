using E_Shop.Application.Services.Interfaces;
using E_Shop.Application.ViewModels;
using E_Shop.Domain.Contracts.ProductCont;
using E_Shop.Domain.Models.ProductModels;

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

        public List<SelectListitem> GetSelectItems()
        {
            var category = productCategoriesRepository.GetAll();
            List<SelectListitem> selectListitems = new List<SelectListitem>();

            foreach (var item in category.Where(c => c.ParentId == null))
            {
                selectListitems.Add(new SelectListitem
                {
                    Name = item.Name,
                    Id = item.Id,
                });

            }
            return selectListitems;
        }

        public CreatProductCategoryViewModel GetUpdateModel(int Id)
        {
            var category = productCategoriesRepository.GetProductCategoryById(Id);


            CreatProductCategoryViewModel productCategories = new CreatProductCategoryViewModel();

            productCategories.ParentList = new List<SelectListitem>();
            var selectitems = GetSelectItems();

            if (category != null)
            {
                productCategories.Name = category.Name;
                productCategories.Id = category.Id;
                if (category.Parent != null)
                {
                    productCategories.ParentName = category.Parent.Name;
                }


                foreach (var item in selectitems)
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

        public bool UpdateproductCategory(CreatProductCategoryViewModel model, bool IsDuplicatedCheck)
        {
            if (IsDuplicatedCheck)
            {
                if (productCategoriesRepository.GetAll().Any(c => c.Name == model.Name)) { return false; }
                else
                {
                    var category = productCategoriesRepository.GetProductCategoryById(model.Id);

                    category.Name = model.Name;
                    category.ParentId = model.ParentId;
                    category.LastModifiedDate = DateTime.Now;
                    var result = productCategoriesRepository.UpdateProductCategory(category);
                    productCategoriesRepository.Save();
                    return result;
                }
            }
            else
            {
                var category = productCategoriesRepository.GetProductCategoryById(model.Id);

                category.Name = model.Name;
                category.ParentId = model.ParentId;
                category.LastModifiedDate = DateTime.Now;
                var result = productCategoriesRepository.UpdateProductCategory(category);
                productCategoriesRepository.Save();
                return result;
            }
        }
        public bool DeleteproductCategory(int Id)
        {
            var subcategories = productCategoriesRepository.GetAll().Where(c => c.ParentId == Id);
            foreach (var subcategory in subcategories)
            {
                subcategory.IsDelete = true;
                productCategoriesRepository.UpdateProductCategory(subcategory);
            }
            var category = productCategoriesRepository.GetProductCategoryById(Id);
            category.IsDelete = true;
            productCategoriesRepository.UpdateProductCategory(category);
            productCategoriesRepository.Save();

            return true;
        }
        public bool CreateproductCategory(CreatProductCategoryViewModel model)
        {
            if (productCategoriesRepository.GetAll().Any(c => c.Name == model.Name)) { return false; }
            else
            {
                var category = new ProductCategories
                {
                    Name = model.Name,
                    ParentId = model.ParentId,
                    CreateDate = DateTime.Now
                };
                return productCategoriesRepository.CreateProductCategory(category);
            }

        }

        public ProductCategoriesViewModel GetProductCategoryById(int Id)
        {
            var category = productCategoriesRepository.GetProductCategoryById(Id);
            ProductCategoriesViewModel model = new ProductCategoriesViewModel();

            model.Name = category.Name;
            model.ParentId = category.ParentId;
            model.CreateDate = DateTime.Now;
            return model;

        }
    }
}
