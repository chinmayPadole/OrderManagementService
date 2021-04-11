namespace OrderManagementService.Gateways
{
    public interface ICustomerStore
    {
        void AddCustomer(CreateCustomerRequest request);
    }
}
