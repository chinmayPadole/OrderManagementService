using OrderManagementService.Data.Models.Order;
using OrderManagementService.Gateways;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OrderManagementService.OrderStore
{
    public class OrderStore : IOrderStore
    {
        public void SaveOrder(CreateOrderRequest order)
        {
            using (var context = new OrderEntities())
            {
                try
                {
                    var tOrder = order.ToModel();
                    var response = context.SaveOrder(tOrder.Id, tOrder.Currency, tOrder.Amount, tOrder.CustomerId);
                    if (response != -1)
                    {
                        foreach (var item in tOrder.tItem)
                        {
                            context.tItem.Add(item);
                        }
                    }
                    else
                    {
                        throw new Exception($"Customer with Id {tOrder.CustomerId} does not exists");
                    }
                    context.SaveChanges();
                }
                catch(Exception ex)
                {
                    throw new Exception($"Somthing went wrong : msg: {ex.Message}");
                }
            }
        }

        public GetOrdersResponse GetOrders(GetOrdersRequest request)
        {
            using (var context = new OrderEntities())
            {
                try
                {
                    if (request.OrderBy == "ASC")
                    {
                        return context.tOrder.OrderBy(x => x.CreateDate).Skip(request.PageIndex * request.PageSize).Take(request.PageSize).ToList().ToDataContract();
                    }
                    else
                    {
                        return context.tOrder.OrderByDescending(x => x.CreateDate).Skip(request.PageIndex * request.PageSize).Take(request.PageSize).ToList().ToDataContract();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"Somthing went wrong : msg: {ex.Message}");
                }
            }
        }
    }
}
