using E_Shop.Application.Services.SpecificationServices;
using E_Shop.Application.ViewModels.SpecificationViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace E_Shop.Web.Areas.Admin.Controllers
{
    public class SpecificationController(ISpecificationService _service) : AdminBaseController
    {
        #region All Specifications
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _service.GetAllSpecs());
        }
        #endregion



        #region Create Specification
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View(await _service.GetSpecCreateModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(SpecCreateVM createVM)
        {
            if (!ModelState.IsValid) return View(createVM);
            createVM.AvailableCategories = (await _service.GetSpecCreateModel()).AvailableCategories;
            await _service.CreateSpec(createVM);
            return RedirectToAction(nameof(Index));
        }
        #endregion



        #region Edit Specifications  
        [HttpGet]
        public async Task<IActionResult> Edit(int specId)
        {
            return View(await _service.GetSpecByIdForEditProduct(specId));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int specId, SpecCreateVM createVM)
        {
            if (specId != createVM.Id) return NotFound();
            if (!ModelState.IsValid) return View(createVM);
            createVM.AvailableCategories = (await _service.GetSpecCreateModel()).AvailableCategories;
            await _service.UpdateSpec(createVM);
            return RedirectToAction(nameof(Index));
        }
        #endregion



        #region Delete Specifications
        public async Task<IActionResult> Delete(int specId)
        {
            await _service.DeleteSpec(specId);
            return RedirectToAction(nameof(Index));
        }
        #endregion



        #region Product Specification
        public async Task<IActionResult> Add(int productId)
        {
            var model = await _service.GetProductSpecModel(productId);
            return View(model);
        }

        // POST: ProductSpecifications/Add
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(ProductSpecAddVM model)
        {
            if (ModelState.IsValid)
            {
                await _service.AddSpecToProduct(model);
                return RedirectToAction("Details", "Products", new { id = model.ProductId });
            }
            model.AvailabeSpecifications = (await _service.GetProductSpecModel(model.ProductId)).AvailabeSpecifications;
            return View(model);
        }

        // GET: ProductSpecifications/Edit/5
        public async Task<IActionResult> Edit(int productId, int specId)
        {
            var productSpec = await _service.GetProductSpec(productId, specId);
            if (productSpec == null)
            {
                return NotFound();
            }

            var model = new ProductSpecAddVM
            {
                ProductId = productId,
                SelectedSpecificationId = specId,
                Value = productSpec.Value,
                AvailabeSpecifications = (await _service.GetProductSpecModel(productId)).AvailabeSpecifications
            };

            return View(model);
        }

        
        [HttpPost]
        public async Task<IActionResult> Edit(int productId, int specId, ProductSpecAddVM model)
        {
            if (ModelState.IsValid)
            {
                await _service.UpdateProductSpec(model);
                return RedirectToAction("Details", "Products", new { id = model.ProductId });
            }
            model.AvailabeSpecifications = (await _service.GetProductSpecModel(model.ProductId)).AvailabeSpecifications;
            return View(model);
        }
        #endregion


    }
}
