using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementService.DataContract.V1
{
    public static class GetOrdersResponseTranslator
    {
        public static DataContract.V1.GetAllOrdersResponse ToDataContract(this Application.GetOrdersResponse response)
        {
            return new DataContract.V1.GetAllOrdersResponse()
            {
                Orders = response.Orders.ToOrders()
            };
        }

        public static List<DataContract.V1.Order> ToOrders(this List<Application.Order> orders)
        {
            var newOrders = new List<DataContract.V1.Order>();

            foreach (var order in orders)
            {
                var newOrder = new DataContract.V1.Order();
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

        public static DataContract.V1.CustomerInfo ToCustomerInfo(this Application.CustomerInfo customerInfo)
        {
            return new DataContract.V1.CustomerInfo()
            {
                Id = customerInfo.Id
            };
        }

        public static List<DataContract.V1.Item> ToItems(this List<Application.Item> items)
        {
            var appItems = new List<DataContract.V1.Item>();

            foreach (var item in items)
            {
                var appItem = new DataContract.V1.Item();
                appItem.Id = item.Id;
                appItem.Name = item.Name;
                appItem.QuotedPrice = item.QuotedPrice.ToQuotedPrice();

                appItems.Add(appItem);
            }

            return appItems;
        }

        public static DataContract.V1.QuotedPrice ToQuotedPrice(this Application.QuotedPrice req)
        {
            return new DataContract.V1.QuotedPrice()
            {
                Amount = req.Amount,
                AmountWithoutTax = req.AmountWithoutTax
            };
        }
    }
}
