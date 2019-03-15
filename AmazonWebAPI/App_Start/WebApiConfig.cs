using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace AmazonWebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
           // config.Routes.MapHttpRoute(
           //   name: "GetAllProduct",
           //   routeTemplate: "api/{controller}/{action}",
           //    defaults: new { Action = "Get", id = RouteParameter.Optional }
           //  );
           // config.Routes.MapHttpRoute(
           // name: "GetProductOfType",
           // routeTemplate: "api/{controller}/{action}/{id}",
           //  defaults: new { Action = "GetOfType", id = RouteParameter.Optional }
           //);
        }
    }
}
