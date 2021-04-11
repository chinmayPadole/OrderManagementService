using OrderManagementService.Application;
using OrderManagementService.DataContract.V1;
using System;
using System.Web.Http;

namespace OrderManagementService.Controllers
{
    public class CustomerController : ApiController
    {
        private ICustomerService _customerService;
        private readonly IValidatorFactory _validatorFactory;
        public CustomerController(ICustomerService customerService, IValidatorFactory validatorFactory)
        {
            _customerService = customerService;
            _validatorFactory = validatorFactory;
        }
        
        [Route("api/v1.0/customer/get")]
        [HttpGet]
        public DataContract.V1.GetCustomerResponse Get(DataContract.V1.GetCustomerRequest request)
        {
            throw new NotImplementedException();
        }

        [Route("api/v1.0/customer/create")]
        [HttpPost]
        public IHttpActionResult CreateCustomer([FromBody]DataContract.V1.CreateCustomerRequest request)
        {
            var validator = new DataContract.V1.CreateCustomerRequestValidator();
            request.Validate(validator);

            _customerService.CreateCustomer(request.ToModel());

            return Ok();
        }
    }
}
