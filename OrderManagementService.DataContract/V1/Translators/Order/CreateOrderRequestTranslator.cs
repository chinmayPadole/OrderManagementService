using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementService.DataContract.V1
{
    public static class CreateOrderRequestTranslator
    {
        public static Application.CreateOrderRequest ToModel(this OrderManagementService.DataContract.V1.CreateOrderRequest req)
        {
            if (req == null) return null;

            return new Application.CreateOrderRequest
            {
                Currency = req.Currency,
                Amount = req.Amount,
                CustomerInfo = req.CustomerInfo.ToCustomerInfo(),
                Items = req.Items.ToItems()
            };
        }

        public static Application.CustomerInfo ToCustomerInfo(this OrderManagementService.DataContract.V1.CustomerInfo customerInfo)
        {
            return new Application.CustomerInfo()
            {
                Id = customerInfo.Id
            };
        }

        public static List<Application.Item> ToItems(this List<OrderManagementService.DataContract.V1.Item> items)
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

        public static Application.QuotedPrice ToQuotedPrice(this OrderManagementService.DataContract.V1.QuotedPrice req)
        {
            return new Application.QuotedPrice()
            {
                Amount = req.Amount,
                AmountWithoutTax = req.AmountWithoutTax
            };
        }
    }
}
