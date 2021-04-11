using OrderManagementService.Data.Models.Customer;
using OrderManagementService.Gateways;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementService.CustomerStore
{
    public static class CreateCustomerRequestTranslator
    {
        public static tCustomer ToModel(this CreateCustomerRequest request)
        {
            return new tCustomer()
            {
                Id = Guid.NewGuid().ToString(),
                Name = request.Name,
                Email = request.Email,
                Password = request.Password
            };
        }
    }
}
