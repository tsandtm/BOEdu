using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using thanhdai18htquanlyphanquyen.Library.WebHelpers;
using thanhdai18htquanlyphanquyen.Library.Models;

namespace project.web.Controls
{
    public partial class LoggedUserInfo : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Request.IsAuthenticated)
            {
                this.lblUser.Text = "<strong>Khách</strong>";
                this.lnkLogoff.Visible = false;
                this.lnkLogin.Visible = true;
                this.lnkAccount.Visible = false;
                //this.HyperLinkManager.Visible = false;
                //this.HyperLinkUpdateUser.Visible = false;
                //this.liProfile.Visible = false;
                //this.liProfileSeparator.Visible = false;
            }
            else
            {
                PhanQuen();
            }

            if (!IsPostBack)
            {
                PopularLabels();
            }
        }

        protected void PhanQuen()
        {
            if (WebUser.IsAdmin)
            {
                //this.HyperLinkManager.Visible = true;
                return;
            }
            //this.HyperLinkManager.Visible = true;//WebUser.isManage(WebUser.GetCurrentUserId());
        }
        private void PopularLabels()
        {
            this.lnkLogin.NavigateUrl = SiteUtils.GetNavigationSiteRoot() + "/Secure/Login.aspx";
            this.lnkLogoff.NavigateUrl = SiteUtils.GetNavigationSiteRoot() + "/Secure/Logoff.aspx";
            this.lnkAccount.NavigateUrl = SiteUtils.GetNavigationSiteRoot() + "/Secure/ChangePassword.aspx";
            //this.HyperLinkManager.NavigateUrl = SiteUtils.GetNavigationSiteRoot() + "/Admin/AdminMenu.aspx";
            //this.HyperLinkUpdateUser.NavigateUrl = SiteUtils.GetNavigationSiteRoot() + "/Secure/UpdateUser.aspx";

            if (this.lblUser != null)
            {
                SiteUser loggedUser = SiteUtils.GetCurrentUser();
                if (loggedUser != null && loggedUser.UserId != Guid.Empty)
                {
                    this.lblUser.Text = String.Format("<strong>{0}</strong> [{1}]", loggedUser.Name, loggedUser.LoginName);
                    this.lnkLogin.Visible = false;
                    this.lnkLogoff.Text = "Đăng xuất";
                }
                else
                {
                    this.lblUser.Text = "<strong>Khách</strong>";
                }

                loggedUser = null;
            }
        }
    }
}
