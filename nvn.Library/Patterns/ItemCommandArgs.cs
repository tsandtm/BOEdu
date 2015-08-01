using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nvn.Library.Patterns
{
    public class ItemCommandArgs<T> : EventArgs
    {
        public string parameterName { get; set; }
        public string parameterValue { get; set; }
        public int? itemIndex { get; set; }
        public T myType { get; set; }

        public ItemCommandArgs() { }
        public ItemCommandArgs(string parameterName, string parameterValues)
        {
            this.parameterName = parameterName;
            this.parameterValue = parameterValue;
        }
        public ItemCommandArgs(string parameterName, string parameterValues,int itemIndex)
        {
            this.parameterName = parameterName;
            this.parameterValue = parameterValues;
            this.itemIndex = itemIndex;
        }

        public ItemCommandArgs(string parameterName, string parameterValues, int itemIndex,T myType)
        {
            this.parameterName = parameterName;
            this.parameterValue = parameterValues;
            this.itemIndex = itemIndex;
            this.myType = myType;
        }
    }
}
