using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementService.Application
{
    public class QuotedPrice
    {
        public decimal Amount { get; set; }
        public decimal AmountWithoutTax { get; set; }
    }
}
