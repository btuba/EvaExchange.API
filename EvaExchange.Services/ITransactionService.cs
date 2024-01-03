using EvaExchange.Shared;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaExchange.Services
{
    public interface ITransactionService
    {
        Task<bool> Buy(TradeModel trade);
        Task<bool> Sell(TradeModel trade);
    }
}
