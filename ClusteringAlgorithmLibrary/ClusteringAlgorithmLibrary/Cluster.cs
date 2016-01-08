using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Clustering_research_tool
{
    public class Cluster
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

        public Vertex ClusterCenter
        {
            get
            {
                double sumx = 0;
                double sumy = 0;
                double sumz = 0;
                for (int i = 0; i < Data.Count; i++)
                {
                    sumx += Data[i].x;
                    sumy += Data[i].y;
                    sumz += Data[i].z;
                }
                return new Vertex(Data[0].Data, sumx / Data.Count, sumy / Data.Count, sumz / Data.Count);
            }
        }

        public static bool ContainsDocs(Cluster cl)
        {
            bool pass = false;
            for (int i = 0; i < cl.Data.Count; i++)
            {
                if (cl.Data[i].Data is TextTitle)
                {
                    pass = true;
                    break;
                }
            }
            return pass;
        }
    }
}