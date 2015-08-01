using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nvn.Library.Patterns
{
    public class SaveEventAgrs<T> : EventArgs
    {
        public T myType { get; set; }

        public SaveEventAgrs() { }
        public SaveEventAgrs(T myType)
        {
            this.myType = myType;
        }
    }
}
