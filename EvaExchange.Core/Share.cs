using EvaExchange.Core.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaExchange.Core
{
    public class Share : BaseEntity
    {
        [MaxLength(3)]
        public string? Symbol { get; set; }
        public ICollection<Price>? Prices { get; set; }
    }
}
