/*Using for drowdownlist*/
 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nvn.Library.Patterns
{
    public class TowTypeParameters<parT,parV>
    {
        private parT t;
        private parV v;

        public TowTypeParameters(){}

        public TowTypeParameters(parT t,parV v)
        {
            this.t = t;
            this.v = v;
        }

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
    }
}
