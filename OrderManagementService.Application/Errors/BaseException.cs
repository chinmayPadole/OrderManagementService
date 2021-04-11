using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementService.Application
{
    public class BaseException
    {
        public string ErrorCode { get; }
        public string ErrorMessage { get; }
        public List<Info> Info { get; } = new List<Info>();

        public BaseException(string errorCode, string errorMessage, List<Info> info = null)
        {
            this.ErrorCode = errorCode;
            this.ErrorMessage = errorMessage;
            if (info != null)
                Info.AddRange(info);
        }
    }
}
