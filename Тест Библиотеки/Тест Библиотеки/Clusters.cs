using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClusteringSearchResults
{
    class Clusters
    {
        Graph G;
        int longestEdgeindex;
        int slongestEdgeindex;
        double lEdgeWeight;
        double slEdgeWeight;
        List<Cluster> C;
        Cluster Texts;
        Tags[] textTitles;
        public double r = 0;

        public Clusters(double[,] A, Tags[] texts, Tags[] words)
        {
            textTitles = texts;
            C = new List<Cluster>();
            G = new Graph();
            Texts = new Cluster();
            double[] W = new double[A.GetLength(0)];
            double[,] U = new double[A.GetLength(0), A.GetLength(1)];
            double[,] VT = new double[A.GetLength(1), A.GetLength(1)];
            alglib.rmatrixsvd(A, A.GetLength(0), A.GetLength(1), 1, 1, 0, out W, out U, out VT);
            #region
            /*************************************************************************
Singular value decomposition of a rectangular matrix.

The algorithm calculates the singular value decomposition of a matrix of
size MxN: A = U * S * V^T

The algorithm finds the singular values and, optionally, matrices U and V^T.
The algorithm can find both first min(M,N) columns of matrix U and rows of
matrix V^T (singular vectors), and matrices U and V^T wholly (of sizes MxM
and NxN respectively).

Take into account that the subroutine does not return matrix V but V^T.

Input parameters:
   A           -   matrix to be decomposed.
                   Array whose indexes range within [0..M-1, 0..N-1].
   M           -   number of rows in matrix A.
   N           -   number of columns in matrix A.
   UNeeded     -   0, 1 or 2. See the description of the parameter U.
   VTNeeded    -   0, 1 or 2. See the description of the parameter VT.
   AdditionalMemory -
                   If the parameter:
                    * equals 0, the algorithm doesn’t use additional
                      memory (lower requirements, lower performance).
                    * equals 1, the algorithm uses additional
                      memory of size min(M,N)*min(M,N) of real numbers.
                      It often speeds up the algorithm.
                    * equals 2, the algorithm uses additional
                      memory of size M*min(M,N) of real numbers.
                      It allows to get a maximum performance.
                   The recommended value of the parameter is 2.

Output parameters:
   W           -   contains singular values in descending order.
   U           -   if UNeeded=0, U isn't changed, the left singular vectors
                   are not calculated.
                   if Uneeded=1, U contains left singular vectors (first
                   min(M,N) columns of matrix U). Array whose indexes range
                   within [0..M-1, 0..Min(M,N)-1].
                   if UNeeded=2, U contains matrix U wholly. Array whose
                   indexes range within [0..M-1, 0..M-1].
   VT          -   if VTNeeded=0, VT isn’t changed, the right singular vectors
                   are not calculated.
                   if VTNeeded=1, VT contains right singular vectors (first
                   min(M,N) rows of matrix V^T). Array whose indexes range
                   within [0..min(M,N)-1, 0..N-1].
                   if VTNeeded=2, VT contains matrix V^T wholly. Array whose
                   indexes range within [0..N-1, 0..N-1].
*************************************************************************/
            #endregion
            //Добавление вершин из матриц
            for (int i = 0; i < U.GetLength(0); i++)
            {
                G.V.Add(new Vertex(words[i], U[i, 0], U[i, 1], U[i, 2]));
            }
            for (int i = 0; i < VT.GetLength(1); i++)
            {
                G.V.Add(new Vertex(texts[i], VT[0, i], VT[1, i], VT[2, i]));
            }
            //добавление рёбер
            for (int i = 0; i < G.V.Count; i++)
            {
                for (int j = i + 1; j < G.V.Count; j++)
                {
                    G.E.Add(new Edge(G.V[i], G.V[j]));
                }
            }

            for (int i = 0; i < texts.Length; i++)
            {
                for (int j = 0; j < G.V.Count; j++)
                {
                    if (texts[i].GetTag == G.V[j].Data.GetTag)
                    {
                        Texts.Data.Add(G.V[j]);
                    }
                }
            }
        }

        public void ClusterSelection(double k, int n) //При параметре n равном 1, удаление зависит от длины второго по длине ребра. При n = 2, удаление зависит от средней длины ребра. При других n удаление зависит от средней длины ребра без учёта самого длинного
        {
            
                G.FindMinSpanTree(G.V[0]);
                for (int i = 0; i < G.E.Count; i++)
                {
                    if (!G.E[i].optimal)
                    {
                        G.E.Remove(G.E[i]);
                        i--;
                    }
                }
            
                LongestEdge();
                if (n == 1)
                {
                    while (lEdgeWeight > k * slEdgeWeight && G.E.Count != 1)
                    {
                        G.E.Remove(G.E[longestEdgeindex]);
                        LongestEdge();
                    }
                }
                else
                {
                    if (n == 2)
                    {
                        while (lEdgeWeight > k * AverageEdgeWeight(1) && G.E.Count != 1)
                        {
                            G.E.Remove(G.E[longestEdgeindex]);
                            LongestEdge();
                        }
                    }
                    else 
                    {
                        if (n == 3)
                        {
                            double temp = AverageEdgeWeight(1);
                            while (lEdgeWeight > k * temp && G.E.Count != 1)
                            {
                                G.E.Remove(G.E[longestEdgeindex]);
                                LongestEdge();
                            }
                        }
                        else
                        {
                            if (n == 4)
                            {
                                while (lEdgeWeight > k * AverageEdgeWeight(2) && G.E.Count != 1)
                                {
                                    G.E.Remove(G.E[longestEdgeindex]);
                                    LongestEdge();
                                }
                            }
                            else
                            {
                                k = lEdgeWeight / AverageEdgeWeight(1);
                                r = k;
                                while (lEdgeWeight > k * AverageEdgeWeight(1) && G.E.Count != 1)
                                {
                                    G.E.Remove(G.E[longestEdgeindex]);
                                    LongestEdge();
                                }
                            }
                        }
                    }
                }
                Clusterize();
                
                for (int i = 0; i < Texts.Data.Count; i++)
                {
                    bool exists = false;
                    for (int q = 0; q < C.Count; q++)
                    {
                        for (int j = 0; j < C[q].Data.Count; j++)
                        {
                            if (C[q].Data[j] == Texts.Data[i] && C[q].Data.Count > 1) exists = true;
                        }
                    }
                    if (!exists)
                    {
                        AddToClosestCluster(Texts.Data[i]);
                    }
                }
                for (int i = 0; i < C.Count; i++)
                {
                    if (C[i].Data.Count <= 1)
                    {
                        C.Remove(C[i]);
                        i--;
                    }
                }
                for (int i = 0; i < C.Count; i++)
                {
                    if (ConsistsOfTexts(C[i]))
                    {
                        AddToClosestCluster(C[i]);
                        C.Remove(C[i]);
                        i--;
                    }
                }
        }

        public void LongestEdge()
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

        public double AverageEdgeWeight(int a)
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

        //распределяет вершины по кластерам
        public void Clusterize()
        {
            C = new List<Cluster>();
            for (int i = 0; i < G.V.Count; i++)
            {
                bool exists = false;
                for (int j = 0; j < C.Count; j++)
                {
                    bool tobreak = false;
                    for (int k = 0; k < C[j].Data.Count; k++)
                    {
                        if (G.V[i] == C[j].Data[k])
                        {
                            exists = true;
                            tobreak = true;
                            break;
                        }
                    }
                    if (tobreak) break;
                }
                if (!exists)
                {
                    C.Add(new Cluster());
                    C[C.Count - 1].Data.Add(G.V[i]);
                    ClusterizeStep(C[C.Count - 1], G.V[i], true);
                }
            }
        }

        void ClusterizeStep(Cluster cl, Vertex v, bool firststep)
        {

            if (firststep)
            {
                for (int i = 0; i < G.E.Count; i++)
                {
                    if (G.E[i].V1 == v)
                    {
                        ClusterizeStep(cl, G.E[i].V2, false);
                    }
                    else if (G.E[i].V2 == v)
                    {
                        ClusterizeStep(cl, G.E[i].V1, false);
                    }
                }
            }
            else
            {
                bool exists = false;
                for (int k = 0; k < cl.Data.Count; k++)
                {
                    if (v == cl.Data[k])
                    {
                        exists = true;
                        break;
                    }
                }
                if (!exists)
                {
                    cl.Data.Add(v);
                    for (int i = 0; i < G.E.Count; i++)
                    {
                        if (G.E[i].V1 == v)
                        {
                            ClusterizeStep(cl, G.E[i].V2, false);
                        }
                        else if (G.E[i].V2 == v)
                        {
                            ClusterizeStep(cl, G.E[i].V1, false);
                        }
                    }
                }
            }
        }

        public bool TextsPacked()
        {
            bool fullpackage = true;
            
            for (int i = 0; i < textTitles.Length; i++)
            {
                bool textpacked = false;
                for (int j = 0; j < C.Count; j++)
                {
                    for (int q = 0; q < C[j].Data.Count; q++)
                    {
                        if (textTitles[i].GetTag == C[j].Data[q].Data.GetTag)
                        {
                            if (C[j].Data.Count > 1)
                            {
                                textpacked = true;
                            }
                        }
                    }
                }
                if (!textpacked)
                {
                    fullpackage = false;
                    break;
                }
            }
            return fullpackage;

        }

        //Определяет, состоит ли кластер лишь из текстов
        public bool ConsistsOfTexts(Cluster cl)
        {
            bool allexist = true;
            for (int i = 0; i < cl.Data.Count; i++)
            {
                bool oneoftexts = false;
                for (int j = 0; j < Texts.Data.Count; j++)
                {
                    if (cl.Data[i].Data.GetTag == Texts.Data[j].Data.GetTag)
                    {
                        oneoftexts = true;
                    }
                }
                if (!oneoftexts)
                {
                    allexist = false;
                    break;
                }
            }
                if (allexist)
                {
                    return true;
                }
            return false;
        }

        //Добавляет вершину к ближайшему кластеру
        public void AddToClosestCluster(Vertex v)
        {
            Graph temp = new Graph(G.V);
            for (int i = 0; i < temp.V.Count; i++)
            {
                for (int j = i + 1; j < temp.V.Count; j++)
                {
                    temp.E.Add(new Edge(temp.V[i], temp.V[j]));
                }
            }

            Vertex neighbour = G.V[0];
            double shortestedgeweight = double.MaxValue;
            for(int i = 0; i < temp.E.Count; i++)
            {
                if (temp.E[i].V1 == v)
                {
                    if (temp.E[i].Weight < shortestedgeweight)
                    {
                        shortestedgeweight = temp.E[i].Weight;
                        neighbour = temp.E[i].V2;
                    }
                }
                else 
                {
                    if (temp.E[i].V2 == v)
                    {
                        if (temp.E[i].Weight < shortestedgeweight)
                        {
                            shortestedgeweight = temp.E[i].Weight;
                            neighbour = temp.E[i].V1;
                        }
                    }
                }
            }
                for (int i = 0; i < C.Count; i++)
                {
                    for (int j = 0; j < C[i].Data.Count; j++)
                    {
                        if (C[i].Data[j] == neighbour)
                        {
                            C[i].Data.Add(v);
                        }
                    }
                }
        }

        //Добавляет кластер к ближайшему кластеру
        public void AddToClosestCluster(Cluster cl)
        {
            Graph temp = new Graph(G.V);
            for (int i = 0; i < temp.V.Count; i++)
            {
                for (int j = i + 1; j < temp.V.Count; j++)
                {
                    temp.E.Add(new Edge(temp.V[i], temp.V[j]));
                }
            }

            Vertex neighbour = G.V[0];
            double shortestedgeweight = double.MaxValue;
            for (int j = 0; j < cl.Data.Count; j++)
            {
                for (int i = 0; i < temp.E.Count; i++)
                {
                    if (temp.E[i].V1 == cl.Data[j])
                    {
                        if (temp.E[i].Weight < shortestedgeweight)
                        {
                            bool access = true;
                            for (int q = 0; q < cl.Data.Count; q++)
                            {
                                if (temp.E[i].V2 == cl.Data[q] && q != j)
                                {
                                    access = false;
                                }
                            }
                            if (access)
                            {
                                shortestedgeweight = temp.E[i].Weight;
                                neighbour = temp.E[i].V2;
                            }
                        }
                    }
                    else
                    {
                        if (temp.E[i].V2 == cl.Data[j])
                        {
                            if (temp.E[i].Weight < shortestedgeweight)
                            {
                                bool access = true;
                                for (int q = 0; q < cl.Data.Count; q++)
                                {
                                if (temp.E[i].V1 == cl.Data[q] && q != j)
                                {
                                    access = false;
                                }
                                }
                            if (access)
                            {
                                shortestedgeweight = temp.E[i].Weight;
                                neighbour = temp.E[i].V1;
                            }
                            }
                        }
                    }
                }
            }
                for (int i = 0; i < C.Count; i++)
                {
                    for (int j = 0; j < C[i].Data.Count; j++)
                    {
                        if (C[i].Data[j] == neighbour)
                        {
                            for (int q = 0; q < cl.Data.Count; q++)
                            {
                                    C[i].Data.Add(cl.Data[q]);
                            }
                            break;
                        }
                    }
                }
        }

        public Graph GetGraph
        {
            get { return G; }
        }

        public List<Cluster> GetClusters
        {
            get { return C; }
        }
    }
}
