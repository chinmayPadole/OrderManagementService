using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementService.Application
{
    public static class CreateOrderRequestTranslator
    {
        public static Gateways.CreateOrderRequest ToModel(this CreateOrderRequest req)
        {
            if (req == null) return null;

            return new Gateways.CreateOrderRequest
            {
                Currency = req.Currency,
                Amount = req.Amount,
                CustomerInfo = req.CustomerInfo.ToCustomerInfo(),
                Items = req.Items.ToItems()
            };
        }

        public static Gateways.CustomerInfo ToCustomerInfo(this CustomerInfo customerInfo)
        {
            return new Gateways.CustomerInfo()
            {
                Id = customerInfo.Id
            };
        }

        public static List<Gateways.Item> ToItems(this List<Item> items)
        {
            var appItems = new List<Gateways.Item>();

            foreach (var item in items)
            {
                var appItem = new Gateways.Item();
                appItem.Id = item.Id;
                appItem.Name = item.Name;
                appItem.QuotedPrice = item.QuotedPrice.ToQuotedPrice();

                appItems.Add(appItem);
            }

            return appItems;
        }

        public static Gateways.QuotedPrice ToQuotedPrice(this QuotedPrice req)
        {
            return new Gateways.QuotedPrice()
            {
                Amount = req.Amount,
                AmountWithoutTax = req.AmountWithoutTax
            };
        }
    }
}
