////////////////////////////////////////////////////////////////////////////////////////////
//             				 Button Control For ASP.NET 2.0			                      //
//								Created By tsandtm									  //
//									28.8.2012									  	  //
//								tsandtm@gmail.com							          //
////////////////////////////////////////////////////////////////////////////////////////////
// added ability to set CssClasses default is tsButton


#region // using Directives
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
#endregion

namespace nvn.Library.Web.Controls
{
    [DefaultProperty("Text")]
    [ToolboxData("<{0}:tsButon runat=server></{0}:tsButon>")]
    public class tsButton : Button
    {
        [Bindable(true)]
        [Category("Appearance")]
        [DefaultValue("")]
        [Localizable(true)]
        public string Text
        {
            get
            {
                String s = (String)ViewState["Text"];
                return ((s == null) ? String.Empty : s);
            }

            set
            {
                ViewState["Text"] = value;
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (CssClass == "")
                CssClass = "tsButton";
        }
    }
}
