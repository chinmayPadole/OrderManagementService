using OrderManagementService.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementService.DataContract.V1
{
    public static class GetOrderRequestTranslator
    {
        public static GetOrdersRequest ToModel(this GetAllOrderRequest request)
        {
            return new GetOrdersRequest() {
                PageSize = request.Filters.PageSize,
                PageIndex = request.Filters.PageIndex,
                OrderBy = request.Filters.OrderBy
            };
        }
    }
}
