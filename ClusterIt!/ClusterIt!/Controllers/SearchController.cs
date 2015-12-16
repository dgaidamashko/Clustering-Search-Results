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
        public ActionResult Response(string query, int group)
        {
            /*Getting results from Ya.XML, clusterisation, etc*/
            return View("ResultPage");
        }
    }
}