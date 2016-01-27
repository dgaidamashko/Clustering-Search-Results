using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Http;

namespace Constella
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Robots.txt",
                url: "robots.txt",
                defaults: new { controller = "Home", action = "Robots"}
                );

            routes.MapRoute(
                name: "Sitemap.xml",
                url: "sitemap",
                defaults: new { controller = "Home", action = "Sitemap"}
                );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{*catchall}",
                defaults: new { controller = "Home", action = "RedirIndex" }

            );

            routes.MapRoute(
                name: "Search",
                url: "Search/SearchResponse/{query}/{group}",
                defaults: new { controller = "Search", action = "SearchResponse", query = RouteParameter.Optional, group = RouteParameter.Optional }
            );
        }
    }
}
