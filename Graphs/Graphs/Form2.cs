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
    public partial class Form2 : Form
    {
        bool isopened;
        bool tbactive;
        public event ParameterChangedEvents PCevent;

        public Form2()
        {
            InitializeComponent();
            trackBar1.Value = Convert.ToInt32(Form1.K * 10);
        }

        public bool Shw
        {
            get
            {
                return isopened;
            }
            set
            {
                isopened = value;
            }
        }

        public bool TBactive
        {
            get { return tbactive; }
            set { tbactive = value; }
        }

        public double K
        {
            set { trackBar1.Value = Convert.ToInt32(value * 10); }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            ParameterEventArgs p = new ParameterEventArgs(Convert.ToDouble(trackBar1.Value) / 10);
            PCevent(this, p);
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            isopened = false;
        }
    }
}
