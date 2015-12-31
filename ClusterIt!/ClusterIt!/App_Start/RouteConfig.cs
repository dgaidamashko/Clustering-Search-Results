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
                name: "Default",
                url: "{controller}/{action}/{*catchall}",
                defaults: new { controller = "Home", action = "RedirIndex" }
                
            );

            routes.MapRoute(
                name: "Search",
                url: "{controller}/{action}/{query}/{group}",
                defaults: new { controller = "Search", action = "SearchResponse", query = RouteParameter.Optional, group = RouteParameter.Optional },
                constraints: new { controller = "Search" }
            );
        }
    }
}
