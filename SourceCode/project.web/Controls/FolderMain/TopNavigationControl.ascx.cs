using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace project.web.Controls.FolderMain
{
    public partial class TopNavigationControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Request.IsAuthenticated)
            {
                this.lnkLogoff.Visible = false;
                lnkAddError.Visible = false;
                this.lnkLogin.Visible = true;

            }
            else
            {

            }

            if (!IsPostBack)
            {
                PopularLabels();
            }

        }
        private void PopularLabels()
        {
            this.lnkLogin.NavigateUrl = SiteUtils.GetNavigationSiteRoot() + "/Secure/Login.aspx";
            this.lnkLogoff.NavigateUrl = SiteUtils.GetNavigationSiteRoot() + "/Secure/Logoff.aspx";
            lnkAddError.NavigateUrl = SiteUtils.GetNavigationSiteRoot() + "/Page/FolderError/PageAddLogError.aspx";

        }
    }
}