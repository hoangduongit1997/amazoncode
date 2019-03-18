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

           

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
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
           //  defaults: new { controller = "User", action = "Login"}
        // );
        }
    }
}
