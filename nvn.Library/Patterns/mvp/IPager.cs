using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using nvn.Library.Patterns;

namespace nvn.Library.Patterns.MVP
{
    public interface IPager : IBaseView
    {
        int PageNumber { get; set; }
        int PageSize { get; set; }
        int TotalPages { set; }
        //int PagesValueSelected { get; set; }
        List<TowTypeParameters<string, string>> PapeNumbers { set; }

        event EventHandler<OneParameterEventAgrs<int>> SelectedIndexChanged_EventArgs;
    }
}
