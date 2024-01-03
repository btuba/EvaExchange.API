using EvaExchange.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace EvaExchange.DataAccess.Repositories
{
    public interface ITransactionWriteRepository : IWriteRepository<Core.Transaction>
    {
    }
}
