using EvaExchange.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaExchange.Core
{
    public class Portfolio : BaseEntity
    {
        public int ClientId { get; set; }
        public Client Client { get; set; }
    }
}
