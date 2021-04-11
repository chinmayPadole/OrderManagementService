namespace OrderManagementService.Application
{
    public interface IOrderService
    {
        void CreateOrder(CreateOrderRequest request);
        GetOrdersResponse GetOrders(GetOrdersRequest request);
    }
}
