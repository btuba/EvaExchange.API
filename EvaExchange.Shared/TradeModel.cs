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
        [Required]

        public int ClientId { get; set; }
        [Required]

        public int ShareId { get; set; }
        [Required]
        public int Quentity { get; set; } = 1;
    }
}
