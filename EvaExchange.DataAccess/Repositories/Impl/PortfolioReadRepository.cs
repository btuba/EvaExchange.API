﻿using EvaExchange.Core;
using EvaExchange.DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaExchange.DataAccess.Repositories.Impl
{
    public class PortfolioReadRepository : ReadRepository<Portfolio>, IPortfolioReadRepository
    {
        public PortfolioReadRepository(EvaDbContext context) : base(context)
        {
        }
    }
}
