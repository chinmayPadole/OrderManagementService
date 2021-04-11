using OrderManagementService.Common;
using System;
using System.Web.Http;

namespace OrderManagementServiceService
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Filters.Add(new ExceptionFilter());

            config.Routes.MapHttpRoute(
                name: "OrderApi",
                routeTemplate: "api/v1.0/order",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
