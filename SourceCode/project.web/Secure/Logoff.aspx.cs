using System;
using System.Globalization;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using thanhdai18htquanlyphanquyen.Library.Framework;




namespace project.web.Secure
{
    public partial class Logoff : System.Web.UI.Page
    {
        const string WindowsLiveSecurityAlgorithm = "wsignin1.0";
        //private bool forceDelAuthNonProvisioned = true;

        protected void Page_Load(object sender, EventArgs e)
        {
            DoLogout();
        }

        private void DoLogout()
        {
            string winliveCookieName = "winliveid" + "WL2011-VinliveCookieName";
            //+ siteSettings.SiteId.ToString(CultureInfo.InvariantCulture);

            string roleCookieName = SiteUtils.GetRoleCookieName();

            HttpCookie roleCookie = new HttpCookie(roleCookieName, string.Empty);
            roleCookie.Expires = DateTime.Now.AddMinutes(1);
            roleCookie.Path = "/";
            Response.Cookies.Add(roleCookie);

            HttpCookie displayNameCookie = new HttpCookie("DisplayName", string.Empty);
            displayNameCookie.Expires = DateTime.Now.AddMinutes(1);
            displayNameCookie.Path = "/";
            Response.Cookies.Add(displayNameCookie);


            FormsAuthentication.SignOut();
            string winLiveToken = CookieHelper.GetCookieValue(winliveCookieName);

            try
            {
                if (Session != null)
                {
                    Session.Abandon();
                }
            }
            catch (HttpException)
            {
            }
            HttpContext.Current.Session["permissionvalue"] = null;
            if (Session["ActivePage"] != null)
                SiteUtils.RedirectToLoginPage(this,Session["ActivePage"].ToString());
				////////////
            else
                WebUtils.SetupRedirect(this, SiteUtils.GetNavigationSiteRoot() + "/Secure/Login.aspx");
				////////////
        }
    }
}
