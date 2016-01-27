using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fabrik.Common.Web;

namespace Constella.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public RedirectResult RedirIndex()
        {
            return Redirect("/Home/Index");
        }

        public ActionResult Info()
        {
            return View();
        }

        public ActionResult Robots()
        {
            Response.ContentType = "text/plain";
            return View();
        }

        public ActionResult Sitemap()
        {
            var sitemapItems = new List<SitemapItem>
            {
                new SitemapItem(Url.QualifiedAction("Index", "Home"), changeFrequency: SitemapChangeFrequency.Always, priority: 1.0)
            };
            return new SitemapResult(sitemapItems);
        }
    }
}