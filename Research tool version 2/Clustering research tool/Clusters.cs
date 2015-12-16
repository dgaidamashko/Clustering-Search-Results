using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clustering_research_tool
{
    class Clusters
    {
        List<Cluster> C;
        Cluster Texts;
        Tags[] textTitles;
        List<Vertex> V;
        public double r;

        public Clusters(double[,] A, Tags[] texts, Tags[] words)
        {
            r = 1;
            V = new List<Vertex>();
            textTitles = texts;
            C = new List<Cluster>();
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
                V.Add(new Vertex(words[i], U[i, 0], U[i, 1], U[i, 2]));
            }
            for (int i = 0; i < VT.GetLength(1); i++)
            {
                V.Add(new Vertex(texts[i], VT[0, i], VT[1, i], VT[2, i]));
            }
            
            for (int i = 0; i < texts.Length; i++)
            {
                for (int j = 0; j < V.Count; j++)
                {
                    if (texts[i].GetTag == V[j].Data.GetTag)
                    {
                        Texts.Data.Add(V[j]);
                    }
                }
            }
        }

        public void dbscan(double eps, int minPts)
        {
            C = new List<Cluster>();
            if (V == null) return;
            int clusterId = 1;
            for (int i = 0; i < V.Count; i++)
            {
                Vertex p = V[i];
                if (p.ClusterId == Vertex.UNCLASSIFIED)
                {
                    if (ExpandCluster(V, p, clusterId, eps, minPts)) clusterId++;
                }
            }
            int maxClusterId = V.OrderBy(p => p.ClusterId).Last().ClusterId;
            if (maxClusterId < 1) return;
            for (int i = 0; i < maxClusterId; i++) C.Add(new Cluster());
            foreach (Vertex p in V)
            {
                if (p.ClusterId > 0) C[p.ClusterId - 1].Data.Add(p);
            }
        }

        static List<List<Vertex>> GetClusters(List<Vertex> v, double eps, int minPts)
        {
            if (v == null) return null;
            List<List<Vertex>> clusters = new List<List<Vertex>>();
            int clusterId = 1;
            for (int i = 0; i < v.Count; i++)
            {
                Vertex p = v[i];
                if (p.ClusterId == Vertex.UNCLASSIFIED)
                {
                    if (ExpandCluster(v, p, clusterId, eps, minPts)) clusterId++;
                }
            }
            int maxClusterId = v.OrderBy(p => p.ClusterId).Last().ClusterId;
            if (maxClusterId < 1) return clusters;
            for (int i = 0; i < maxClusterId; i++) clusters.Add(new List<Vertex>());
            foreach (Vertex p in v)
            {
                if (p.ClusterId > 0) clusters[p.ClusterId - 1].Add(p);
            }
            return clusters;
        }

        static List<Vertex> GetRegion(List<Vertex> points, Vertex p, double eps)
        {
            List<Vertex> region = new List<Vertex>();
            for (int i = 0; i < points.Count; i++)
            {
                double distSquared = Vertex.EuclideDistance(p, points[i]);
                if (distSquared <= eps) region.Add(points[i]);
            }
            return region;
        }

        static bool ExpandCluster(List<Vertex> points, Vertex p, int clusterId, double eps, int minPts)
        {
            List<Vertex> seeds = GetRegion(points, p, eps);
            if (seeds.Count < minPts) // no core point
            {
                p.ClusterId = Vertex.NOISE;
                return false;
            }
            else // all points in seeds are density reachable from point 'p'
            {
                for (int i = 0; i < seeds.Count; i++) seeds[i].ClusterId = clusterId;
                seeds.Remove(p);
                while (seeds.Count > 0)
                {
                    Vertex currentP = seeds[0];
                    List<Vertex> result = GetRegion(points, currentP, eps);
                    if (result.Count >= minPts)
                    {
                        for (int i = 0; i < result.Count; i++)
                        {
                            Vertex resultP = result[i];
                            if (resultP.ClusterId == Vertex.UNCLASSIFIED || resultP.ClusterId == Vertex.NOISE)
                            {
                                if (resultP.ClusterId == Vertex.UNCLASSIFIED) seeds.Add(resultP);
                                resultP.ClusterId = clusterId;
                            }
                        }
                    }
                    seeds.Remove(currentP);
                }
                return true;
            }
        }

        public List<Vertex> GetV
        {
            get { return V; } 
        }

        public List<Cluster> GetClusterList
        {
            get { return C; }
        }
    }
}
