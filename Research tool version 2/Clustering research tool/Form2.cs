using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clustering_research_tool
{
    public partial class Form2 : Form
    {
        Clusters C;
        static int scale = 400;
        bool moving;
        PointF movestart;
        bool EnableClusterPainting;
        //????
        string kstring;
        //
        double k;

        public Form2()
        {
            InitializeComponent();
            this.MouseWheel += new MouseEventHandler(Form2_MouseWheel);
            EnableClusterPainting = false;
            k = 1;
            moving = false;
            movestart = new PointF();
            kstring = Convert.ToString(k);
            label3.BackColor = Color.Transparent;
            if (Form1.listChanged || Form1.firstTxtEnter)
            {
                comboBox2.Items.Add(Convert.ToString(comboBox2.Items.Count + 1));
            }
            comboBox1.SelectedIndex = comboBox1.Items.Count - 1;
            comboBox2.SelectedIndex = comboBox2.Items.Count - 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CBaction(true);
        }

        private void Form2_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta >= 120)
            {
                scale += 100;
            }
            else
            {
                if (e.Delta <= -120 && scale >= 100)
                {
                    scale -= 100;
                }
            }
            Invalidate();
        }

        public static int GetScale
        {
            get { return scale; }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (EnableClusterPainting)
            {
                CBaction(false);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            bool error = false;
            try
            {
                if (textBox1.Text != "")
                {
                    button1.Enabled = true;
                    k = Convert.ToDouble(textBox1.Text);
                }
                else
                {
                    button1.Enabled = false;
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

        private void Form2_Paint(object sender, PaintEventArgs e)
        {
            if (EnableClusterPainting)
            {
                e.Graphics.Clear(this.BackColor);
                for (int i = 0; i < C.GetV.Count; i++)
                {
                    C.GetV[i].Draw(e.Graphics);
                }
                for (int i = 0; i < C.GetClusterList.Count; i++)
                {
                    C.GetClusterList[i].ConvexHull(e.Graphics);
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            DoubleBuffered = true;
        }

        private void Form2_MouseMove(object sender, MouseEventArgs e)
        {
            if (moving)
            {
                Vertex.AX += e.X - (int)movestart.X;
                Vertex.AY += e.Y - (int)movestart.Y;
                movestart.X = e.X;
                movestart.Y = e.Y;
                Invalidate();
            }
            else
            {
                if (EnableClusterPainting)
                {

                    bool vselected = false;
                    label2.Text = "";
                    for (int i = 0; i < C.GetV.Count; i++)
                    {
                        if (C.GetV[i].Clicked(e.X, e.Y))
                        {
                            label3.Visible = true;
                            vselected = true;
                            label3.Text += " ";
                            label3.Text += C.GetV[i].Data.GetTag;
                            label3.Left = C.GetV[i].GetCoordX + 20;
                            label3.Top = C.GetV[i].GetCoordY + 20;

                        }
                    }
                    if (!vselected) label3.Visible = false;
                }
            }
        }

        private void Form2_MouseDown(object sender, MouseEventArgs e)
        {
            if (EnableClusterPainting)
            {
                moving = true;
                movestart.X = e.X;
                movestart.Y = e.Y;
            }
        }

        private void Form2_MouseUp(object sender, MouseEventArgs e)
        {
            moving = false;
        }

        private void CBaction(bool needReform)
        {
            if (needReform)
            {
                TextOperations.InitParams(Form1.TestData[comboBox2.SelectedIndex]);
                TextOperations.TagNullifier();
                for (int i = 0; i < TextOperations.ts.Count; i++)
                {
                    TextOperations.Tag.Add(TextOperations.Frequency(TextOperations.vClusterize(TextOperations.ts[i].ToString())));
                }
                TextOperations.FormMatrix();
            }
            if (EnableClusterPainting)
            {
                C = new Clusters(TextOperations.GetMatrix, TextOperations.GetTextTitles, TextOperations.GetWords);
                C.r = k;
                MethodDecision();
                Invalidate();
            }
        }

        private void MethodDecision()
        {
            switch(comboBox1.SelectedIndex)
            {
                case 0: C.dbscan(0.1, 2); break;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(EnableClusterPainting)
            { CBaction(true); }
            
        }
    }
}
