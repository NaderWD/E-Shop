using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Shop.Domain.Enum
{
    public enum TransactionType
    {
        Deposit,
        Withdrawal,
    }
    public enum TranStatus
    {
        Pending,
        Failed,
        Success
    }
}
