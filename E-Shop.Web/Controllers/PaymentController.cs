using E_Shop.Application.DTOs.Novino;
using E_Shop.Application.Services.WalletServices;
using E_Shop.Application.ViewModels.Payment;
using E_Shop.Application.ViewModels.Wallet;
using E_Shop.Domain.DTOs.Novino;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyEshop.Data.DTOs.Novino;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;

namespace E_Shop.Web.Controllers
{
    public class PaymentController(IWalletService _walletService) : Controller
    {
        public async Task<IActionResult> StartPay(string model)
        {
            
            using HttpClient httpClient = new HttpClient();


            HttpContent content = new StringContent(model, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync(
                "https://api.novinopay.com/payment/ipg/v2/request",
                content
                );

            string responseContent = await response.Content.ReadAsStringAsync();

            var finalResult = JsonConvert.DeserializeObject<NovinoGetPaymentUrlResponseDto>(responseContent);

            if (finalResult != null && finalResult.Status == "100")
            {
                return Redirect(finalResult.Data.Payment_Url);
            }
            else 
            {
                return NotFound();
            }
                
        }

        public async Task<IActionResult> NovinoCallback(string paymentStatus, string invoiceID, string authority)
        {
            if (!string.IsNullOrEmpty(paymentStatus) && paymentStatus.ToLower() == "ok")
            {
                var amount = _walletService.GetAmount(int.Parse(invoiceID));
                
                using HttpClient httpClient = new HttpClient();

                NovinoVerifyPaymentRequestDto model = new NovinoVerifyPaymentRequestDto()
                {
                    Amount = amount,
                    Authority = authority,
                    MerchantId = "test"
                };

                string body = JsonConvert.SerializeObject(model);

                HttpContent content = new StringContent(body, Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync(
                           "https://api.novinopay.com/payment/ipg/v2/verification",
                           content
                           );

                string responseContent = await response.Content.ReadAsStringAsync();

                var finalResult = JsonConvert.DeserializeObject<NovinoVerifyPaymentResponseDto>(responseContent);

                if (finalResult != null && finalResult.Status == "100")
                {
                    _walletService.DefineStatus(true,int.Parse(invoiceID));
                    return View("SuccessPayment", new SuccessPaymentViewModel()
                    {
                        Message = "پرداخت با موفقیت انجام شد.",
                        RefId = finalResult.Data.RefId
                    });
                }
                else
                {
                    _walletService.DefineStatus(false, int.Parse(invoiceID));
                    return View("ErrorPayment", new ErrorPaymentViewModel()
                    {
                        Message = "خرید شما با شکست مواجه شده است. لطفا تیکت ارسال کنید.",
                        RefId = "123431"
                    });
                }
            }
            else
            {
                _walletService.DefineStatus(false, int.Parse(invoiceID));
                return View("ErrorPayment", new ErrorPaymentViewModel()
                {
                    Message = "خرید شما با شکست مواجه شده است. لطفا تیکت ارسال کنید.",
                    RefId = "123431"
                });
            }
        }

    }
}
