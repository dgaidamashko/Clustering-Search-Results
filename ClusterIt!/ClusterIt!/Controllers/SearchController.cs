using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClusterIt_.Controllers
{
    public class SearchController : Controller
    {

        [HttpGet]
        public ActionResult SearchResponse(string query, int group=1)
        {
            /*Getting results from Ya.XML, clusterisation, etc*/
            ViewData["query"] = query;
            int[] temp = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };
            ViewData["list"] = temp;
            return View();
        }
    }
}