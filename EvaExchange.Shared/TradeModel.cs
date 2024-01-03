using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaExchange.Shared
{
    public class TradeModel
    {
        public int ClientId { get; set; }
        public int ShareId { get; set; }
        public int Quentity { get; set; }
    }
}
