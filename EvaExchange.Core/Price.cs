using EvaExchange.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaExchange.Core
{
    public class Price : BaseEntity
    {
        public decimal Rate { get; set; }
        public int ShareId { get; set; }
        public Share Share { get; set; }
    }
}
