using E_Shop.Application.ViewModels.SpecificationViewModels;
using E_Shop.Domain.Contracts.SpecificationCont;
using E_Shop.Domain.Models.SpecificationModels;

namespace E_Shop.Application.Services.SpecificationServices
{
    public class SpecificationService(ISpecificationRepository _specRepo) : ISpecificationService
    {
        public async Task AddCategoryToSpec(int categoryId, int specId)
        {
            var categorySpec = new CategorySpecification
            {
                CategoryId = categoryId,
                SpecificationId = specId
            };
            var checkSpec = await _specRepo.IsSpecificationExist(specId);
            if (checkSpec) await _specRepo.UpdateCategorySpec(categorySpec);
            if (!checkSpec) await _specRepo.CreateCategorySpec(categorySpec);
            await Save();
        }

        public async Task CreateSpec(SpecCreateVM createVM)
        {
            var Spec = _specRepo.CreateSpec(new Specification { Name = createVM.Name });
            foreach (var categoryId in createVM.SelectedCategoryIds)
                await AddCategoryToSpec(categoryId, Spec.Id);
            await Save();
        }

        public async Task AddSpecToProduct(ProductSpecAddVM specAddVM)
        {
            var product = await _specRepo.GetProductById(specAddVM.ProductId);
            var validSpecs = await _specRepo.GetSpecListByCategoryId(product.CategoryId);
            if (!validSpecs.Any(x => x.Id == specAddVM.SelectedSpecificationId))
                throw new InvalidOperationException("مشخصه ی مناسبی برای اضافه کردن به این محصول وجود ندارد");
            ProductSpecification productSpec = new()
            {
                ProductId = specAddVM.ProductId,
                SpecificationId = specAddVM.SelectedSpecificationId,
                Value = specAddVM.Value
            };
            await _specRepo.CreateProductSpec(productSpec);
            await Save();
        }

        public async Task<List<SpecListVM>> GetAllSpecs()
        {
            var spec = await _specRepo.GetAllSpecs();
            var specList = spec.Select(s => new SpecListVM
            {
                Id = s.Id,
                Name = s.Name,
                LinkedCategoriesCount = s.CategorySpecifications.Count
            }).ToList();
            return specList;
        }

        public async Task<List<Specification>> GetAvailableSpecs(int productId)
        {
            var product = await _specRepo.GetProductById(productId);
            if (product == null) return null;
            var categories = await _specRepo.GetSpecListByCategoryId(product.CategoryId);
            return categories;
        }

        public async Task<SpecDetailsVM> GetSpecDetails(int specId)
        {
            var spec = await _specRepo.GetSpecById(specId);
            var categories = await _specRepo.GetCategoryListBySpecId(specId);
            SpecDetailsVM specVM = new()
            {
                Id = spec.Id,
                Name = spec.Name,
                Categories = [.. categories.Select(c => c.Name)]
            };
            return specVM;
        }

        public async Task<SpecCreateVM> GetSpecByIdForEditProduct(int specId) // بپرس
        {
            var spec = await _specRepo.GetSpecById(specId);
            var availableCategories = await _specRepo.GetCategoryListBySpecId(specId);
            List<int> selectedCategoryIds = [.. spec.CategorySpecifications.Select(v => v.CategoryId)];
            SpecCreateVM editSpec = new()
            {
                Id = spec.Id,
                Name = spec.Name,
                SelectedCategoryIds = selectedCategoryIds,
                AvailableCategories = [.. availableCategories.Select(c => new CategorySelectionVM
                {
                    Id = c.Id,
                    Name = c.Name,
                    IsSelected = selectedCategoryIds.Contains(c.Id)
                })]
            };
            return editSpec;
        }

        public async Task<SpecCreateVM> GetSpecCreateModel()
        {
            var categories = await _specRepo.GetSubCategoryList();
            return new SpecCreateVM
            {
                AvailableCategories = [.. categories.Select(x => new CategorySelectionVM
                {
                    Id = x.Id,
                    Name = x.Name
                })]
            };
        }

        public async Task<List<Specification>> GetSpecListByProductId(int productId)
           => await _specRepo.GetSpecListByProductId(productId);

        public async Task<ProductSpecAddVM> GetProductSpecModel(int productId)
        {
            var specs = await GetAvailableSpecs(productId);
            return new ProductSpecAddVM
            {
                ProductId = productId,
                AvailabeSpecifications = [.. specs.Select(x => new SpecOptionVM
                {
                    Id = x.Id,
                    Name = x.Name
                })]
            };
        }

        public async Task<ProductSpecification> GetProductSpec(int productId, int specId)
            => await _specRepo.GetProductSpecBySpecId(specId);

        public async Task UpdateSpec(SpecCreateVM specUpdate)  //بپرس
        {
            var spec = await _specRepo.GetSpecById(specUpdate.Id);
            var categories = spec.CategorySpecifications.Select(x => x.CategoryId).ToList();
            spec.Name = specUpdate.Name;
            categories = specUpdate.SelectedCategoryIds;
            spec.LastModifiedDate = DateTime.Now;
            await _specRepo.UpdateSpec(spec);
            await Save();
        }

        public async Task UpdateProductSpec(UpdateProductSpecVM update)
        {
            var produstSpec = await _specRepo.GetProductSpecBySpecId(update.Id);
            _ = new UpdateProductSpecVM()
            {
                ProductId = produstSpec.ProductId,
                Value = produstSpec.Value,
                Specs = await GetSpecListByProductId(produstSpec.ProductId)
            };
            await _specRepo.UpdateProductSpec(produstSpec);
            await Save();
        }

        public async Task DeleteSpec(int specId)
        {
            var spec = await _specRepo.GetSpecById(specId) ?? throw new Exception("مشخصه وجود ندارد");
            spec.IsDelete = true;
            await _specRepo.UpdateSpec(spec);
            await Save();
        }

        public async Task DeleteCategorySpec(int specId)
        {
            var categorySpec = await _specRepo.GetCategorySpecBySpecId(specId) ?? throw new Exception();
            categorySpec.IsDelete = true;
            await _specRepo.UpdateCategorySpec(categorySpec);
            await Save();
        }

        public async Task DeleteProductSpec(int specId)
        {
            var productSpec = await _specRepo.GetProductSpecBySpecId(specId) ?? throw new Exception();
            productSpec.IsDelete = true;
            await _specRepo.UpdateProductSpec(productSpec);
            await Save();
        }

        public async Task Save() => await _specRepo.Save();
    }
}
