using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ClusteringSearchResults
{
    public partial class Form2 : Form
    {
        Clusters C;
        int mousex, mousey;
        static int scale = 400;
        bool moving;
        PointF movestart;
        bool EnableClusterPainting;
        Form3 ParScroll;

        public Form2()
        {
            InitializeComponent();
            this.MouseWheel += new MouseEventHandler(Form2_MouseWheel);
            EnableClusterPainting = false;
            mousex = 0;
            mousey = 0;
            label2.BackColor = Color.Transparent;
            moving = false;
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            movestart = new PointF();
            TestData.SetData();
            ParScroll = new Form3();
        }

        private void CBaction()
        {
            double k = Convert.ToDouble(textBox1.Text);
            if (comboBox1.SelectedIndex == 0)
            {
                C.ClusterSelection(k, 2);
            }
            else
            {
                if (comboBox1.SelectedIndex == 1)
                {
                    C.ClusterSelection(k, 3);
                }
                else
                {
                    if (comboBox1.SelectedIndex == 2)
                    {
                        C.ClusterSelection(k, 1);
                    }
                    else
                    {
                        if (comboBox1.SelectedIndex == 3)
                        {
                            C.ClusterSelection(k, 4);
                        }
                        else
                        {
                            C.ClusterSelection(k, 5);
                            textBox2.Text = Convert.ToString(C.r);
                        }
                    }
                }
            }
        }

        private void UpdateParameter(object sender, ParameterEventArgs e)
        {
            textBox1.Text = Convert.ToString(e.GetPar);
            TestData.SetData();
            textBox3.Clear();
            C = new Clusters(TextOperations.GetMatrix, TextOperations.GetTextTitles, TextOperations.GetWords);
            EnableClusterPainting = true;
            CBaction();
            textBox3.Clear();
            for (int i = 0; i < C.GetClusters.Count; i++)
            {
                for (int j = 0; j < C.GetClusters[i].Data.Count; j++)
                {
                    textBox3.Text += C.GetClusters[i].Data[j].Data.GetTag += " ";
                }
                textBox3.Text += " | ";
            }
            Invalidate();
        }

        private void Visualization_Load(object sender, EventArgs e)
        {
            DoubleBuffered = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TestData.SetData();
            textBox3.Clear();
            C = new Clusters(TextOperations.GetMatrix, TextOperations.GetTextTitles, TextOperations.GetWords);
            CBaction();
            EnableClusterPainting = true;
            textBox3.Clear();
            for (int i = 0; i < C.GetClusters.Count; i++)
            {
                for (int j = 0; j < C.GetClusters[i].Data.Count; j++)
                {
                    textBox3.Text += C.GetClusters[i].Data[j].Data.GetTag += " ";
                }
                textBox3.Text += " | ";
            }
                Invalidate();
        }

        private void button1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void Form2_Paint(object sender, PaintEventArgs e)
        {
            if (EnableClusterPainting)
            {
                
                e.Graphics.Clear(this.BackColor);
                for (int i = 0; i < C.GetGraph.E.Count; i++)
                {
                    C.GetGraph.E[i].Draw(e.Graphics);
                }
                for (int i = 0; i < C.GetGraph.V.Count; i++)
                {
                    C.GetGraph.V[i].Draw(e.Graphics);
                }
                
            }
        }

        private void Form2_SizeChanged(object sender, EventArgs e)
        {
            EventArgs par = new EventArgs();
            //FormSizeChanged(this, par);
        }

        private void Form2_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void Form2_MouseMove(object sender, MouseEventArgs e)//временная версия
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
                    for (int i = 0; i < C.GetGraph.V.Count; i++)
                    {
                        if (C.GetGraph.V[i].Clicked(e.X, e.Y))
                        {
                            mousex = e.X;
                            mousey = e.Y;
                            label2.Visible = true;
                            vselected = true;
                            label2.Text += " ";
                            label2.Text += C.GetGraph.V[i].Data.GetTag;
                            //label2.Left = C.GetGraph.V[i].GetCoordX + 20;
                            //label2.Top = C.GetGraph.V[i].GetCoordY + 20;

                        }
                    }
                    if (!vselected) label2.Visible = false;
                }
            }
            
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            EnableClusterPainting = false;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
           
        }

        public static int GetScale
        {
            get { return scale; }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (EnableClusterPainting)
            {
                TestData.SetData();
                C = new Clusters(TextOperations.GetMatrix, TextOperations.GetTextTitles, TextOperations.GetWords);
                CBaction();
                textBox3.Clear();
                for (int i = 0; i < C.GetClusters.Count; i++)
                {
                    for (int j = 0; j < C.GetClusters[i].Data.Count; j++)
                    {
                        textBox3.Text += C.GetClusters[i].Data[j].Data.GetTag += " ";
                    }
                    textBox3.Text += " | ";
                }
                Invalidate();
            }
        }

        private void Form2_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta >= 120)
            {
                scale += 100;
            }
            else 
            {
                if (e.Delta <= -120&&scale>=100)
                {
                    scale -= 100;
                }
            }
            Invalidate();
        }

        private void comboBox1_MouseWheel(object sender, MouseEventArgs e)
        {
            
        }

        private void Form2_MouseEnter(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_MouseLeave(object sender, EventArgs e)
        {
            
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox3.Clear();
            TestData.SetData();
            TextOperations.InitParams(TestData.Texts[comboBox2.SelectedIndex]);
            
            TextOperations.TagNullifier();
            for (int i = 0; i < TextOperations.ts.Count; i++)
            {
                TextOperations.Tag.Add(TextOperations.Frequency(TextOperations.vClusterize(TextOperations.ts[i].ToString())));
            }
            TextOperations.FormMatrix();
            if (EnableClusterPainting)
            {
                C = new Clusters(TextOperations.GetMatrix, TextOperations.GetTextTitles, TextOperations.GetWords);
                CBaction();
                textBox3.Clear();
                for (int i = 0; i < C.GetClusters.Count; i++)
                {
                    for (int j = 0; j < C.GetClusters[i].Data.Count; j++)
                    {
                        textBox3.Text += C.GetClusters[i].Data[j].Data.GetTag += " ";
                    }
                    textBox3.Text += " | ";
                }
                Invalidate();
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (ParScroll.Shw)
            {
                ParScroll.PCevent += new ParameterChangedEvents(this.UpdateParameter);
                ParScroll.Activate();
                ParScroll.WindowState = FormWindowState.Normal;
            }
            else 
            {
                ParScroll = new Form3();
                ParScroll.K = Convert.ToDouble(textBox1.Text);
                ParScroll.PCevent += new ParameterChangedEvents(this.UpdateParameter);
                ParScroll.Show();
                ParScroll.Shw = true;
            }
        }

        private void Form2_Activated(object sender, EventArgs e)
        {
            ParScroll.TBactive = false;
        }

        private void comboBox1_DropDownClosed(object sender, EventArgs e)
        {
            label1.Focus();
        }

        private void comboBox2_DropDownClosed(object sender, EventArgs e)
        {
            label1.Focus();
        }
    }
}
