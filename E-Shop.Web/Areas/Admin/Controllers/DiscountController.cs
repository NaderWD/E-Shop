using E_Shop.Application.Services.ColorServices;
using E_Shop.Application.Services.DiscountServices;
using E_Shop.Application.ViewModels.DiscountsViewModels;
using E_Shop.Domain.Models.ValidationModels;
using Microsoft.AspNetCore.Mvc;

namespace E_Shop.Web.Areas.Admin.Controllers
{
    public class DiscountController(IDiscountService discountService) : AdminBaseController
    {
        public IActionResult DiscountIndex()
        {
            var content = discountService.GetAll();
            return View(content);
        }

        #region Add
        public IActionResult CreateDiscount()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateDiscount(DiscountViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = discountService.CreateDiscount(model);
            if (result == true)
            {
                TempData[SuccessMessage] = ErrorMessages.ColorAdded;
                return RedirectToAction("ColorIndex");
            }
            else
            {
                TempData[ErrorMessage] = ErrorMessages.FailedMessage;
                return RedirectToAction("ColorIndex");
            }
        }
        #endregion

        #region Add
        public IActionResult UpdateDiscount(int DiscountId)
        {
            var content = discountService.GetById(DiscountId);
            return View(content);
        }

        [HttpPost]
        public IActionResult UpdateDiscount(DiscountViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = discountService.CreateDiscount(model);
            if (result == true)
            {
                TempData[SuccessMessage] = ErrorMessages.ColorAdded;
                return RedirectToAction("ColorIndex");
            }
            else
            {
                TempData[ErrorMessage] = ErrorMessages.FailedMessage;
                return RedirectToAction("ColorIndex");
            }
        }
        #endregion 
    }
}
