using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Graphs
{
    public partial class Form1 : Form
    {
        Graph G;
        float max = float.MaxValue;
        Vertex temp1, temp2, temp;
        static int scale = 1;
        int end;
        bool clicked;
        bool moving;
        PointF movestart;
        static int formwidth, formheight;
        static double k = 2;
        string kstring = "";
        Form2 ParScroll;
        public static string el;
        public static string al;

        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;
            this.MouseWheel += new MouseEventHandler(Form1_MouseWheel);
            G = new Graph();
            end = 0;
            Invalidate();
            clicked = false;
            formwidth = this.Size.Width;
            formheight = this.Size.Height;
            movestart = new PointF();
            moving = false;
            textBox1.Text = "2";
            ParScroll = new Form2();
        }

        private void UpdateParameter(object sender, ParameterEventArgs e)
        {
            k = e.GetPar;
            textBox1.Text = Convert.ToString(k);
            for (int i = 0; i < G.E.Count; i++)
            {
                G.E[i].optimal = false;
            }
            for (int i = 0; i < G.V.Count; i++)
            {
                //if (G.V[i].isin) { ends.Add(G.V[i]); }
                G.V[i].wasMin = false;
                G.V[i].t = max;
                G.V[i].p = max;
            }
            ClOperations.ClusterSelection(k, G, 2);
            Invalidate();
        }

        public static double K
        {
            get { return k; }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void pictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            
        }

        private void Form1_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta >= 120)
            {
                //scale += 100;
            }
            else
            {
                if (e.Delta <= -120 && scale >= 100)
                {
                    //scale -= 100;
                }
            }
            Invalidate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Vertex> ends = new List<Vertex>();
            if (end != 2)
            {
                MessageBox.Show("Укажите начало и конец пути!");
            }
            else
            {
                for (int i = 0; i < G.E.Count; i++)
                {
                    G.E[i].optimal = false;
                }
                for (int i = 0; i < G.V.Count; i++)
                {
                    if (G.V[i].isin) { ends.Add(G.V[i]); }
                    G.V[i].wasMin = false;
                    G.V[i].t = max;
                    G.V[i].p = max;
                }
               
                if (Graph.IsConVerx(G.IsConList(ends[0]), ends[1]))
                {
                    G.FindingMinWay(ends[0], ends[1]);
                    Invalidate();
                }
                else MessageBox.Show("Нет пути!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            G = new Graph();
            end = 0;
            Invalidate();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            List<Vertex> ends = new List<Vertex>();
            if (end < 1)
            {
                MessageBox.Show("Укажите корень остовного дерева!");
            }
            else if (end > 1)
            {
                MessageBox.Show("Укажите только корень остовного дерева!");
            }
            else
            {
                for (int i = 0; i < G.E.Count; i++)
                {
                    G.E[i].optimal = false;
                }
                for (int i = 0; i < G.V.Count; i++)
                {
                    if (G.V[i].isin) { ends.Add(G.V[i]); }
                    G.V[i].wasMin = false;
                    G.V[i].t = max;
                    G.V[i].p = max;
                }
                if (G.IsCon())
                {
                    G.FindMinSpanTree(ends[0]);
                    Invalidate();
                }
                else MessageBox.Show("Нет пути!");
            }
        }

        public static int GetScale
        {
            get { return scale; }
        }

        public static int GetFormWidth
        {
            get { return formwidth; }
            set { formwidth = value; }
        }

        public static int GetFormHeight
        {
            get { return formheight; }
            set { formheight = value; }
        }

        private void Form1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                bool chosen = false;
                for (int i = 0; i < G.V.Count; i++)
                {
                    if (G.V[i].Clicked(e.X, e.Y))
                    {
                        chosen = true;
                        if (G.V[i].isin) { G.V[i].isin = false; end--; }
                        else
                        {
                            if (end < 2)
                            {
                                G.V[i].isin = true; end++;
                            }
                        }
                    }
                }
                if (!chosen) G.V.Add(new Vertex(e.X - Vertex.AX, e.Y - Vertex.AY));
            }
            else if (e.Button == MouseButtons.Right)
            {
                for (int i = 0; i < G.V.Count; i++)
                {
                    if (G.V[i].Clicked(e.X, e.Y))
                    {
                        temp = G.V[i];
                        for (int j = 0; j < G.E.Count; j++)
                        {
                            if (G.E[j].V1 == temp || G.E[j].V2 == temp)
                            {
                                G.E.Remove(G.E[j]);
                                j = -1;
                            }
                        }
                        if (temp.isin) end--;
                        G.V.Remove(temp);
                    }
                }
            }
            this.Invalidate();
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (clicked)
            {
                for (int i = 0; i < G.V.Count; i++)
                {
                    if (G.V[i].Clicked(e.X, e.Y))
                    {
                        temp2 = G.V[i];
                        break;
                    }
                }
                if (temp1 != temp2 && (temp1 != null && temp2 != null))
                {
                    if (new Edge(temp1, temp2).Weight <= max)
                    {
                        G.E.Add(new Edge(temp1, temp2));
                    }
                }
            }
            clicked = false;
            moving = false;
            Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < G.V.Count; i++)
            {
                G.V[i].Draw(e.Graphics);
            }
            for (int i = 0; i < G.E.Count; i++)
            {
                G.E[i].Draw(e.Graphics);
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < G.V.Count; i++)
            {
                if (G.V[i].Clicked(e.X, e.Y))
                {
                    temp1 = G.V[i];
                    clicked = true;
                    moving = false;
                    break;
                }
            }
            if (!clicked) 
            {
                moving = true;
                movestart.X = e.X;
                movestart.Y = e.Y;
            }
            for (int i = 0; i < G.E.Count; i++)
            {
                G.E[i].optimal = false;
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (moving)
            {
                Vertex.AX += e.X - (int)movestart.X;
                Vertex.AY += e.Y - (int)movestart.Y;
                movestart.X = e.X;
                movestart.Y = e.Y;
                Invalidate();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < G.E.Count; i++)
            {
                G.E[i].optimal = false;
            }
            for (int i = 0; i < G.V.Count; i++)
            {
                //if (G.V[i].isin) { ends.Add(G.V[i]); }
                G.V[i].wasMin = false;
                G.V[i].t = max;
                G.V[i].p = max;
            }
            ClOperations.ClusterSelection(k, G, 2);
            textBox2.Text = Convert.ToString(ClOperations.r);
            textBox3.Text = el;
            textBox4.Text = al;
            Invalidate();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            bool error = false;
            try
            {
                if (textBox1.Text != "")
                {
                    k = Convert.ToDouble(textBox1.Text);
                }
            }
            catch (System.Exception)
            {
                error = true;
                MessageBox.Show("Невертый формат текста");
                textBox1.Text = kstring;
            }
            if (!error)
            {
                kstring = textBox1.Text;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (ParScroll.Shw)
            {
                ParScroll.PCevent += new ParameterChangedEvents(this.UpdateParameter);
                ParScroll.Activate();
                ParScroll.WindowState = FormWindowState.Normal;
            }
            else
            {
                ParScroll = new Form2();
                ParScroll.K = Convert.ToDouble(textBox1.Text);
                ParScroll.PCevent += new ParameterChangedEvents(this.UpdateParameter);
                ParScroll.Show();
                ParScroll.Shw = true;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
