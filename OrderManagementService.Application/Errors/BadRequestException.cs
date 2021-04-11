using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementService.Application
{
    [Serializable]
    public partial class BadRequestException : BaseApplicationException
    {
        public BadRequestException(string code, string message, HttpStatusCode httpStatusCode) : base(code, message, httpStatusCode) { }
    }
}
