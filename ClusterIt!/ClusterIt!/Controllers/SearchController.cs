using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Yandex.XML.Search;
using Clustering_research_tool;

namespace ClusterIt_.Controllers
{
    public class SearchController : Controller
    {
        Clusters Ctool;
        List<List<Tags>> words;
        List<List<Tags>> TextTitles;
        List<YaSearchResult> results;
        List<List<YaSearchResult>> ResultCluster;
        [HttpGet]
        public ActionResult SearchResponse(string query, int group=1)
        {
            /*Getting results from Ya.XML, clusterisation, etc*/
            results = YaSearch(query, group);
            Clusterisation(GetTexts());
            ResultCluster = Classification();
            ViewData["query"] = query;
            ViewData["clusterresults"] = ResultCluster;
            ViewData["clusterwords"] = words;
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
            for (int i=0;i<TextTitles.Count;i++)
            {
                ResultCluster.Add(new List<YaSearchResult>());
                for (int j=0;j<TextTitles[i].Count;j++)
                {
                    ResultCluster[i].Add(results[Convert.ToInt32(TextTitles[i][j])-1]);
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

            YandexSearchQuery _query = new YandexSearchQuery(query, _DefaultCredential, _region, RequestMethodEnum.POST);
            List<YaSearchResult> resultList = _query.GetResponseToList();
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