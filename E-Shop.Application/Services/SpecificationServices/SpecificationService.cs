using E_Shop.Application.ViewModels.SpecificationViewModels;
using E_Shop.Domain.Contracts.SpecificationCont;
using E_Shop.Domain.Models.ProductModels;
using E_Shop.Domain.Models.SpecificationModels;

namespace E_Shop.Application.Services.SpecificationServices
{
    public class SpecificationService(ISpecificationRepository _repository) : ISpecificationService
    {

        #region Specification
        public async Task CreateSpecification(SpecCreateVM specVM)
        {
            var spec = new Specification { Name = specVM.Name };
            await _repository.CreateSpec(spec);
            await Save();
            specVM.AllCategories = await _repository.GetAllCategoryList();
            foreach (var categoryId in specVM.SelectedCategoryIds)
                if (!await CheckCategorySpecExist(categoryId))
                    await CreateCategorySpecification(new CategorySpecVM
                    {
                        SpecId = spec.Id,
                        CategoryId = categoryId
                    });
            await UpdateCategorySpecifications(spec.Id, specVM.SelectedCategoryIds);
            await Save();
        }

        public async Task<List<SpecListVM>> GetAllSpecifications()
        {
            var specs = await _repository.GetAllSpecs();
            List<SpecListVM> specListVM = [];
            foreach (var spec in specs)
            {
                specListVM.Add(new SpecListVM
                {
                    SpecId = spec.Id,
                    Name = spec.Name,
                    LinkedCategoriesCount = (await _repository.GetCategoryListBySpecId(spec.Id)).Count
                });
            }
            return specListVM;
        }

        public async Task<SpecDetailsVM> GetSpecificationDetails(int specId)
        {
            var spec = await _repository.GetSpecById(specId);
            var categoriesNames = (await _repository.GetCategoryListBySpecId(specId)).Select(c => c.Name).ToList();
            SpecDetailsVM specDetail = new()
            {
                SpecId = spec.Id,
                Name = spec.Name,
                LinkedCategories = categoriesNames
            };
            return specDetail;
        }

        public async Task<SpecCreateVM> GetSpecificationForEdit(int specId)
        {
            var spec = await _repository.GetSpecById(specId);
            var Allcategories = await _repository.GetAllCategoryList();
            var selectedCategoriesIds = (await _repository.GetCategorySpecListBySpecId(spec.Id)).Select(c => c.CategoryId).ToList();
            SpecCreateVM specEdit = new()
            {
                SpecId = spec.Id,
                Name = spec.Name,
                SelectedCategoryIds = selectedCategoriesIds,
                AllCategories = Allcategories,
                NumberOfLinkedCategory = selectedCategoriesIds.Count
            };
            return specEdit;
        }

        public async Task UpdateSpecification(SpecCreateVM specVM)
        {
            var spec = await _repository.GetSpecById(specVM.SpecId);
            spec.Name = specVM.Name;
            await UpdateCategorySpecifications(spec.Id, specVM.SelectedCategoryIds);
            await _repository.UpdateSpec(spec);
            await Save();
        }

        public async Task DeleteSpecification(int specId)
        {
            var spec = await _repository.GetSpecById(specId);
            await DeleteCategorySpecification(spec.Id);
            await DeleteProductSpecification(spec.Id);
            spec.IsDelete = true;
            await Save();
        }

        public async Task Save()
        {
            await _repository.Save();
        }
        #endregion



        #region CategorySpecification
        public async Task CreateCategorySpecification(CategorySpecVM categorySpec)
        {
            CategorySpecification categorySpecification = new()
            {
                CategoryId = categorySpec.CategoryId,
                SpecificationId = categorySpec.SpecId,
                CreateDate = DateTime.Now,
                LastModifiedDate = DateTime.Now
            };
            await _repository.CreateCategorySpec(categorySpecification);
            await Save();
        }

        public async Task<List<ProductCategories>> GetAllCategoriesList()
        {
            return await _repository.GetAllCategoryList();
        }

        public async Task UpdateCategorySpecifications(int specId, List<int> selectedCategoryIds)
        {
            var categorySpecList = await _repository.GetCategorySpecListBySpecId(specId);
            foreach (var categorySpec in categorySpecList)
            {
                if (!selectedCategoryIds.Contains(categorySpec.CategoryId))
                {
                    categorySpec.IsDelete = true;
                    await _repository.UpdateCategorySpec(categorySpec);
                }
            }
            foreach (var categoryId in selectedCategoryIds)
            {
                if (!await CheckCategorySpecExist(categoryId))
                {
                    CategorySpecification catSpec = new()
                    {
                        CategoryId = categoryId,
                        SpecificationId = specId,
                        LastModifiedDate = DateTime.Now,
                        CreateDate = DateTime.Now,
                        IsDelete = false
                    };
                    await _repository.CreateCategorySpec(catSpec);
                }
                else
                {
                    var existingCategorySpec = await _repository.GetCategorySpecByCategoryId(categoryId);
                    if (existingCategorySpec.IsDelete)
                    {
                        existingCategorySpec.IsDelete = false;
                        await _repository.UpdateCategorySpec(existingCategorySpec);
                    }
                }

            }
        }

