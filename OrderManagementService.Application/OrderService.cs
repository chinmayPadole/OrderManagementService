using OrderManagementService.Gateways;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementService.Application
{
    public class OrderService : IOrderService
    {
        private IOrderStore _orderStore;
        public OrderService(IOrderStore orderStore)
        {
            _orderStore = orderStore;
        }

        public void CreateOrder(CreateOrderRequest request)
        {

            //todo : add logic to 
            //validate item availablity,
            //validate price 
            //get exchangeRate from some Exchange rateService and calculate new amount in base currency in which our application deals
            _orderStore.SaveOrder(request.ToModel());
        }

        public GetOrdersResponse GetOrders(GetOrdersRequest request)
        {
           return _orderStore.GetOrders(request.ToModel()).ToDataContract();
        }
    }
}
