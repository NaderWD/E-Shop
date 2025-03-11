using E_Shop.Domain.Models.Wallet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Shop.Domain.Contracts.WalletCont
{
    public interface IWalletRepository
    {
        bool AddTarnsaction(Wallet model);
        int GetAmount(int Id);
        Wallet GetById(int Id);
        bool UpdateTransaction(Wallet model);
        List<Wallet> GetAll(int userId);
        int GetWalletBalance(int userId);
    }
}
