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
        public ActionResult Index()
        {
                ViewBag.Controller = "HomeController";
                ViewBag.Action = "Index";
                return View();
        }

        /*public RedirectResult Index(string query)
        {
            return Redirect("/Search/SearchResponse?query=" + query + "&group=1");
        }*/

        public RedirectResult RedirIndex()
        {
            return Redirect("/Home/Index/");
        }
    }
}