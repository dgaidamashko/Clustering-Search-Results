using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Graphs
{
    class Vertex
    {
        public float t, p; //временный и постоянный приоритетные коэффициенты
        public int cocheck;
        public double x, y;
        public bool isin, wasMin;
        public Vertex prev; // предыдущая вершина в минимальном остовном дереве/графе минимального пути
        protected int rad;
        protected static int ax = 0;
        protected static int ay = 0;
        public Vertex(double x, double y)
        {
            this.x = x;
            this.y = y;
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
            if (isin) br = new SolidBrush(Color.Red);
            else br = new SolidBrush(Color.Black);
            g.FillEllipse(br, (int)(x * Form1.GetScale) - rad + ax, (int)(y * Form1.GetScale) - rad + ay, rad * 2, rad * 2);
        }

        public bool Clicked(float x0, float y0)
        {
            if (Math.Pow(x0 - ((x * Form1.GetScale) + ax), 2) + Math.Pow(y0 - ((y * Form1.GetScale) +  ay), 2) <= Math.Pow(rad, 2))
            {
                return true;
            }
            else return false;
        }


        public int GetCoordX
        {
            get { return (int)(x * Form1.GetScale) - rad + ax; }
        }

        public int GetCoordY
        {
            get { return (int)(y * Form1.GetScale) - rad + ay; }
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