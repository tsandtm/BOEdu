using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;
using System.Globalization;

namespace project.web
{
    public class BasePage : System.Web.UI.Page
    {
        protected override void InitializeCulture()
        {
            if (!string.IsNullOrEmpty(Request["lang"]))
            {
                Session["lang"] = Request["lang"];
            }
            string lang = Convert.ToString(Session["lang"]);
            string culture = string.Empty;
            if (lang.ToLower().CompareTo("vi") == 0 || string.IsNullOrEmpty(culture))
            {
                culture = "vi-VN";
            }
            if (lang.ToLower().CompareTo("ja") == 0)
            {
                culture = "ja-JP";
            }
            if (lang.ToLower().CompareTo("en") == 0)
            {
                culture = "en-US";
            }
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(culture);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);

            base.InitializeCulture();
        }

        //protected override void OnLoadComplete(EventArgs e)
        //{
        //    // Set the page's title, if necessary
        //    if (string.IsNullOrEmpty(Page.Title) || Page.Title == "Untitled Page")
        //    {
        //        // Determine the filename for this page
        //        string fileName = System.IO.Path.GetFileNameWithoutExtension(Request.PhysicalPath);
                
        //        this.Page.Title = fileName;
        //    }

        //    base.OnLoadComplete(e);
        //}
    }

}