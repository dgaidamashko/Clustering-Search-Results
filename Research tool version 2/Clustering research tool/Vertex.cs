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
        protected int rad;
        protected static int ax = 0;
        protected static int ay = 0;
        public Vertex(Tags Data, double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            isin = false;
            wasMin = false;
            this.Data = Data; 
            rad = 7;
        }
        public void Draw(Graphics g)
        {
            Brush br;
            if (Data is Word) br = new SolidBrush(Color.Red);
            else br = new SolidBrush(Color.Blue);
            g.FillEllipse(br, (int)(x * Form2.GetScale) - rad + Form1.GetForm2Width / 2 + ax, (int)(y * Form2.GetScale) - rad + Form1.GetForm2Height / 2 + ay, rad * 2, rad * 2);
            g.DrawEllipse(new Pen(new SolidBrush(Color.Black)), (int)(x * Form2.GetScale) - rad + Form1.GetForm2Width / 2 + ax, (int)(y * Form2.GetScale) - rad + Form1.GetForm2Height / 2 + ay, rad * 2, rad * 2);
            g.DrawEllipse(new Pen(new SolidBrush(Color.Black)), (int)(x * Form2.GetScale) - (int)(Form2.GetK * Form2.GetScale) + Form1.GetForm2Width / 2 + ax, (int)(y * Form2.GetScale) - (int)(Form2.GetK * Form2.GetScale) + Form1.GetForm2Height / 2 + ay, (int)(Form2.GetK * Form2.GetScale) * 2, (int)(Form2.GetK * Form2.GetScale) * 2);
        }

        public bool Clicked(float x0, float y0)
        {
            if (Math.Pow(x0 - ((x * Form2.GetScale) + Form1.GetForm2Width / 2 + ax), 2) + Math.Pow(y0 - ((y * Form2.GetScale) + Form1.GetForm2Height / 2 + ay), 2) <= Math.Pow(rad, 2))
            {
                return true;
            }
            else return false;
        }

        public static double EuclideDistance(Vertex a, Vertex b)
        {
            return Math.Sqrt(Math.Pow(a.x, 2) + Math.Pow(a.y, 2) + Math.Pow(a.z, 2));
        }

        public int GetCoordX
        {
            get { return (int)(x * Form2.GetScale) - rad + Form1.GetForm2Width / 2 + ax; }
        }

        public int GetCoordY
        {
            get { return (int)(y * Form2.GetScale) - rad + Form1.GetForm2Height / 2 + ay; }
        }

        public int GetRad
        {
            get { return rad; }
        }

        public static int AX
        {
            get { return ax; }
            set { ax = value; }
        }

        public static int AY
        {
            get { return ay; }
            set { ay = value; }
        }
    }
}
