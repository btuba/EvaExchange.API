using EvaExchange.Core;
using EvaExchange.DataAccess.Context;
using EvaExchange.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaExchange.DataAccess.Repositories.Impl
{
    public class ClientWriteRepository : WriteRepository<Client>, IClientWriteRepository
    {
        public ClientWriteRepository(EvaDbContext context) : base(context)
        {
        }
    }
}
