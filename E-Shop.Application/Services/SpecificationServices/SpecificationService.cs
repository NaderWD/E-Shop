using E_Shop.Application.ViewModels.ProductsViewModel;
using E_Shop.Application.ViewModels.SpecificationViewModels;
using E_Shop.Domain.Contracts.ProductCont;
using E_Shop.Domain.Contracts.SpecificationCont;
using E_Shop.Domain.Models.SpecificationModels;

namespace E_Shop.Application.Services.SpecificationServices
{
    public class SpecificationService(ISpecificationRepository _repository,
IProductCategoriesRepository _categoryRepo, IProductsRepository _productsRepo) : ISpecificationService
    {                                                                          
        public async Task CreateSpecification(SpecificationCreateVM createVM)
        {
            var createdSpec = _repository.Create(new Specification { Name = createVM.Name });
            foreach (var categoryId in createVM.SelectedCategoryIds)
                await AddCategoryToSpecification(categoryId, createdSpec.Id);
            await Save();
        }

        public async Task AddCategoryToSpecification(int categoryId, int specId)
        {
            var categorySpec = new CategorySpecification
            {
                CategoryId = categoryId,
                SpecificationId = specId
            };
            await _repository.CreateCategorySpecification(categorySpec);
        }

        public async Task AddSpecificationToProduct(ProductSpecificationAddVM specificationAddVM)
        {
            var product = await _productsRepo.GetProductById(specificationAddVM.ProductId);
            var validSpecs = await _repository.GetSpecificationsByCategoryId(product.CategoryId);
            if (!validSpecs.Any(x => x.Id == specificationAddVM.SelectedSpecificationId))
                throw new InvalidOperationException("مشخصه ای برای اضافه کردن به این محصول وجود ندارد");
            ProductSpecification productSpec = new()
            {
                ProductId = specificationAddVM.ProductId,
                SpecificationId = specificationAddVM.SelectedSpecificationId,
                Value = specificationAddVM.Value
            };
            await _repository.CreateProductSpecification(productSpec);
        }

        public async Task<SpecificationDetailsVM> GetSpecificationsDetails(int specId)
        {
            var spec = await _repository.GetSpecificationById(specId);
            var categories = await _repository.GetCategoriesForSpecification(specId);
            SpecificationDetailsVM specVM = new()
            {
                Id = spec.Id,
                Name = spec.Name,
                Categories = [.. categories.Select(c => c.Name)]
            };
            return specVM;
        }

        public async Task<SpecificationCreateVM> GetSpecificationCreateModel()
        {
            var categories = await _categoryRepo.GetAllSubCategories();
            return new SpecificationCreateVM
            {
                AvailableCategories = [.. categories.Select(x => new CategorySelectionVM
                {
                    Id = x.Id,
                    Name = x.Name
                })]
            };
        }

        public async Task<ProductSpecificationAddVM> GetProductSpecificationModel(int productId)
        {
            var specs = await GetAvailableSpecifications(productId);
            return new ProductSpecificationAddVM
            {
                ProductId = productId,
                AvailabeSpecifications = [.. specs.Select(x => new SpecificationOptionVM
                {
                    Id = x.Id,
                    Name = x.Name
                })]
            };
        }

        public async Task<List<Specification>> GetAvailableSpecifications(int productId)
        {
            var product = _productsRepo.GetProductById(productId);
            if (product == null) return null;
            var categories = await _repository.GetSpecificationsByCategoryId(product.Id);
            return categories;
        }

        public Task<List<ProductCategoriesViewModel>> GetCategoriesForSpecification(int specId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Specification>> GetSpecificationsByCategoryId(int categoryId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Specification>> GetSpecificationsForProduct(int productId)
        {
            throw new NotImplementedException();
        }

        public Task RemoveProductSpecification(int productId, int specId)
        {
            throw new NotImplementedException();
        }

        public async Task Save()
        {
            await _repository.Save();
        }

    }
}
