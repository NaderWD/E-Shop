using E_Shop.Domain.Contracts.WalletCont;
using E_Shop.Domain.Models.Wallet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Shop.Infra.Data.Repositories.WalletRepo
{
    public class WalletRepository(ShopDbContext dbContext) : IWalletRepository
    {
        public bool AddTarnsaction(Wallet model)
        {
            dbContext.Wallet.Add(model);
            dbContext.SaveChanges();
            return true;
        }

        public List<Wallet> GetAll(int userId)
        {
            return dbContext.Wallet.ToList();
        }

        public int GetAmount(int Id)
        {
            return dbContext.Wallet.Find(Id).Amount;
        }

        public Wallet GetById(int Id)
        {
            return dbContext.Wallet.Find(Id);
        }

        public int GetWalletBalance(int userId)
        {
            var deposit = dbContext.Wallet.Where(t => t.UserId == userId && t.Type == Domain.Enum.TransactionType.Deposit && t.Status == Domain.Enum.TranStatus.Success).Sum(t => t.Amount);
            var withraw = dbContext.Wallet.Where(t => t.UserId == userId && t.Type == Domain.Enum.TransactionType.Withdrawal && t.Status == Domain.Enum.TranStatus.Success).Sum(t => t.Amount);
            return deposit - withraw;
        }

        public bool UpdateTransaction(Wallet model)
        {
            dbContext.Wallet.Update(model);
            dbContext.SaveChanges();
            return true;
        }
    }
}
