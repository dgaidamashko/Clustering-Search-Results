using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace ClusteringSearchResults
{

    public class Vertex
    {
        public float t, p; //временный и постоянный приоритетные коэффициенты
        public int cocheck;
        public double x, y, z;
        public bool isin, wasMin;
        public Vertex prev; // предыдущая вершина в минимальном остовном дереве/графе минимального пути
        public Tags Data;
        protected int rad;
        protected static int ax = 0;
        protected static int ay = 0;
        public Vertex(Tags Data, double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.Data = Data;
            t = float.MaxValue; 
            p = float.MaxValue; 
            prev = null;
            isin = false;
            wasMin = false;
            rad = 7;
        }
        public void Draw(Graphics g)
        {
            Brush br;
            if (Data is Word) br = new SolidBrush(Color.Red);
            else br = new SolidBrush(Color.Blue);
            g.FillEllipse(br, (int)(x * Form2.GetScale) - rad + Form1.GetForm2Width / 2 + ax, (int)(y * Form2.GetScale) - rad + Form1.GetForm2Height / 2 + ay, rad * 2, rad * 2);
        }

        public bool Clicked(float x0, float y0)
        {
            if (Math.Pow(x0 - ((x * Form2.GetScale) + Form1.GetForm2Width / 2 + ax), 2) + Math.Pow(y0 - ((y * Form2.GetScale) + Form1.GetForm2Height / 2 + ay), 2) <= Math.Pow(rad, 2))
            {
                return true;
            }
            else return false;
        }


        public int GetCoordX
        {
            get { return (int)(x * Form2.GetScale) - rad + Form1.GetForm2Width / 2 + ax; }
        }

        public int GetCoordY
        {
            get { return (int)(y * Form2.GetScale) - rad + Form1.GetForm2Height / 2 + ay; }
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