using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementService.Gateways
{
    public interface IOrderStore
    {
        void SaveOrder(CreateOrderRequest request);

        GetOrdersResponse GetOrders(GetOrdersRequest request);
    }
}
