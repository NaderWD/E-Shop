using E_Shop.Application.ViewModels.ColorViewModels;
using E_Shop.Application.ViewModels.ProductsViewModel;
using E_Shop.Application.ViewModels.SpecificationViewModels;
using E_Shop.Domain.Contracts.ProductCont;
using E_Shop.Domain.Models.ProductModels;

namespace E_Shop.Application.Services.ProductServices
{
    public class ProductService(IProductsRepository productsRepository, IProductCategoriesRepository productCategoriesRepository) : IProductsService
    {

        #region Product CRUD
        public bool CreateProduct(CreateProductViewModel product)
        {
            Product model = new()
            {
                Title = product.Title,
                Description = product.Description,
                Review = product.Review,
                ExpertReview = product.ExpertReview,
                Inventory = product.Inventory,
                ImageName = product.ImageName,
                Price = product.Price,
                CategoryId = product.CategoryId
            };

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



        public ProductViewModel GetById(int Id)
        {
            var products = productsRepository.GetById(Id);
            ProductViewModel model = new()
            {
                Title = products.Title,
                Description = products.Description,
                Review = products.Review,
                ExpertReview = products.ExpertReview,
                Inventory = products.Inventory,
                ImageName = products.ImageName,
                Price = products.Price,
                CategoryId = products.CategoryId
            };

            return model;
        }


        public CreateProductViewModel GetProductCreateModel()
        {
            var productCategories = productCategoriesRepository.GetAll();

            CreateProductViewModel model = new()
            {
                Category = []
            };

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

            UpdateProductViewModel model = new()
            {
                Title = product.Title,
                Description = product.Description,
                Review = product.Review,
                ExpertReview = product.ExpertReview,
                Inventory = product.Inventory,
                ImageName = product.ImageName,
                Price = product.Price,
                CategoryId = product.CategoryId,
                Id = product.Id
            };
            model.Price = product.Price;


            model.Category = [];
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
            var category = productCategoriesRepository.GetAll();
            List<SelectListitem> selectListitems = [];

            foreach (var item in category)
            {
                selectListitems.Add(new SelectListitem
                {
                    Name = item.Name,
                    Id = item.Id,
                });

            }
            return selectListitems;
        }


        public FilterProductViewModel Filter(FilterProductViewModel filter)
        {
            var query = productsRepository.Filter();

            #region Filter

            if (filter.Title != null)
            {
                query = query.Where(q => q.Title.Contains(filter.Title));
            }

            if (filter.Inventory != null)
            {
                query = query.Where(q => q.Inventory == filter.Inventory);
            }

            if (filter.CategoryId != null)
            {
                query = query.Where(q => q.CategoryId == filter.CategoryId);
            }

            #endregion

            var productCategories = GetSelectItems();
            filter.Category = new List<ProductCategoryViewModel>();
            foreach (var item in productCategories)
            {
                filter.Category.Add(new ProductCategoryViewModel
                {
                    Name = item.Name,
                    Id = item.Id,
                });
            }

            var products = query.Select(q => new ProductViewModel
            {
                Id = q.Id,
                CategoryName = q.Category.Name,
                Title = q.Title,
                Price = q.Price,
                Inventory = q.Inventory,
            });

            filter.ToPaged(products);

            return filter;
        }

        public ProductArchiveViewModel ArchiveFilter(ProductArchiveViewModel filter)
        {
            var query = productsRepository.ArchiveFilter(filter.CategoryId);

            #region Filter
            if (filter.Title != null)
            {
                query = query.Where(q => q.Title.Contains(filter.Title));
            }

            if (filter.Inventory == true)
            {
                query = query.Where(q => q.Inventory > 0);
            }
            #endregion

            #region Sorting
            switch (filter.SortBy)
            {
                case Domain.Enum.ProductEnums.MostExpensive:
                    query = filter.SortOrder == Domain.Enum.SortOrder.Ascending
                    ? query.OrderBy(p => p.Price)
                    : query.OrderByDescending(p => p.Price);
                    break;
                case Domain.Enum.ProductEnums.MostRecent:
                    query = query.OrderByDescending(p => p.CreateDate);
                    break;
                default:
                    query = query.OrderBy(p => p.Id);
                    break;
            }
            #endregion

            var productsQuery = query.Select(q => new ProductViewModel
            {
                Id = q.Id,
                CategoryName = q.Category.Name,
                Title = q.Title,
                Price = q.Price,
                Inventory = q.Inventory,
                ImageName = q.ImageName,
                Colors = q.Color.Select(color => new ColorViewModel()
                {
                    Id = color.ColorId,
                    Name = color.Color.Name,
                    Code = color.Color.Code
                }).ToList(),


            });

            filter.Category = new ProductCategoriesViewModel();
            filter.Category.Name = query.Select(q => q.Category.Name).FirstOrDefault();
            filter.Category.ParentName = query.Select(q => q.Category.Parent.Name).FirstOrDefault();
            filter.Category.ParentId = query.Select(q => q.Category.Parent.Id).FirstOrDefault();

            filter.ToPaged(productsQuery);
            return filter;


        }

        public ProductViewModel GetByIdForDetails(int productId, int colorId)
        {
            var product = productsRepository.GetByIdForDetails(productId);

            product.Category = new ProductCategories();

            ProductViewModel model = new()
            {
                Id = product.Id,
                Title = product.Title,
                Description = product.Description,
                Review = product.Review,
                ExpertReview = product.ExpertReview,
                Inventory = product.Inventory,
                ImageName = product.ImageName,
                CategoryId = product.CategoryId,
                CategoryName = product.Category.Name,
            };

            model.Colors = [];

            foreach (var item in product.Color)
            {

                model.Colors.Add(new ColorViewModel
                {
                    Code = item.Color.Code,
                    Name = item.Color.Name,
                    Id = item.ColorId,
                    IsDefault = item.IsDefault,
                });
            }

            if (colorId != 0)
            {
                model.Price = product.Price + product.Color.Where(c => c.ColorId == colorId).FirstOrDefault().Price;
            }
            else
            {
                model.Price = product.Price + product.Color.Where(c => c.IsDefault == true).FirstOrDefault().Price;
            }

            return model;
        }

        public List<ProductViewModel> GetByCategoryId(int Id)
        {
            var products = productsRepository.GetByCategoryId(Id);

            List<ProductViewModel> model = new List<ProductViewModel>();

            foreach (var item in products)
            {
                model.Add(new ProductViewModel
                    {
                    Id = item.Id,
                    Title = item.Title,
                    Description = item.Description,
                    Review = item.Review,
                    ExpertReview = item.ExpertReview,
                    Inventory = item.Inventory,
                    ImageName = item.ImageName,
                    Price = item.Price,
                    CategoryId = item.CategoryId,
                    
                });
                
            }
            

            return model;
        }
    }
}
