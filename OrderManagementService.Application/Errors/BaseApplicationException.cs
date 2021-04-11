using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementService.Application
{
    public class BaseApplicationException : Exception
    {
        public HttpStatusCode HttpStatusCode { get; }
        public BaseException BaseException { get; set; }

        public BaseApplicationException(string errorCode, string errorMessage, HttpStatusCode httpStatusCode, List<Info> info = null) : base(errorMessage)
        {
            this.HttpStatusCode = httpStatusCode;
            BaseException = new BaseException(errorCode, errorMessage, info);
        }
        public BaseApplicationException(string message, string code) : base(message)
        {
            BaseException = new BaseException(code, message);
        }

        public BaseApplicationException(string message, string code, Exception inner) : base(message, inner)
        {
            BaseException = new BaseException(code, message);
        }
    }
}
