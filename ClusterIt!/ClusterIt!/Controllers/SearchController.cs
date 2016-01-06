using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Yandex.XML.Search;

namespace ClusterIt_.Controllers
{
    public class SearchController : Controller
    {

        class A
        {
            List<int> l=new List<int>();
            public A(int[] arr)
            {
                for (int i = 0; i < arr.Length; i++)
                { l.Add(arr[i]); }
            }
            public List<int> ArrL
            {
                get { return l; }
                set { l = value; }
            }
        }

        [HttpGet]
        public ActionResult SearchResponse(string query, int group=1)
        {
            /*Getting results from Ya.XML, clusterisation, etc*/
            
            //
            ViewData["query"] = query;

            int[] temp = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };
            object B = new A(temp);
            List<int> l = new List<int>();
            foreach (int elem in temp)
            {
                l.Add(elem);
            }
            ViewData["list"] = l;
            return View();
        }

        private List<YaSearchResult> YaSearch(string query, int group)
        {
            string user = "dan-gai";
            string key = "03.56416762:5589252e96061e5a63e0be3823f0101b";
            Yandex.XML.Search.APICredentials _DefaultCredential = new APICredentials();
            _DefaultCredential.User = user;
            _DefaultCredential.Key = key;
            YandexRegion _region = YandexRegion.GetList().FirstOrDefault(n => n.StringName.Contains("Москва"));

            YandexSearchQuery _query = new YandexSearchQuery(query, _DefaultCredential, _region, RequestMethodEnum.POST);
            List<YaSearchResult> resultList = _query.GetResponseToList();
            return resultList;
        }
    }
}