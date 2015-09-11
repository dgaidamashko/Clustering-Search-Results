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
    public partial class Form3 : Form
    {
        bool isopened;
        bool tbactive;
        public event ParameterChangedEvents PCevent;

        public Form3()
        {
            InitializeComponent();
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

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            isopened = false;
        }

        private void Form3_Activated(object sender, EventArgs e)
        {
            tbactive = true;
        }
    }
}
