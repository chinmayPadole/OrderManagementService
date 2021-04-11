using OrderManagementService.Data.Models.Customer;
using OrderManagementService.Gateways;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementService.CustomerStore
{
    public class CustomerStore : ICustomerStore
    {
        public void AddCustomer(CreateCustomerRequest request)
        {
            using (var context = new CustomerEntities())
            {
                try
                {
                    var addCustomerRequest = request.ToModel();
                    var result = context.AddCustomer(addCustomerRequest.Id, addCustomerRequest.Name, addCustomerRequest.Email, addCustomerRequest.Password);

                    context.SaveChanges();

                    if (result == -1)
                    {
                        throw new Exception($"Customer with Email {addCustomerRequest.Email} already exists");
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
