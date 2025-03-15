using E_Shop.Application.Services.WalletServices;
using E_Shop.Application.Tools;
using E_Shop.Application.ViewModels.Wallet;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace E_Shop.Web.Areas.User.Controllers
{
    public class WalletController(IWalletService _walletService) : UserBaseController
    {
        public IActionResult WalletIndex()
        {
            int userid = User.GetUserId();
            TempData["UserId"] = userid;
            ViewData["UserId"] = TempData["UserId"];

            var content = _walletService.GetAll(userid);
            
            return View(content);
        }
        #region Deposit
        [HttpPost]
        public IActionResult Deposit(WalletViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var TransactionId = _walletService.AddTransaction(model);
            
            var paymentcontent = _walletService.RequestContent(model, TransactionId);
            var serialized = JsonConvert.SerializeObject(paymentcontent);

            return RedirectToAction("StartPay", "Payment", new { area= "", model = serialized });
        }
        #endregion 
    }
}
