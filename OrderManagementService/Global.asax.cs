using OrderManagementService;
using System;
using System.Web.Http;

namespace OrderManagementServiceService
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            Bootstrapper.Run();
        }
    }
}
