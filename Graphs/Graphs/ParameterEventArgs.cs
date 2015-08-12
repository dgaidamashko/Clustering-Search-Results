using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Graphs
{
    public class ParameterEventArgs : EventArgs
    {
        double k;

        public ParameterEventArgs(double k)
        {
            this.k = k;
        }

        public double GetPar
        {
            get { return k; }
        }
    }
}
