using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Yandex.XML.Search;
using Clustering_research_tool;

namespace Constella.Controllers
{
    public class SearchController : Controller
    {
        Clusters Ctool;
        List<List<Tags>> words;
        List<List<Tags>> TextTitles;
        List<YaSearchResult> results;
        List<List<YaSearchResult>> ResultCluster;
        static string found_docs_human;
        static string error_code;
        bool correct_query;
        [HttpGet]
        public ActionResult SearchResponse(string query="", int group = 1)
        {
            correct_query = true;
            if (query == "")
            {
                correct_query = false;
                ViewBag.query = "";
            }
            else
            {
                /*Getting results from Ya.XML, clusterisation, etc*/
                results = YaSearch(query, group);
                ViewData["found"] = found_docs_human;
                ViewData["error"] = error_code;
                if (results.Count != 0)
                {
                    Clusterisation(GetTexts());
                    ResultCluster = Classification();
                    ViewData["clusterresults"] = ResultCluster;
                    ViewData["clusterwords"] = words;
                }
                else
                {
                    ViewData["clusterresults"] = null;
                    ViewData["clusterwords"] = null;
                }
            }
            ViewBag.query = query;
            ViewData["correct"] = Convert.ToString(correct_query);
            return View();
        }

        private void Clusterisation(List<string> input)
        {
            TextOperations.InitParams(input);
            TextOperations.TagNullifier();
            for (int i = 0; i < TextOperations.ts.Count; i++)
            {
                TextOperations.Tag.Add(TextOperations.Frequency(TextOperations.vClusterize(TextOperations.ts[i].ToString())));
            }
            TextOperations.FormMatrix();
            Ctool = new Clusters(TextOperations.GetMatrix, TextOperations.GetTextTitles, TextOperations.GetWords);
            MethodDecision(0);
            words = Ctool.GetWdsFromClst();
            TextTitles = Ctool.GetTxtsFromClst();
        }

        private void MethodDecision(int method)
        {
            switch (method)
            {
                case 0: Ctool.dbscan(0.3, 1, Ctool.WordVertexes); Ctool.PostClustering(); break;
            }
        }

        private List<List<YaSearchResult>> Classification()
        {
            ResultCluster = new List<List<YaSearchResult>>();
            for (int i = 0; i < TextTitles.Count; i++)
            {
                ResultCluster.Add(new List<YaSearchResult>());
                for (int j = 0; j < TextTitles[i].Count; j++)
                {
                    ResultCluster[i].Add(results[Convert.ToInt32(TextTitles[i][j]) - 1]);
                }
            }
            return ResultCluster;
        }

        private static List<YaSearchResult> YaSearch(string query, int group)
        {
            string user = "dan-gai";
            string key = "03.56416762:5589252e96061e5a63e0be3823f0101b";
            Yandex.XML.Search.APICredentials _DefaultCredential = new APICredentials();
            _DefaultCredential.User = user;
            _DefaultCredential.Key = key;
            YandexRegion _region = YandexRegion.GetList().FirstOrDefault(n => n.StringName.Contains("Москва"));
            YandexSearchQuery _query = new YandexSearchQuery(query, group - 1, _DefaultCredential, _region, RequestMethodEnum.POST);
            List<YaSearchResult> resultList = _query.GetResponseToList();
            error_code = _query._error;
            found_docs_human = _query._found;
            return resultList;
        }

        private List<string> GetTexts()
        {
            List<string> texts = new List<string>();
            for (int i = 0; i < results.Count; i++)
            {
                texts.Add(results[i].Description);
            }
            return texts;
        }

    }
}