        public async Task DeleteCategorySpecification(int SpecId)
        {
            var catSpecs = await _repository.GetCategorySpecListBySpecId(SpecId);
            foreach (var catSpec in catSpecs)
            {
                catSpec.IsDelete = true;
                await _repository.UpdateCategorySpec(catSpec);
            }
            await Save();
        }

        public async Task<bool> CheckCategorySpecExist(int categoryId)
        {
            if (!await _repository.CheckCategorySpecExist(categoryId))
                return false;
            return true;
        }
        #endregion                       



        #region ProductSpecification
        public async Task CreateProductSpecification(ProductSpecVM productSpec)
        {
            ProductSpecification proSpec = new()
            {
                ProductId = productSpec.ProductId,
                SpecificationId = productSpec.SpecId,
                Value = productSpec.Value,
                CreateDate = DateTime.Now,
                LastModifiedDate = DateTime.Now
            };
            await _repository.CreateProductSpec(proSpec);
            await Save();
        }

        public async Task<List<SpecVM>> GetAvailableSpecificationsToAddProduct(int productId)
        {
            var product = await _repository.GetProductById(productId);
            var specs = await _repository.GetSpecListByCategoryId(product.CategoryId);
            List<SpecVM> listSpecVM = [];
            foreach (var spec in specs) listSpecVM.Add(new SpecVM
            {
                SpecId = spec.Id,
                Name = spec.Name,
                CategorySpecId = spec.CategorySpecificationId,
                ProductSpecId = spec.ProductSpecificationId
            });
            return listSpecVM;
        }

        public async Task AddSpecificationToProduct(AddSpecToProductVM addSpecVM)
        {
            var product = await _repository.GetProductById(addSpecVM.ProductId);
            addSpecVM.AvailabeSpecifications = await GetAvailableSpecificationsToAddProduct(product.Id);
            foreach (var specId in addSpecVM.SelectedSpecificationIds)
            {
                ProductSpecification proSpec = new()
                {
                    ProductId = product.Id,
                    SpecificationId = specId,
                    Value = addSpecVM.Value,
                    CreateDate = DateTime.Now,
                    LastModifiedDate = DateTime.Now
                };
                await _repository.CreateProductSpec(proSpec);
            }
            await Save();
        }

        public async Task<List<SpecVM>> GetSpecificationListByProductId(int productId)
        {
            var specs = await _repository.GetSpecListByProductId(productId);
            List<SpecVM> listSpecVM = [];
            foreach (var spec in specs) listSpecVM.Add(new SpecVM
            {
                SpecId = spec.Id,
                Name = spec.Name,
                CategorySpecId = spec.CategorySpecificationId,
                ProductSpecId = spec.ProductSpecificationId
            });
            return listSpecVM;
        }

        public async Task UpdateProductSpecifications(int productId, List<int> selectedSpecIds)
        {
            var productSpecList = await _repository.GetProductSpecListByProductId(productId);
            foreach (var productSpec in productSpecList)
            {
                if (!selectedSpecIds.Contains(productSpec.SpecificationId))
                {
                    productSpec.IsDelete = true;
                    await _repository.UpdateProductSpec(productSpec);
                }
            }
            foreach (var specId in selectedSpecIds)
            {
                if (!await CheckProductSpecExist(specId))
                {
                    ProductSpecification proSpec = new()
                    {
                        ProductId = productId,
                        SpecificationId = specId,
                        LastModifiedDate = DateTime.Now,
                        CreateDate = DateTime.Now,
                        IsDelete = false
                    };
                    await _repository.CreateProductSpec(proSpec);
                }
                else
                {
                    var existingProductSpec = await _repository.GetProductSpecBySpecId(specId);
                    if (existingProductSpec.IsDelete)
                    {
                        existingProductSpec.IsDelete = false;
                        await _repository.UpdateProductSpec(existingProductSpec);
                    }
                }

            }
        }

        public async Task DeleteProductSpecification(int specId)
        {
            var proSpecs = await _repository.GetProductSpecListBySpecId(specId);
            foreach (var proSpec in proSpecs)
            {
                proSpec.IsDelete = true;
                await _repository.UpdateProductSpec(proSpec);
            }
            await Save();
        }

        public async Task<bool> CheckProductSpecExist(int specId)
        {
            var check = await _repository.CheckProductSpecExist(specId);
            if (!check) return false;
            return true;
        }
        #endregion

    }
}