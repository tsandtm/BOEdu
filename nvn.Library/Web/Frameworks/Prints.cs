using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web;


namespace nvn.Library.Frameworks
{
    public static class Prints
    {
        public static void PrintWebControl(Control ControlToPrint, Control MyStyle)
        {
            StringWriter stringWrite = new StringWriter();
            System.Web.UI.HtmlTextWriter htmlWrite = new System.Web.UI.HtmlTextWriter(stringWrite);
            if (ControlToPrint is WebControl)
            {
                Unit w = new Unit(100, UnitType.Percentage);
                ((WebControl)ControlToPrint).Width = w;
            }
            System.Web.UI.Page pg = new System.Web.UI.Page();
            pg.EnableEventValidation = false;
            HtmlForm frm = new HtmlForm();

            frm.Controls.Add(MyStyle);

            pg.Controls.Add(frm);
            frm.Attributes.Add("runat", "server");
            frm.Controls.Add(ControlToPrint);
            pg.DesignerInitialize();
            pg.RenderControl(htmlWrite);
            string strHTML = stringWrite.ToString();
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.Write(strHTML);
            HttpContext.Current.Response.Write("<script>window.print();</script>");
            HttpContext.Current.Response.End();
        }
    }
}
