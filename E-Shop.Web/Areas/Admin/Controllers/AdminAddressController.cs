using E_Shop.Application.Services.AddressServices;
using E_Shop.Application.ViewModels.AddressViewModels;
using Microsoft.AspNetCore.Mvc;

namespace E_Shop.Web.Areas.Admin.Controllers
{
    public class AdminAddressController(IStateServices _stateServices, ICityServices _cityServices) : AdminBaseController
    {
        #region State
        public async Task<IActionResult> AllStates()
        {
            return View(await _stateServices.GetAllStates());
        }

        [HttpGet]
        public async Task<IActionResult> CreateState()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateState(string stateName)
        {
            await _stateServices.CreateState(stateName);
            return RedirectToAction(nameof(AllStates));
        }

        [HttpPost]
        public async Task<IActionResult> DeleteState(int stateId)
        {
            await _stateServices.SoftDeleteState(stateId);
            return RedirectToAction(nameof(AllStates));
        }
        #endregion

        #region City
        public async Task<IActionResult> AllCities()
        {
            return View(await _cityServices.GetAllCities());
        }

        [HttpGet]
        public async Task<IActionResult> CreateCity()
        {
            ViewBag.StateList = await _stateServices.GetAllStates();
            return View(new CityVM { });
        }

        [HttpPost]
        public async Task<IActionResult> CreateCity(CityVM cityVm)
        {
            await _cityServices.CreateCity(cityVm);
            return RedirectToAction(nameof(AllCities));
        }

        [HttpPost]
        public async Task<IActionResult> DeleteCity(int cityId)
        {
            await _cityServices.SoftDeleteCity(cityId);
            return RedirectToAction(nameof(AllCities));
        }
        #endregion
    }
}
