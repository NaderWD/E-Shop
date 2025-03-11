using E_Shop.Application.Services.ProductServices;
using E_Shop.Application.Services.WalletServices;
using E_Shop.Application.Tools;
using Microsoft.AspNetCore.Mvc;

namespace E_Shop.Web.Components
{
    public class WalletBalanceViewComponent(IWalletService _walletService) : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            int userid = User.GetUserId();
            var content = _walletService.GetWalletBalance(userid);
            return View("GetWalletBalance", content);
        }
    }
}
