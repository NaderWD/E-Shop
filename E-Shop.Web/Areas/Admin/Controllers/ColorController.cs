using E_Shop.Application.Services.Interfaces;
using E_Shop.Application.ViewModels.Color;
using E_Shop.Domain.Models.Shared;
using E_Shop.Application.Services.ColorServices;
using E_Shop.Application.ViewModels.ColorViewModels;
using Microsoft.AspNetCore.Mvc;

namespace E_Shop.Web.Areas.Admin.Controllers
{
    public class ColorController(IColorService colorService) : AdminBaseController
    {
        public IActionResult ColorIndex()
        {
            var colors = colorService.GetAll().ToList();
            return View(colors);
        }

        [HttpPost]
        public IActionResult CreateColor(ColorViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = colorService.Create(model);
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

        public IActionResult UpdateColor(int colorId)
        {
            var color = colorService.GetById(colorId);
            return PartialView("_UpdateColor" ,color);
        }

        [HttpPost]
        public IActionResult UpdateColor(ColorViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = colorService.Update(model);
            if (result == true)
            {
                TempData[SuccessMessage] = ErrorMessages.ColorUpdate;
                return RedirectToAction("ColorIndex");
            }
            else
            {
                TempData[ErrorMessage] = ErrorMessages.FailedMessage;
                return RedirectToAction("ColorIndex");
            }
        }

        [HttpPost]
        public IActionResult DeleteColor(int Id)
        {
            var result = colorService.Delete(Id);
            if (result == true)
            {
                TempData[SuccessMessage] = ErrorMessages.ColorDeleted;
                return RedirectToAction("ColorIndex");
            }
            else
            {
                TempData[ErrorMessage] = ErrorMessages.FailedMessage;
                return RedirectToAction("ColorIndex");
            }
        }
    }

}
