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
    public partial class Form1 : Form
    {
        Form2 F;
        List<string> input;
        public static List<string[]> TestData = new List<string[]>();
        static int formwidth, formheight;
        public static bool firstTxtEnter;
        public static bool txtEntered;
        public static bool listChanged;

        public Form1()
        {
            InitializeComponent();
            input = new List<string>();
            F = new Form2();
            formwidth = F.Size.Width;
            formheight = F.Size.Height;
            button3.Enabled = false;
            firstTxtEnter = true;
            txtEntered = false;
            listChanged = false;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text != "")
            {
                input.Add(richTextBox1.Text);
                TextOperations.InitParams(input);
                listBox1.Items.Add(TextOperations.ts[TextOperations.ts.Count - 1]);
                richTextBox1.Text = "";
                txtEntered = true;
                if (input.Count >= 3 || TestData.Count > 0) button3.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            input = new List<string>();
            listBox1.Items.Clear();
            txtEntered = false;
            listChanged = true;
            if (firstTxtEnter && TestData.Count < 1) button3.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            F = new Form2();
            //Список конвертируется в массив
            if (txtEntered)
            {
                string[] temp = new string[input.Count];
                for (int i = 0; i < temp.Length; i++)
                {
                    temp[i] = input[i];
                }
                if (listChanged || firstTxtEnter)
                {
                    TestData.Add(temp);
                }
                else
                {
                    TestData[TestData.Count - 1] = temp;
                }
            }
            //Задаются необходимые для обработки текстов параметры и формируется частотная матрица
            TextOperations.TagNullifier();
            for (int i = 0; i < TextOperations.ts.Count; i++)
            {
                TextOperations.Tag.Add(TextOperations.Frequency(TextOperations.vClusterize(TextOperations.ts[i].ToString())));
            }
            TextOperations.FormMatrix();
            F.ShowDialog();
            firstTxtEnter = false;
            if (txtEntered)
            {
                listChanged = false;
            }
        }

        public static int GetForm2Width
        {
            get { return formwidth; }
            set { formwidth = value; }
        }
        public static int GetForm2Height
        {
            get { return formheight; }
            set { formheight = value; }
        }
    }
}
