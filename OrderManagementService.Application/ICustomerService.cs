namespace OrderManagementService.Application
{
    public interface ICustomerService
    {
        GetCustomerResponse GetCustomer(GetCustomerRequest request);
        void CreateCustomer(CreateCustomerRequest request);
    }
}
