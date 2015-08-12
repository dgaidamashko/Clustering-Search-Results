using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RRC
{
    class Program
    {
        static void MatrixInput(ref double[,] M)
        {
            for (int i = 0; i < M.GetLength(0); i++)
            {
                for (int j = 0; j < M.GetLength(1); j++)
                {
                    Console.WriteLine("M[{0},{1}] = ", i + 1, j + 1);
                    M[i, j] = double.Parse(Console.ReadLine());
                }
            }
        }

        static void MatrixOutput(double[,] M)
        {
            for (int i = 0; i < M.GetLength(0); i++)
            {
                for (int j = 0; j < M.GetLength(1); j++)
                {
                    Console.Write("     {0}", Math.Round(M[i, j], 2));
                }
                Console.Write("\n\n");
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Set matrix params"); // first - number of rows, second - number of colums
            int a = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());
            double[,] A = new double[a, c];
            MatrixInput(ref A);
            double[] W = new double[A.GetLength(0)];
            double[,] U = new double[A.GetLength(0), A.GetLength(1)];
            double[,] VT = new double[A.GetLength(1), A.GetLength(1)];
            alglib.rmatrixsvd(A, A.GetLength(0), A.GetLength(1), 1, 1, 0, out W, out U, out VT);
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
            Console.WriteLine("Matrix U:");
            MatrixOutput(U);
            Console.Write("\n\n\n\n\n\n");
            Console.WriteLine("Matrix V^T:");
            MatrixOutput(VT);
            Console.Write("\n\n\n\n\n\n");
            Console.WriteLine("Matrix W:");
            for (int i = 0; i < W.Length; i++)
            {
                Console.Write("  {0}", W[i]);
            }
            Console.ReadKey();
        }
    }
}
