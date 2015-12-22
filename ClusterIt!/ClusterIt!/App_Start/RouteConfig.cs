using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Http;

namespace ClusterIt_
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

           routes.MapRoute(
                name: "Search",
                url: "search/{query}/{group}",
                defaults: new { controller = "Search", action = "Response", query = UrlParameter.Optional, group = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}",
                defaults: new { controller = "Home", action = "RedirIndex" }
                
            );

            /*routes.MapRoute(
                name: "SearchRedir",
                url: "Home/Index{query}",
                defaults: new { controller = "Home", action = "RedirQuery", query = UrlParameter.Optional }
            );*/
        }
    }
}
