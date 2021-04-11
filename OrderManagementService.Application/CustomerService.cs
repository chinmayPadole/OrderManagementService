using OrderManagementService.Gateways;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementService.Application
{
    public class CustomerService : ICustomerService
    {
        private ICustomerStore _customerStore;
        public CustomerService(ICustomerStore customerStore)
        {
            _customerStore = customerStore;
        }
        public void CreateCustomer(CreateCustomerRequest request)
        {
            _customerStore.AddCustomer(request.ToModel());
        }

        public GetCustomerResponse GetCustomer(GetCustomerRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
