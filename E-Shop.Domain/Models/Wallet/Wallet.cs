using E_Shop.Domain.Enum;
using E_Shop.Domain.Models.UserModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace E_Shop.Domain.Models.Wallet
{
    public class Wallet : BaseModel
    {
        public int Amount { get; set; }
        public int UserId { get; set; }
        public TransactionType Type { get; set; }
        public Status Status { get; set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; set; }

    }
}
