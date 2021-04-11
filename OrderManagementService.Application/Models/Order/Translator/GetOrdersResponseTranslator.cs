using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementService.Application
{
    public static class GetOrdersResponseTranslator
    {
        public static Application.GetOrdersResponse ToDataContract(this Gateways.GetOrdersResponse response)
        {
            return new Application.GetOrdersResponse() {
                Orders = response.Orders.ToOrders()
            };
        }

        public static List<Application.Order> ToOrders(this List<Gateways.Order> orders)
        {
            var newOrders = new List<Application.Order>();

            foreach(var order in orders)
            {
                var newOrder = new Application.Order();
                newOrder.Amount = order.Amount;
                newOrder.CreateDate = order.CreateDate;
                newOrder.CustomerInfo = order.CustomerInfo.ToCustomerInfo();
                newOrder.Id = order.Id;
                newOrder.Items = order.Items.ToItems();
                newOrder.ModifiedDate = order.ModifiedDate;

                newOrders.Add(newOrder);
            }

            return newOrders;
        }

        public static Application.CustomerInfo ToCustomerInfo(this Gateways.CustomerInfo customerInfo)
        {
            return new Application.CustomerInfo()
            {
                Id = customerInfo.Id
            };
        }

        public static List<Application.Item> ToItems(this List<Gateways.Item> items)
        {
            var appItems = new List<Application.Item>();

            foreach (var item in items)
            {
                var appItem = new Application.Item();
                appItem.Id = item.Id;
                appItem.Name = item.Name;
                appItem.QuotedPrice = item.QuotedPrice.ToQuotedPrice();

                appItems.Add(appItem);
            }

            return appItems;
        }

        public static Application.QuotedPrice ToQuotedPrice(this Gateways.QuotedPrice req)
        {
            return new Application.QuotedPrice()
            {
                Amount = req.Amount,
                AmountWithoutTax = req.AmountWithoutTax
            };
        }
    }
}
