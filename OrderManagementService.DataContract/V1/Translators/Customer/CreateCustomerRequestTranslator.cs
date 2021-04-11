using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementService.DataContract.V1
{
    public static class CreateCustomerRequestTranslator
    {
        public static Application.CreateCustomerRequest ToModel(this CreateCustomerRequest request)
        {
            return new Application.CreateCustomerRequest()
            {
                Name = request.Name,
                Email = request.Email,
                Password = request.Password
            };
        }
    }
}
