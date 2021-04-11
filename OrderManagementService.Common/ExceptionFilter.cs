using OrderManagementService.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Filters;

namespace OrderManagementService.Common
{
    public class ExceptionFilter : ExceptionFilterAttribute, IExceptionFilter
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            BaseApplicationException res = null;

            if (actionExecutedContext.Exception is BaseApplicationException)
            {
                res = actionExecutedContext.Exception as BaseApplicationException;
            }
            else
            {
                //overriding exception type to return exception in proper format
                res = new BaseApplicationException("500", actionExecutedContext.Exception.Message);
            }
            var error = Newtonsoft.Json.JsonConvert.SerializeObject(res.BaseException);



            HttpResponseMessage response = new HttpResponseMessage(res.HttpStatusCode)
            {
                Content = new StringContent(error),
                ReasonPhrase = "Internal Server Error. Please check logs for more details.",
            };

            actionExecutedContext.Response = response;
        }
    }
}
