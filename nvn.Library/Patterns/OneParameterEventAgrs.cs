using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nvn.Library.Patterns
{
    public class OneParameterEventAgrs<T> : EventArgs
    {
        public T myType { get; set; }

        public OneParameterEventAgrs() { }
        public OneParameterEventAgrs(T myType)
        {
            this.myType = myType;
        }
    }
}
