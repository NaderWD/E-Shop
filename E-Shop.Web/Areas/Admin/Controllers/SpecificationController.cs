using E_Shop.Application.Services.SpecificationServices;
using E_Shop.Application.ViewModels.SpecificationViewModels;
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
        [HttpGet]
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
                AvailabeSpecifications = await _service.GetAvailableSpecificationsToAddProduct(productId)
            };
            return View(specModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddToProduct(AddSpecToProductVM model, List<int> specIds)
        {
            if (!ModelState.IsValid)
            {
                AddSpecToProductVM specModel = new()
                {
                    AvailabeSpecifications = await _service.GetAvailableSpecificationsToAddProduct(model.ProductId)
                };
                return View(specModel);
            }
            model.SelectedSpecificationIds = specIds;
            await _service.AddSpecificationToProduct(model);
            return RedirectToAction(nameof(SpecificationDetails), new { id = model.ProductId });
        }
        #endregion

        #region Edit For Product
        [HttpGet]
        public async Task<IActionResult> EditForProduct(int productId)
        {
            var specs = await _service.GetSpecificationListByProductId(productId);
            AddSpecToProductVM updateVm = new()
            {
                ProductId = productId,
                SelectedSpecificationIds = [.. specs.Select(c => c.SpecId)],
                AvailabeSpecifications = await _service.GetAvailableSpecificationsToAddProduct(productId)
            };
            return View(updateVm);
        }


        [HttpPost]
        public async Task<IActionResult> EditForProduct(int productId, AddSpecToProductVM model, List<int> selectedSpecsIds)
        {
            if (!ModelState.IsValid) return View(model);
            await _service.AddSpecificationToProduct(model);
            await _service.UpdateProductSpecifications(productId, selectedSpecsIds);
            return RedirectToAction("Details", "Products", new { id = model.ProductId });
        }
        #endregion

        #region Delete For Product
        [HttpGet]
        public async Task<IActionResult> DeleteSpecificationForProduct(int specId)
        {
            await _service.DeleteProductSpecificationForProduct(specId);
            return RedirectToAction(nameof(SpecificationDetails));
        }
        #endregion
    }
}
