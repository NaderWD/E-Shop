using E_Shop.Application.ViewModels.SpecificationViewModels;
using E_Shop.Domain.Contracts.SpecificationCont;
using E_Shop.Domain.Models.ProductModels;
using E_Shop.Domain.Models.SpecificationModels;
using Microsoft.AspNetCore.Mvc.Rendering;

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
            await _repository.UpdateSpec(spec);
            await UpdateCategorySpecifications(spec.Id, specVM.SelectedCategoryIds);
            await Save();
        }

        public async Task DeleteSpecification(int specId)
        {
            var spec = await _repository.GetSpecById(specId);
            await DeleteCategorySpecification(spec.CategorySpecificationId);
            await DeleteProductSpecification(spec.ProductSpecificationId);
            await _repository.DeleteSpecification(specId);
            await Save();
        }

        public async Task Save() => await _repository.Save();
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
                if (!selectedCategoryIds.Contains(categorySpec.CategoryId))
                {
                    await DeleteCategorySpecification(categorySpec.Id);
                }
            foreach (var categoryId in selectedCategoryIds)
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
        }

        public async Task DeleteCategorySpecification(int catSpecId)
        {
            await _repository.DeleteCategorySpec(catSpecId);
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
        public async Task AddSpecificationToProduct(AddSpecToProductVM addSpecVM)
        {
            var product = await _repository.GetProductById(addSpecVM.ProductId);
            addSpecVM.AvailabeSpecifications = await GetAvailableSpecificationsToAddProduct(product.Id);
            foreach (var specVM in addSpecVM.SelectedSpecifications.Where(s => s.IsSelected))
            {
                ProductSpecification proSpec = new()
                {
                    ProductId = product.Id,
                    SpecificationId = specVM.SelectedSpecId,
                    Value = specVM.SelectedSpecValue,
                    CreateDate = DateTime.Now,
                    LastModifiedDate = DateTime.Now
                };
                await _repository.CreateProductSpec(proSpec);
                await Save();
            }
            await UpdateProductSpecifications(product.Id, [.. addSpecVM.SelectedSpecifications.Select(s => s.SelectedSpecId)]);
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

        public async Task<ProSpecEditVM> GetProSpecVMForEdit(int proSpecId)
        {
            var proSpec = await _repository.GetProductSpecById(proSpecId) ?? throw new Exception("مشخصه ی مورد نظر یافت نشد");
            var allSpecs = await _repository.GetAllSpecs();
            return new ProSpecEditVM
            {
                ProSpecId = proSpec.Id,
                ProductId = proSpec.ProductId,
                SelectedSpecIds = [proSpec.SpecificationId],
                Value = proSpec.Value,
                AvailableSpecifications = [.. allSpecs.Select(s => new SelectListItem
                {
                    Value = s.Id.ToString(),
                    Text = s.Name
                })]
            };
        }

        // ask if its right     its for test 
        public async Task<ProSpecDetailsFinalVM> GetSpecificationDetailByProductId(int productId)
        {
            var product = await _repository.GetProductById(productId);
            var proSpecList = await _repository.GetProductSpecListByProductId(productId);
            return new ProSpecDetailsFinalVM
            {
                ProductId = product.Id,
                ProSpecVM = [.. proSpecList.Select(ps => new ProductSpecDetailVM
                {
                    ProSpecId = ps.Id,
                    SpecName = ps.Specification.Name,
                    Value = ps.Value

                })]
            };
        }

        public async Task UpdateProductSpecifications(int productId, List<int> selectedSpecIds)
        {
            var productSpecList = await _repository.GetProductSpecListByProductId(productId);
            foreach (var productSpec in productSpecList)
                if (!selectedSpecIds.Contains(productSpec.SpecificationId))
                {
                    await DeleteProductSpecification(productSpec.Id);
                }
            foreach (var specId in selectedSpecIds)
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
        }

        public async Task UpdateProductSpecificationForProduct(ProSpecEditVM ProSpecVM)
        {
            var proSpec = await _repository.GetProductSpecById(ProSpecVM.ProSpecId) ?? throw new Exception("مشخصه ی مورد نظر یافت نشد");
            proSpec.Value = ProSpecVM.Value;
            proSpec.SpecificationId = ProSpecVM.SelectedSpecIds.FirstOrDefault();
            proSpec.LastModifiedDate = DateTime.Now;
            await _repository.UpdateProductSpec(proSpec);
            await UpdateProductSpecifications(ProSpecVM.ProductId, [.. ProSpecVM.SelectedSpecIds]);
            await Save();
        }

        public async Task DeleteProductSpecification(int proSpecId)
        {
            await _repository.DeleteProductSpec(proSpecId);
            await Save();
        }
        #endregion
    }
}