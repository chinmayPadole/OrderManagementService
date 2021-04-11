using OrderManagementService.Data.Models.Order;
using OrderManagementService.Gateways;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementService.OrderStore
{
    public static class CreateOrderRequestTranslator
    {
        public static tOrder ToModel(this CreateOrderRequest request)
        {
            var orderId = Guid.NewGuid().ToString();
            return new tOrder()
            {
                Id = orderId,
                Currency = request.Currency,
                Amount = request.Amount,
                CustomerId = request.CustomerInfo.Id,
                tItem = request.Items.ToModel(orderId)
            };
        }

        public static ICollection<tItem> ToModel(this List<Item> items, string orderId)
        {
            var tItems = new List<tItem>();

            foreach (var item in items)
            {
                var tItem = new tItem();
                tItem.Amount = item.QuotedPrice.Amount;
                tItem.AmountWithoutTax = item.QuotedPrice.AmountWithoutTax;
                tItem.Id = item.Id;
                tItem.Name = item.Name;
                tItem.OrderId = orderId;
                tItems.Add(tItem);
            }

            return tItems;
        }
    }
}
