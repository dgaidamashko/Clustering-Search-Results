using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClusterIt_.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index(string query)
        {
            ViewBag.Controller = "HomeController";
            ViewBag.Action = "Index";
            return View("Index");
        }

        public RedirectResult RedirIndex()
        {
            return RedirectPermanent("/Home/Index");
        }

        /*public RedirectResult RedirQuery(string query)
        {
            return RedirectPermanent("/Search/Response?query="+query+"&group=1");
        }*/
    }
}