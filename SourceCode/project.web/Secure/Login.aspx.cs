using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using thanhdai18htquanlyphanquyen.Library.Framework;


namespace project.web.Secure
{
    public partial class Login : hutechNoneBasePage
    {
        //Constituent controls inside LoginControl

        private string rpxApiKey = string.Empty;
        private string rpxApplicationName = string.Empty;
        private string returnUrlCookieName = string.Empty;



        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.Load += new EventHandler(this.Page_Load);
            //this.AppendQueryStringToAction = false;

            returnUrlCookieName = "returnurl" + "Hutech-Insider-Beta";


            //if (WebConfigSettings.HideMenusOnLoginPage) { SuppressAllMenus(); }

        }


        private void Page_Load(object sender, EventArgs e)
        {
            if (SiteUtils.SslIsAvailable())
                SiteUtils.ForceSsl();
            SecurityHelper.DisableBrowserCache();

            if (Request.IsAuthenticated)
            {
                // user is logged in
                WebUtils.SetupRedirect(this, SiteRoot + "/Default.aspx");
                return;
            }
            PopulateLabels();
            SetupReturnUrlCookie();
        }

        private void SetupReturnUrlCookie()
        {
            if (Page.IsPostBack)
            {
                return;
            }

            string returnUrl = string.Empty;

            if (Page.Request.UrlReferrer != null)
            {
                string urlReferrer = Page.Request.UrlReferrer.ToString();
                if ((urlReferrer.StartsWith(SiteRoot)) || (urlReferrer.StartsWith(SiteRoot.Replace("https://", "http://"))))
                {
                    returnUrl = urlReferrer;
                }
            }

            string returnUrlParam = Page.Request.Params.Get("returnurl");
            if (!String.IsNullOrEmpty(returnUrlParam))
            {
                returnUrlParam = SecurityHelper.RemoveMarkup(returnUrlParam);
                string redirectUrl = Page.ResolveUrl(SecurityHelper.RemoveMarkup(Page.Server.UrlDecode(returnUrlParam)));
                //string redirectUrl = Page.ResolveUrl(SecurityHelper.RemoveMarkup(returnUrlParam));
                if ((redirectUrl.StartsWith(SiteRoot)) || (redirectUrl.StartsWith(SiteRoot.Replace("https://", "http://"))))
                {
                    returnUrl = redirectUrl;
                }
            }
            if (returnUrl.Length > 0)
            {
                CookieHelper.SetCookie(returnUrlCookieName, returnUrl);
            }
        }


        private void PopulateLabels()
        {

        }
    }
}