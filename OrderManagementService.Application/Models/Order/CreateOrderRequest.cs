using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementService.Application
{
    public class CreateOrderRequest
    {
        public string Currency { get; set; }
        public decimal Amount { get; set; }
        public List<Item> Items { get; set; }
        public CustomerInfo CustomerInfo { get; set; }
    }
}
