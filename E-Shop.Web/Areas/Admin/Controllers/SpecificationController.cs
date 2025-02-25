using Microsoft.AspNetCore.Mvc;

namespace E_Shop.Web.Areas.Admin.Controllers
{
    public class SpecificationController : AdminBaseController
    {
        #region All Specifications
        public IActionResult Index()
        {
            return View();
        }
        #endregion



        #region  Create New Specification
        [HttpGet]
        public async Task<IActionResult> Create()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create()
        {

            return View();
        }
        #endregion



        #region  Add Specification To Product
        #endregion



        #region  Updates
        #endregion


        // To Modify
        public class SpecificationController : Controller
        {
            // GET: Shows form with categories checkboxes
            public async Task<IActionResult> Create()
            {
                ViewBag.Categories = await _categoryService.GetAllSubCategories();
                return View();
            }

            // POST: Handles spec creation
            [HttpPost]
            public async Task<IActionResult> Create(string name, List<int> categoryIds)
            {
                var spec = await _specService.CreateSpecification(name, categoryIds);
                return RedirectToAction("Index");
            }
        }

        public class ProductController : Controller
        {
            // GET: Show available specs for product
            public async Task<IActionResult> AddSpecification(int productId)
            {
                var specs = await _productService.GetAvailableSpecifications(productId);
                ViewBag.ProductId = productId;
                return View(specs);
            }

            // POST: Add spec to product
            [HttpPost]
            public async Task<IActionResult> AddSpecification(int productId, int specId, string value)
            {
                await _productService.AddSpecificationToProduct(productId, specId, value);
                return RedirectToAction("Details", new { id = productId });
            }
        }
    }
}
