using E_Shop.Application.ViewModels.Wallet;
using E_Shop.Domain.DTOs.Novino;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Shop.Application.Services.WalletServices
{
    public interface IWalletService
    {
        int AddTransaction(WalletViewModel Transaction);
        NovinoGetPaymentUrlRequestDto RequestContent(WalletViewModel transaction , int InvoiceId);
        int GetAmount(int Id);
        bool DefineStatus(bool Confirmed, int Id);
        List<WalletViewModel> GetAll(int userId);
        int GetWalletBalance(int userId);
    }
}
