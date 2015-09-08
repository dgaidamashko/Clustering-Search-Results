using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Graphs
{
    class ClOperations
    {
        static int longestEdgeindex;
        static int slongestEdgeindex;
        static double lEdgeWeight;
        static double slEdgeWeight;
        public static double r = 0;

        public static void ClusterSelection(double k, Graph G , int n)
        {
            for (int i = 0; i < G.V.Count; i++)
            {
                for (int j = i + 1; j < G.V.Count; j++)
                {
                    G.E.Add(new Edge(G.V[i], G.V[j]));
                }
            }
                G.FindMinSpanTree(G.V[0]);
            for (int i = 0; i < G.E.Count; i++)
            {
                if (!G.E[i].optimal)
                {
                    G.E.Remove(G.E[i]);
                    i--;
                }
            }
            for (int i = 0; i < G.E.Count(); i++)
            {
                Form1.el += Convert.ToString(Math.Round(G.E[i].Weight, 2));
                Form1.el += "; ";
            }
            Form1.al = Convert.ToString(AverageEdgeWeight(1, G));
            LongestEdge(G);
            r =  RelCount(G);
            if (n == 1)
            {
                while (lEdgeWeight > k * slEdgeWeight)
                {
                    G.E.Remove(G.E[longestEdgeindex]);
                    LongestEdge(G);
                }
            }
            else
            {
                if (n == 2)
                {
                    while (lEdgeWeight > k * AverageEdgeWeight(1, G))
                    {
                        G.E.Remove(G.E[longestEdgeindex]);
                        LongestEdge(G);
                    }
                }
                else
                {
                    if (n == 3)
                    {
                        double temp = AverageEdgeWeight(1, G);
                        while (lEdgeWeight > k * temp)
                        {
                            G.E.Remove(G.E[longestEdgeindex]);
                            LongestEdge(G);
                        }
                    }
                    else
                    {
                        while (lEdgeWeight > k * AverageEdgeWeight(2, G))
                        {
                            G.E.Remove(G.E[longestEdgeindex]);
                            LongestEdge(G);
                        }
                    }
                }
            }
        }

        public static void LongestEdge(Graph G)
        {
            if (G.E.Count > 1)
            {
                longestEdgeindex = 0;
                lEdgeWeight = G.E[0].Weight;
                for (int i = 0; i < G.E.Count; i++)
                {
                    if (G.E[i].Weight > lEdgeWeight)
                    {
                        slEdgeWeight = lEdgeWeight;
                        slongestEdgeindex = longestEdgeindex;
                        lEdgeWeight = G.E[i].Weight;
                        longestEdgeindex = i;
                    }
                }
                for (int i = 0; i < G.E.Count; i++)
                {
                    if (i != longestEdgeindex)
                    {
                        if (G.E[i].Weight > slEdgeWeight && G.E[i].Weight != lEdgeWeight)
                        {
                            slEdgeWeight = G.E[i].Weight;
                            slongestEdgeindex = i;
                        }
                    }
                }
            }
        }

        public static double AverageEdgeWeight(int a, Graph G)
        {
            double sum = 0;
            if (a == 1)
            {
                for (int i = 0; i < G.E.Count; i++)
                {
                    sum += G.E[i].Weight;
                }
                return sum / G.E.Count;
            }
            else
            {
                for (int i = 0; i < G.E.Count; i++)
                {
                    if (i != longestEdgeindex)
                    {
                        sum += G.E[i].Weight;
                    }
                }
                return sum / (G.E.Count - 1);
            }
            /*
             Метод возвращает среднюю длину ребра графа при значении параметра, равном 1
             Метод возвращает сребнюю длину ребра без учёта самого длинного при любом другом значении параметра
             */
        }

        public static double RelCount(Graph G)
        {
            return lEdgeWeight / AverageEdgeWeight(1, G);
        }

    }
}
