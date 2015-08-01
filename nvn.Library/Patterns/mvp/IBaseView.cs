using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nvn.Library.Patterns.MVP
{
    public interface IBaseView
    {
        string ErrorMessage { set; }
        string WaningMessage { set; }
        string SuccessMessage { set; }
        event EventHandler<EventArgs> FristLoadEventHandler;
    }
}
