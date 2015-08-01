using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using thanhdai18htquanlyphanquyen.Library.Models;


namespace project.web.Controls.FolderMain
{
    public partial class UserInfoControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Request.IsAuthenticated)
            {
                this.lblFullName.Text = "<strong>Khách</strong>";
                this.lnkLogoff.Visible = false;
                this.lnkLogin.Visible = true;
                this.lnkAccount.Visible = false;

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
            this.lnkAccount.NavigateUrl = SiteUtils.GetNavigationSiteRoot() + "/Secure/ChangePassword.aspx";
            //this.HyperLinkManager.NavigateUrl = SiteUtils.GetNavigationSiteRoot() + "/Admin/AdminMenu.aspx";
            //this.HyperLinkUpdateUser.NavigateUrl = SiteUtils.GetNavigationSiteRoot() + "/Secure/UpdateUser.aspx";

            if (this.lblUserName != null)
            {
                SiteUser loggedUser = SiteUtils.GetCurrentUser();
                if (loggedUser != null && loggedUser.UserId != Guid.Empty)
                {
                    this.lblFullName.Text = "<strong>" + loggedUser.Name + "</strong>";
                    this.lnkLogin.Visible = false;
                    this.lblUserName.Text = "[" + loggedUser.LoginName + "]";
                }
                else
                {
                    this.lblFullName.Text = "<strong>Khách</strong>";
                    this.lblUserName.Text = "";
                }

                loggedUser = null;
            }
        }
    }
}