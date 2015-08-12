using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Graphs
{
    class Graph
    {
        float max = float.MaxValue;
        public List<Vertex> V;
        public List<Edge> E;
        public Graph()
        {
            V = new List<Vertex>();
            E = new List<Edge>();
        }

        public void FindingMinWay(Vertex first, Vertex last)
        {
            first.t = 0;
            Vertex temp;
            List<Vertex> neighbours = new List<Vertex>();
            while (last.p == max)
            {
                temp = Mint();
                temp.p = temp.t;
                neighbours = new List<Vertex>();
                FindingNeighbours1(neighbours, temp);
                ChangeMarkerT(neighbours, temp);
            }
            temp = last;
            while (temp != first)
            {
                neighbours = new List<Vertex>();
                FindingNeighbours(neighbours, temp);
                for (int i = 0; i < neighbours.Count; i++)
                {
                    double w = FindEdge(temp, neighbours[i]).Weight;
                    if (Math.Round(temp.p - neighbours[i].p, 3) == Math.Round(w, 3))
                    {
                        FindEdge(temp, neighbours[i]).optimal = true;
                        temp = neighbours[i];
                        break;
                    }
                }
            }
        }

        public void FindMinSpanTree(Vertex first)
        {
            first.t = 0;
            Vertex temp = first;
            List<Vertex> neighbours = new List<Vertex>();
            List<Vertex> Q = new List<Vertex>();
            while (Gone())
            {
                temp = Mint();
                temp.p = temp.t;
                neighbours = new List<Vertex>();
                FindingNeighbours1(neighbours, temp);
                ChangeMarkerT2(neighbours, temp);
                Q.Add(temp);
            }
            for (int i = 1; i < Q.Count; i++)
            {
                Edge e = FindEdge(Q[i], Q[i].prev);
                e.optimal = true;
            }          
            
        }


        public bool IsCon()
        {
            for (int i = 0; i < V.Count; i++)
            {
                V[i].cocheck = 1;
            }
            V[0].cocheck = 2;
            while (IsConPrior(2))
            {
                for (int i = 0; i < V.Count; i++)
                {
                    if (V[i].cocheck == 2)
                    {
                        List<Vertex> n = new List<Vertex>();
                        V[i].cocheck = 3;
                        FindingNeighbours(n, V[i]);
                        for (int j = 0; j < n.Count; j++)
                        {
                            if (n[j].cocheck == 1)
                                n[j].cocheck = 2;
                        }
                    }
                }
            }
            if (IsConPrior(1)) return false;
            return true;
        }

        //Формирование списка вершин в минимальном остовном дереве/графе оптимального пути
        public List<Vertex> IsConList(Vertex begin)
        {
            List<Vertex> Q = new List<Vertex>();
            Q.Remove(begin);
            Q.Insert(0, begin);
            for (int i = 0; i < V.Count; i++)
            {
                V[i].cocheck = 1;
            }
            Q[0].cocheck = 2;
            while (IsConPrior(2))
            {
                for (int i = 0; i < V.Count; i++)
                {
                    if (V[i].cocheck == 2)
                    {
                        List<Vertex> n = new List<Vertex>();
                        V[i].cocheck = 3;
                        Q.Add(V[i]);
                        FindingNeighbours(n, V[i]);
                        for (int j = 0; j < n.Count; j++)
                        {
                            if (n[j].cocheck == 1)
                                n[j].cocheck = 2;
                        }
                    }
                }
            }
            return Q;
        }

        //Проверка на наличие вершины в списке
        public static bool IsConVerx(List<Vertex> Q, Vertex v)
        {
            bool End = false;
            for (int i = 0; i < Q.Count; i++)
            {
                if (Q[i] == v) End = true;
            }
            if (End) return true;
            return false;
        }

        //
        public bool IsConPrior(int n)
        {
            for (int i = 0; i < V.Count; i++)
            {
                if (V[i].cocheck == n)
                    return true;
            }
            return false;
        }

        //Находение ребра в списке ребер по заданным вершинам
        public Edge FindEdge(Vertex v1, Vertex v2)
        {
            Edge temp = null;
            for (int j = 0; j < E.Count; j++)
            {
                if ((E[j].V1 == v1 && E[j].V2 == v2) || (E[j].V2 == v1 && E[j].V1 == v2))
                {
                    temp = E[j];
                }
            }
            return temp;
        }

        //Нахождение вершины с минимальным приоритетным коэффициентом
        public Vertex Mint()
        {
            Vertex temp = null;
            for (int i = 0; i < V.Count; i++)
            {
                if (!V[i].wasMin)
                {
                    temp = V[i];
                    break;
                }
            }
            for (int i = 0; i < V.Count; i++)
            {
                if (V[i].t <= temp.t && V[i].p == max)
                {
                    if (!V[i].wasMin)
                    {
                        temp = V[i];
                    }
                }
            }
            temp.wasMin = true;
            return temp;
        }

        //Нахождение у вершины соседей с максимальным временным приоритетом
        public void FindingNeighbours1(List<Vertex> l, Vertex temp)
        {
            for (int j = 0; j < E.Count; j++)
            {
                if (E[j].V1 == temp && E[j].V2.p == max)
                {
                    l.Add(E[j].V2);
                }
                else if (E[j].V2 == temp && E[j].V1.p == max)
                {
                    l.Add(E[j].V1);
                }
            }
        }

        //Нахождение соседей вершины
        public void FindingNeighbours(List<Vertex> l, Vertex temp)
        {
            for (int j = 0; j < E.Count; j++)
            {
                if (E[j].V1 == temp)
                {
                    l.Add(E[j].V2);
                }
                else if (E[j].V2 == temp)
                {
                    l.Add(E[j].V1);
                }
            }
        }

        //
        public void ChangeMarkerT(List<Vertex> l, Vertex temp)
        {
            double w = 0;
            for (int i = 0; i < l.Count; i++)
            {
                w = (float)FindEdge(temp, l[i]).Weight;
                if ((l[i].t > temp.t + w))
                {
                    l[i].t = (float)(temp.t + w);
                    l[i].prev = temp;
                }

            }
        }

        //Проверка на конец прохождения по графу
        public bool Gone()
        {
            for (int i = 0; i < V.Count; i++)
            {
                if (V[i].p == max) return true;
            }
            return false;
        }

        //
        public void ChangeMarkerT2(List<Vertex> l, Vertex temp)
        {
            double w = 0;
            for (int i = 0; i < l.Count; i++)
            {
                w = (float)FindEdge(temp, l[i]).Weight;
                if (l[i].t > w)
                {
                    l[i].t = (float)w;
                    l[i].prev = temp;
                }
            }
        }
    }
}
