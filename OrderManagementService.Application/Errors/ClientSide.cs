using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementService.Application
{
    public static partial class Errors
    {
        public static partial class ClientSide
        {

            public static BaseApplicationException InvalidRequest()
            {
                return new BadRequestException("404", "Invalid Request", HttpStatusCode.BadRequest);
            }
        }
    }
}
