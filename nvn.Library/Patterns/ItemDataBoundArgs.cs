using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nvn.Library.Patterns
{
    public class ItemDataBoundArgs : EventArgs
    {
        public string parameterName { get; set; }

        public ItemDataBoundArgs() { }
        public ItemDataBoundArgs(string parameterName)
        {
            this.parameterName = parameterName;
        }
    }
}
