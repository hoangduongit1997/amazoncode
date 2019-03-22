using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Amazon
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapMvcAttributeRoutes();


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{identifier}",
                defaults: new { controller = "Home", action = "Index", identifier = UrlParameter.Optional },
                  namespaces: new[] { "Amazon.Controllers" }
            );

            routes.MapRoute(
                name: "Product types",
                url: "ProductTypes-{typeid}",
                defaults: new { controller = "Product", action = "Index", typeid = UrlParameter.Optional },
                  namespaces: new[] { "Amazon.Controllers" }
            );
            // routes.MapRoute(
            //    name: "Defaulta",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "User", action = "Regist", id = UrlParameter.Optional }
            //);
            // routes.MapRoute(
            //    name: "Defaultfff",
            //    url: "Admin/{controller}/{action}/{id}",
            //    defaults: new { controller = "ProductAD", action = "Create", id = UrlParameter.Optional }
            //);
            // routes.MapRoute(
            //  name: "Defaultfffss",
            //  url: "{controller}/{action}",
            //  defaults: new { controller = "User", action = "Login" }
            // );

        }
    }
}
