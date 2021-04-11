using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementService.Application
{
    public static class GetOrderRequestTranslator
    {
        public static Gateways.GetOrdersRequest ToModel(this GetOrdersRequest request)
        {
            return new Gateways.GetOrdersRequest()
            {
                PageSize = request.PageSize,
                PageIndex = request.PageIndex,
                OrderBy = request.OrderBy
            };
        }
    }

}
