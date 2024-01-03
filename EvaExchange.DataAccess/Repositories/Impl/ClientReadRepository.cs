using EvaExchange.Core;
using EvaExchange.Core.Common;
using EvaExchange.DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaExchange.DataAccess.Repositories.Impl
{
    public class ClientReadRepository : ReadRepository<Client>, IClientReadRepository
    {
        public ClientReadRepository(EvaDbContext context) : base(context)
        {
        }
    }
}
