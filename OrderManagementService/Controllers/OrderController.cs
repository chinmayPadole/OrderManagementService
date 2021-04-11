using OrderManagementService.Application;
using OrderManagementService.DataContract.V1;
using System.Web.Http;

namespace OrderManagementService.Controllers
{
    public class OrderController : ApiController
    {
        private IOrderService _orderService;
        private readonly IValidatorFactory _validatorFactory;
        public OrderController(IOrderService orderService, IValidatorFactory validatorFactory)
        {
            _orderService = orderService;
            _validatorFactory = validatorFactory;
        }

        // POST: api/order/create
        [Route("api/v1.0/order/create")]
        [HttpPost]
        public IHttpActionResult CreateOrder([FromBody]OrderManagementService.DataContract.V1.CreateOrderRequest request)
        {
            var validator = new CreateOrderRequestValidator() ;
            request.Validate(validator);

            _orderService.CreateOrder(request.ToModel());
            return Ok();
        }

        // POST: api/order/create
        [Route("api/v1.0/order/getAll")]
        [HttpGet]
        public GetAllOrdersResponse GetAllOrders(GetAllOrderRequest request)
        {
            var response =  _orderService.GetOrders(request.ToModel());
            return response.ToDataContract();
        }
    }
}
