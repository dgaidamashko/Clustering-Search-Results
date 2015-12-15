using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Clustering_research_tool
{
    class LineCalculations
    {
        public static bool HighCheck(Vertex dot1, Vertex dot2, Vertex dot3)
        {


            if (dot1.GetCoordX != dot2.GetCoordX)
            {
                double k = (double)(dot2.GetCoordY - dot1.GetCoordY) / (double)(dot2.GetCoordX - dot1.GetCoordX);

                if (dot3.GetCoordY == (dot3.GetCoordX - dot1.GetCoordX) * k + dot1.GetCoordY) return true;
                if (dot3.GetCoordY > (dot3.GetCoordX - dot1.GetCoordX) * k + dot1.GetCoordY)
                {
                    return true;
                }
                else return false;


            }
            else
            {
                if (dot3.GetCoordX >= dot1.GetCoordX) return true;
                return false;

            }
        }

        public static bool CheckLine(Vertex dot1, Vertex dot2, Vertex dot3)
        {
            if (dot1.GetCoordX != dot2.GetCoordX)
            {
                double k = (double)(dot2.GetCoordY - dot1.GetCoordY) / (double)(dot2.GetCoordX - dot1.GetCoordX);

                if (dot3.GetCoordY == Math.Round((dot3.GetCoordX - dot1.GetCoordX) * k + dot1.GetCoordY)) return true;

                else return false;


            }
            else
            {

                if (dot3.GetCoordX == dot1.GetCoordX) return true;
                return false;

            }
        }

        public static void ConnectDots(Vertex dot1, Vertex dot2, Graphics g)
        {
            g.DrawLine(new Pen(new SolidBrush(Color.Black)), dot1.GetCoordX + dot1.GetRad, dot1.GetCoordY + dot1.GetRad, dot2.GetCoordX + dot2.GetRad, dot2.GetCoordY + dot2.GetRad);
        }
    }
    }
