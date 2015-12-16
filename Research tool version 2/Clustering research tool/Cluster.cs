using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Clustering_research_tool
{
    class Cluster
    {
        public List<Vertex> Data;

        public Cluster()
        {
            Data = new List<Vertex>();
        }

        public List<Tags> GetWds()
        {
            List<Tags> result = new List<Tags>();
            for (int i = 0; i < Data.Count; i++)
            {
                if (Data[i].Data is Word)
                {
                    result.Add(Data[i].Data);
                }
            }
            return result;
        }

        public List<Tags> GetTxts()
        {
            List<Tags> result = new List<Tags>();
            for (int i = 0; i < Data.Count; i++)
            {
                if (Data[i].Data is TextTitle)
                {
                    result.Add(Data[i].Data);
                }
            }
            return result;
        }

        public void ConvexHull(Graphics g)
        {
            bool include = true;
            bool first;
            bool orient = true;
            for (int i = 0; i < Data.Count; i++)
            {
                for (int j = i + 1; j < Data.Count; j++)
                {
                    first = true;
                    for (int a = 0; a < Data.Count; a++)
                    {
                        if (a != i && a != j)
                        {

                            if (!LineCalculations.CheckLine(Data[i], Data[j], Data[a]))
                            {
                                if (first) { orient = LineCalculations.HighCheck(Data[i], Data[j], Data[a]); first = false; }

                                if (LineCalculations.HighCheck(Data[i], Data[j], Data[a]) != orient) include = false;

                            }
                        }
                    }

                    if (include) LineCalculations.ConnectDots(Data[i], Data[j], g);
                    include = true;
                }
            }
        }
    }
}