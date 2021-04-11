using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementService.Gateways
{
    public class GetOrdersResponse
    {
        public List<Order> Orders { get; set; }
    }
}
