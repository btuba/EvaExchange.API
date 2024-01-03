using EvaExchange.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaExchange.Core
{
    public class Transaction : BaseEntity
    {
        public string? Action { get; set; }
        public int Quantity { get; set; }
        public int ShareId { get; set; }
        public Share Share { get; set; } = null!;
        public int PortfolioId { get; set; }
        public Portfolio Portfolio { get; set; } = null!;
        public decimal Rate { get; set; }
    }
}
