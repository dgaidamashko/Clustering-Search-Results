using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Clustering_research_tool
{
    public class Vertex
    {
        public int cocheck;
        public double x, y, z;
        public const int NOISE = -1;
        public const int UNCLASSIFIED = 0;
        public int ClusterId;
        public bool isin, wasMin;
        public Tags Data;
        public Vertex(Tags Data, double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            isin = false;
            wasMin = false;
            this.Data = Data;
        }
        

        public static double EuclideDistance(Vertex a, Vertex b)
        {
            return Math.Sqrt(Math.Pow(a.x - b.x, 2) + Math.Pow(a.y - b.y, 2) + Math.Pow(a.z - b.z, 2));
        }
    }
}
