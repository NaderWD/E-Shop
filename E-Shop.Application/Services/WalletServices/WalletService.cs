using E_Shop.Application.ViewModels.Wallet;
using E_Shop.Domain.Contracts.WalletCont;
using E_Shop.Domain.DTOs.Novino;
using E_Shop.Domain.Models.Wallet;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Shop.Application.Services.WalletServices
{
    public class WalletService(IWalletRepository _walletRepository) : IWalletService
    {
        public int AddTransaction(WalletViewModel Transaction)
        {
            Wallet model = new Wallet()
            {
                Amount = Transaction.Amount,
                CreateDate = DateTime.Now,
                Status = Domain.Enum.TranStatus.Pending,
                Type = Transaction.Type,
                UserId = Transaction.UserId,

            };
            _walletRepository.AddTarnsaction(model);
            return model.Id;
        }

        public bool DefineStatus(bool Confirmed, int Id)
        {
            var transaction = _walletRepository.GetById(Id);

            if (Confirmed)
            {
                transaction.Status = Domain.Enum.TranStatus.Success;
            }
            else
            {
                transaction.Status = Domain.Enum.TranStatus.Failed;
            }

            return _walletRepository.UpdateTransaction(transaction);
            
        }

        public List<WalletViewModel> GetAll(int userId)
        {
            var wallet = _walletRepository.GetAll(userId);
            List<WalletViewModel> model = new List<WalletViewModel>();
            foreach (var item in wallet)
            {
                model.Add(new WalletViewModel 
                {
                    Amount = item.Amount,
                    Status = item.Status,
                    CreateDate = item.CreateDate,
                    Id = item.Id,
                    Type = item.Type,
                    UserId = item.UserId
                });
            }

            return model;
        }

        public int GetAmount(int Id)
        {
            return _walletRepository.GetAmount(Id);
        }

        public int GetWalletBalance(int userId)
        {
            return _walletRepository.GetWalletBalance(userId);
        }

        public NovinoGetPaymentUrlRequestDto RequestContent(WalletViewModel transaction, int InvoiceId)
        {
            NovinoGetPaymentUrlRequestDto model = new()
            {
                Amount = transaction.Amount,
                CallBack_Method = "",
                CallBack_Url = "https://localhost:7118/Payment/NovinoCallback",
                Card_pan = null,
                Description = "شارژ کیف پول",
                Email = null,
                Invoice_Id = InvoiceId.ToString(),
                MerchantId = "test",
                Mobile = null,
                Name = null,
            };
            return model;

        }
    }
}
