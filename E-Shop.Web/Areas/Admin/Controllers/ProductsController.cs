using E_Shop.Application.Services.ColorServices;
using E_Shop.Application.Services.Interfaces;
using E_Shop.Application.Services.ProductServices;
using E_Shop.Application.ViewModels.ColorViewModels;
using E_Shop.Application.ViewModels.ProductsViewModel;
using E_Shop.Domain.Models.ValidationModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace E_Shop.Web.Areas.Admin.Controllers
{
    public class ProductsController(IProductsService productsService , IProductColorService productColorService, IColorService colorservice) : AdminBaseController
    {
        public IActionResult ProductIndex()
        {
            var content = productsService.GetAll();
            return View(content);
        }

        #region Create Product
        public IActionResult CreateProduct()
        {
            var content = productsService.GetProductCreateModel();
            ViewBag.CategoryList = new SelectList(content.Category ?? new List<ProductCategoryViewModel>(), "Id", "Name");
            return View(content);
        }

        [HttpPost]
        public IActionResult CreateProduct(CreateProductViewModel model)
        {

            if (!ModelState.IsValid)
            {
                var content = productsService.GetProductCreateModel();
                ViewBag.CategoryList = new SelectList(content.Category ?? new List<ProductCategoryViewModel>(), "Id", "Name");
                return View(model);
            }


            if (model.Image != null && model.Image.Length > 0)
            {

                var fileName = Path.GetFileNameWithoutExtension(model.Image.FileName);
                var extension = Path.GetExtension(model.Image.FileName);
                var uniqueFileName = $"{fileName}_{DateTime.Now.ToString("yyyyMMddHHmmss")}{extension}";


                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/theme-assets/images/products", uniqueFileName);


                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    model.Image.CopyTo(stream);
                }
                model.ImageName = uniqueFileName;
            }

            var result = productsService.CreateProduct(model);
            switch (result)
            {
                case false:
                    TempData[ErrorMessage] = ErrorMessages.FailedMessage;
                    return RedirectToAction("ProductIndex");

                case true:
                    TempData[SuccessMessage] = ErrorMessages.ProductAdded;
                    break;
            }
            return RedirectToAction("ProductIndex");



        }
        #endregion Create Product

        #region Update Product
        public IActionResult UpdateProduct(int productId)
        {
            var content = productsService.GetProductUpdateModel(productId);
            ViewBag.CategoryList = new SelectList(content.Category ?? new List<ProductCategoryViewModel>(), "Id", "Name");
            return View(content);
        }

        [HttpPost]
        public IActionResult UpdateProduct(UpdateProductViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var content = productsService.GetProductUpdateModel(model.Id);
                ViewBag.CategoryList = new SelectList(content.Category ?? new List<ProductCategoryViewModel>(), "Id", "Name");
                return View(model);
            }

            var oldFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/theme-assets/images/products", model.ImageName);

            if (model.Image != null && model.Image.Length > 0)
            {
                
                if (System.IO.File.Exists(oldFilePath))
                {
                    System.IO.File.Delete(oldFilePath);
                }

                
                var fileName = Path.GetFileNameWithoutExtension(model.Image.FileName);
                var extension = Path.GetExtension(model.Image.FileName);
                var uniqueFileName = $"{fileName}_{DateTime.Now.ToString("yyyyMMddHHmmss")}{extension}";

                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/theme-assets/images/products", uniqueFileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    model.Image.CopyTo(stream);
                }
                model.ImageName = uniqueFileName;
            }

            var result = productsService.UpdateProduct(model);
            switch (result)
            {
                case false:
                    TempData[ErrorMessage] = ErrorMessages.FailedMessage;
                    return RedirectToAction("ProductIndex");

                case true:
                    TempData[SuccessMessage] = ErrorMessages.ProductUpdated;
                    break;
            }
            return RedirectToAction("ProductIndex");
        }
        #endregion Update Product

        #region Delete Product

        public IActionResult DeleteProduct(int ProductId , string ImageName)
        {
            var oldFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/theme-assets/images/products", ImageName);
            if (System.IO.File.Exists(oldFilePath))
            {
                System.IO.File.Delete(oldFilePath);
            }

            var result = productsService.DeleteProduct(ProductId);

            if (result == true)
            {
                TempData[SuccessMessage] = ErrorMessages.ProductDeleted;
                return RedirectToAction("Index");
            }
            else
            {
                TempData[ErrorMessage] = ErrorMessages.FailedMessage;
                return RedirectToAction("Index");
            }
        }

        #endregion Delete Product

        #region ProductColor
        public IActionResult ProductColor(int productId)
        {
            var content = productColorService.GetAllColorForProduct(productId);
            ViewBag.ProductId = productId;
            return View(content);
        }
        
        public IActionResult AddColor(int productId)
        {
            
            ViewBag.ProductId = productId;
            var content = colorservice.GetAll();
            ViewBag.Colors = content ?? new List<ColorViewModel>();
            
            return View();
        }

        [HttpPost]
        public IActionResult AddColor(AddColorToProductViewModel model)
        {
            if (!ModelState.IsValid) { return View(model); }
            var result = productColorService.AddMapping(model);
            
            switch (result)
            {
                case false:
                    TempData[ErrorMessage] = ErrorMessages.FailedMessage;
                    return RedirectToAction("ProductIndex");

                case true:
                    TempData[SuccessMessage] = ErrorMessages.ProductAdded;
                    return RedirectToAction("ProductIndex");
            }
            
        }

        public IActionResult RemoveColor(int MappingId)
        {
            var result = productColorService.RemoveColor(MappingId);
            switch (result)
            {
                case false:
                    TempData[ErrorMessage] = ErrorMessages.FailedMessage;
                    return RedirectToAction("ProductIndex");

                case true:
                    TempData[SuccessMessage] = ErrorMessages.ProductAdded;
                    break;
            }
            return RedirectToAction("ProductIndex");
        }
        #endregion
    }
}
