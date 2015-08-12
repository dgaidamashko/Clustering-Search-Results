using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Graphs
{
    class Edge
    {
        public Vertex V1, V2;
        public bool optimal;
        public double Weight;
        public Edge(Vertex V1, Vertex V2)
        {
            this.V1 = V1;
            this.V2 = V2;
            Weight = Math.Sqrt(Math.Pow((V1.x - V2.x), 2) + Math.Pow((V1.y - V2.y), 2));
        }

        public void Draw(Graphics g)
        {
            Pen p;
            if (optimal) p = new Pen(Color.Red, 2);
            else p = new Pen(Color.Black, 2);
            g.DrawLine(p, (int)(V1.x * Form1.GetScale) + Vertex.AX, (int)(V1.y * Form1.GetScale) + Vertex.AY, (int)(V2.x * Form1.GetScale) + Vertex.AX, (int)(V2.y * Form1.GetScale) + Vertex.AY);
        }
    }
}
