using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nvn.Library.Patterns
{
    public class TowParameterEventAgrs<parT, parV> : EventArgs
    {
        private parT t;
        private parV v;

        public parT T
        {
            get { return t; }
            set { t = value; }
        }
        public parV V
        {
            get { return v; }
            set { v = value; }
        }

        public TowParameterEventAgrs() { }
        public TowParameterEventAgrs(parT T,parV V)
        {
            this.t = T;
            this.v = V;
        }
    }
}
