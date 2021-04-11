using OrderManagementService.Data.Models.Order;
using System;
using System.Collections.Generic;

namespace OrderManagementService.OrderStore
{
    public static class GetOrdersResponseTranslator
    {
        public static Gateways.GetOrdersResponse ToDataContract(this List<tOrder> response)
        {
            return new Gateways.GetOrdersResponse()
            {
                Orders = response.ToOrders()
            };
        }

        public static List<Gateways.Order> ToOrders(this List<tOrder> orders)
        {
            var newOrders = new List<Gateways.Order>();

            foreach (var order in orders)
            {
                var newOrder = new Gateways.Order();
                newOrder.Amount = (decimal)order.Amount;
                newOrder.CreateDate = (DateTime)order.CreateDate;
                newOrder.CustomerInfo = order.CustomerId.ToCustomerInfo();
                newOrder.Id = order.Id;
                newOrder.Items = order.tItem.ToItems();
                newOrder.ModifiedDate =(DateTime) order.ModifiedDate;

                newOrders.Add(newOrder);
            }

            return newOrders;
        }

        public static Gateways.CustomerInfo ToCustomerInfo(this string customerId)
        {
            return new Gateways.CustomerInfo()
            {
                Id = customerId
            };
        }

        public static List<Gateways.Item> ToItems(this ICollection<tItem> items)
        {
            var appItems = new List<Gateways.Item>();

            foreach (var item in items)
            {
                var appItem = new Gateways.Item();
                appItem.Id = item.Id;
                appItem.Name = item.Name;
                appItem.QuotedPrice = item.Amount.ToQuotedPrice(item.AmountWithoutTax);

                appItems.Add(appItem);
            }

            return appItems;
        }

        public static Gateways.QuotedPrice ToQuotedPrice(this decimal? amount, decimal? amountWithoutTax)
        {
            return new Gateways.QuotedPrice()
            {
                Amount = (decimal)amount,
                AmountWithoutTax = (decimal)amountWithoutTax
            };
        }
    }
}
