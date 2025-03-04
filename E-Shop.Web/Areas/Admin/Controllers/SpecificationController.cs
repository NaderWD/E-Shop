using E_Shop.Application.Services.SpecificationServices;
using E_Shop.Application.ViewModels.SpecificationViewModels;
using E_Shop.Domain.Models.ProductModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;

namespace E_Shop.Web.Areas.Admin.Controllers
{
    public class SpecificationController(ISpecificationService _service) : AdminBaseController
    {
        #region All Specifications
        [HttpGet]
        public async Task<IActionResult> AllSpecifications()
        {
            return View(await _service.GetAllSpecifications());
        }
        #endregion

        #region Specification Details
        [HttpGet]
        public async Task<ActionResult> SpecificationDetails(int productId)
        {
            return View(await _service.GetSpecificationDetailByProductId(productId));
        }
        #endregion

        #region Create Specification
        [HttpGet]
        public async Task<IActionResult> CreateSpecification()
        {
            SpecCreateVM specVM = new()
            {
                AllCategories = await _service.GetAllCategoriesList()
            };
            return View(specVM);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSpecification(SpecCreateVM createVM, List<int> CategoryIds)
        {
            if (!ModelState.IsValid)
            {
                SpecCreateVM specVM = new()
                {
                    AllCategories = await _service.GetAllCategoriesList()
                };
                return View(specVM);
            }
            createVM.SelectedCategoryIds = CategoryIds;
            await _service.CreateSpecification(createVM);
            createVM.NumberOfLinkedCategory = CategoryIds.Count;
            await _service.Save();
            return RedirectToAction(nameof(AllSpecifications));
        }
        #endregion

        #region Edit Specifications  
        [HttpGet]
        public async Task<IActionResult> EditSpecification(int specId)
        {
            return View(await _service.GetSpecificationForEdit(specId));
        }

        [HttpPost]
        public async Task<IActionResult> EditSpecification(int specId, SpecCreateVM createVM, List<int> CategoryIds)
        {
            if (specId != createVM.SpecId) return NotFound();
            if (!ModelState.IsValid)
            {
                createVM.AllCategories = await _service.GetAllCategoriesList();
                createVM.SelectedCategoryIds = CategoryIds;
                createVM.NumberOfLinkedCategory = CategoryIds.Count;
                return View(createVM);
            }
            createVM.SelectedCategoryIds = CategoryIds;
            await _service.UpdateSpecification(createVM);
            return RedirectToAction(nameof(AllSpecifications));
        }
        #endregion

        #region Delete Specifications
        [HttpPost]
        public async Task<IActionResult> DeleteSpecification(int specId)
        {
            await _service.DeleteSpecification(specId);
            return RedirectToAction(nameof(AllSpecifications));
        }
        #endregion                                                    

        #region Add Specification To Product
        [HttpGet]
        public async Task<IActionResult> AddToProduct(int productId)
        {
            AddSpecToProductVM specModel = new()
            {
                ProductId = productId,
                AvailabeSpecifications = await _service.GetAvailableSpecificationsToAddProduct(productId),
                SelectedSpecifications = [new()] // Start with one row
            };
            return View(specModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddToProduct(AddSpecToProductVM model)
        {
            if (!ModelState.IsValid) return RedirectToAction(nameof(AddToProduct), new { productId = model.ProductId });
            await _service.AddSpecificationToProduct(model);
            return RedirectToAction(nameof(SpecificationDetails), new { productId = model.ProductId });
        }

        [HttpPost]
        public async Task<IActionResult> AddRow(AddSpecToProductVM model)
        {
            // Re-populate available specifications
            model.AvailabeSpecifications = await _service.GetAvailableSpecificationsToAddProduct(model.ProductId);
            // Add a new empty row
            model.SelectedSpecifications.Add(new SelectedSpecificationsVM());
            return View(nameof(AddToProduct), model);
        }
        #endregion

        #region Edit For Product
        [HttpGet]
        public async Task<IActionResult> EditForProduct(int proSpecId)
        {
            return View(await _service.GetProSpecVMForEdit(proSpecId));
        }

        [HttpPost]
        public async Task<IActionResult> EditForProduct(ProSpecEditVM editVM)
        {
            if (!ModelState.IsValid) return RedirectToAction(nameof(EditForProduct), new { proSpecId = editVM.ProSpecId });
            await _service.UpdateProductSpecificationForProduct(editVM);
            return RedirectToAction(nameof(SpecificationDetails), new { productId = editVM.ProductId });
        }
        #endregion

        #region Delete For Product
        [HttpPost]
        public async Task<IActionResult> DeleteSpecificationForProduct(int proSpecId)
        {
            var proSpec = await _service.GetProductSpecificationById(proSpecId);
            await _service.DeleteProductSpecification(proSpecId);
            return RedirectToAction(nameof(SpecificationDetails), new { productId = proSpec.ProductId });
        }
        #endregion
    }
}
