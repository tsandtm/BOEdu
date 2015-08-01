/*Using for drowdownlist*/
 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nvn.Library.Patterns
{
    public class ThreeTypeParameters<parX, parY, parZ>
    {
        private parX x;

        public parX X
        {
            get { return x; }
            set { x = value; }
        }
        private parY y;

        public parY Y
        {
            get { return y; }
            set { y = value; }
        }
        private parZ z;

        public parZ Z
        {
            get { return z; }
            set { z = value; }
        }

        public ThreeTypeParameters(){}

        public ThreeTypeParameters(parX x, parY y, parZ z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        
    }
}
