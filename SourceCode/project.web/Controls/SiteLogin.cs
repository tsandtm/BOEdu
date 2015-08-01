using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using log4net;

using thanhdai18htquanlyphanquyen.Library.Models;
using thanhdai18htquanlyphanquyen.Library.Framework;
using thanhdai18htquanlyphanquyen.Library.WebHelpers.UserSignInHandlers;



namespace project.web.UI
{
    public class SiteLogin : Login
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(SiteLogin));
        //private readonly SiteSettings siteSettings = CacheHelper.GetCurrentSiteSettings();
        private readonly string siteRoot = SiteUtils.GetNavigationSiteRoot();
        //private HiddenField hdnReturnUrl = null;

        private bool setRedirectUrl = true;

        public bool SetRedirectUrl
        {
            get
            {
                return setRedirectUrl;
            }
            set
            {
                setRedirectUrl = value;
            }
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            this.Load += new EventHandler(SiteLogin_Load);
            this.LoginError += new EventHandler(SiteLogin_LoginError);
            this.LoggingIn += new LoginCancelEventHandler(SiteLogin_LoggingIn);
            this.LoggedIn += new EventHandler(SiteLogin_LoggedIn);

            this.CreateUserText = "Đăng ký";
            this.CreateUserUrl = "#";
            this.FailureText = "Đăng nhập thất bại";
            this.LoginButtonText = "Đăng nhập";
            this.PasswordRecoveryText = "Lấy lại mật mã";
            this.PasswordRecoveryUrl = "#";
            this.RememberMeText = "Nhớ mật mã";

#if !NET35
            this.RenderOuterTable = false;
            this.CssClass = string.Empty;
#endif
            //HookupSignInEventHandlers();

            //hdnReturnUrl = new HiddenField();
            //hdnReturnUrl.ID = "hdnReturnUrl";
            //this.Controls.Add(hdnReturnUrl);

        }


        void SiteLogin_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ViewState["LoginErrorCount"] = 0;

                if (Page.Request.UrlReferrer != null)
                {
                    string urlReferrer = Page.Request.UrlReferrer.ToString();
                    if ((urlReferrer.StartsWith(siteRoot)) || (urlReferrer.StartsWith(siteRoot.Replace("https://", "http://"))))
                    {
                        ViewState["ReturnUrl"] = urlReferrer;
                        //log.Info(hdnReturnUrl.Value);
                    }
                }

                string returnUrlParam = Page.Request.Params.Get("returnurl");
                if (!String.IsNullOrEmpty(returnUrlParam))
                {
                    returnUrlParam = SecurityHelper.RemoveMarkup(returnUrlParam);
                    string redirectUrl = Page.ResolveUrl(SecurityHelper.RemoveMarkup(Page.Server.UrlDecode(returnUrlParam)));
                    if ((redirectUrl.StartsWith(siteRoot)) || (redirectUrl.StartsWith(siteRoot.Replace("https://", "http://"))))
                    {
                        ViewState["ReturnUrl"] = redirectUrl;
                    }
                    if ((!redirectUrl.StartsWith(siteRoot)) && (!redirectUrl.StartsWith(siteRoot.Replace("https://", "http://"))))
                    {
                        ViewState["ReturnUrl"] = siteRoot +"/"+ returnUrlParam;
                    }
                }
            }

            //this.DestinationPageUrl = GetRedirectPath();
            if (setRedirectUrl)
            {
                this.DestinationPageUrl = GetRedirectPath();
            }

            if (WebConfigSettings.DebugLoginRedirect)
            {
                log.Info("Login redirect url was " + this.DestinationPageUrl + " for Site Root " + siteRoot);
            }
        }


        protected void SiteLogin_LoginError(object sender, EventArgs e)
        {
            int errorCount = (int)ViewState["LoginErrorCount"] + 1;
            ViewState["LoginErrorCount"] = errorCount;

            //if ((siteSettings != null)
            //    && (!siteSettings.UseLdapAuth)
            //    && (siteSettings.PasswordFormat != 1)
            //    && (siteSettings.AllowPasswordRetrieval)
            //    && (errorCount >= siteSettings.MaxInvalidPasswordAttempts - 1)
            //    && (this.PasswordRecoveryUrl != String.Empty)
            //    )
            //{
            //    WebUtils.SetupRedirect(this, this.PasswordRecoveryUrl);
            //}
        }


        void SiteLogin_LoggingIn(object sender, LoginCancelEventArgs e)
        {
            //SiteUser siteUser = new SiteUser(this.UserName);// dang nhap cho nay. rac roi
            //if (siteUser.UserId != Guid.Empty)
            //{
            //    if (siteUser.IsLockedOut)
            //    {
            //        e.Cancel = true;
            //        //this.FailureText = Resource.LoginAccountLockedMessage;
            //        Label lblFailure = (Label)this.FindControl("FailureText");
            //        if (lblFailure != null)
            //        {
            //            lblFailure.Visible = true;
            //            lblFailure.Text = "Tài khoản đã bị khóa";
            //        }
            //    }
            //}
        }


        protected void SiteLogin_LoggedIn(object sender, EventArgs e)
        {
            IUserBAL itemBAL = new UserBAL();
            User item = itemBAL.GetUserByLoginName(this.UserName.Trim());

            SiteUser siteUser = new SiteUser();
            siteUser.LoginName = item.UserID;
            siteUser.Name = item.UserName;
            siteUser.UserId = item.UserGuid;

            string cookieName = "siteguid" + SiteUtils.GetSiteId();
            CookieHelper.SetCookie(cookieName, siteUser.UserId.ToString(), this.RememberMeSet);

            if (siteUser.UserId == Guid.Empty)
                return;


            UserSignInEventArgs u = new UserSignInEventArgs(siteUser);
            OnUserSignIn(u);
        }

        #region Events

        //private void HookupSignInEventHandlers()
        //{
        //    // this is a hook so that custom code can be fired when pages are created
        //    // implement a PageCreatedEventHandlerPovider and put a config file for it in
        //    // /Setup/ProviderConfig/pagecreatedeventhandlers
        //    try
        //    {
        //        foreach (UserSignInHandlerProvider handler in UserSignInHandlerProviderManager.Providers)
        //        {
        //            this.UserSignIn += handler.UserSignInEventHandler;
        //        }
        //    }
        //    catch (TypeInitializationException ex)
        //    {
        //        log.Error(ex);
        //    }

        //}

        //public event UserSignInEventHandler UserSignIn;

        protected void OnUserSignIn(UserSignInEventArgs e)
        {
            foreach (UserSignInHandlerProvider handler in UserSignInHandlerProviderManager.Providers)
            {
                handler.UserSignInEventHandler(null, e);
            }
            //if (UserSignIn != null)
            //{
            //    UserSignIn(this, e);
            //}
        }

        #endregion


        private string GetRedirectPath()
        {
            string redirectPath = WebConfigSettings.PageToRedirectToAfterSignIn;

            if (redirectPath.EndsWith(".aspx"))
            {
                return redirectPath;
            }

            if (ViewState["ReturnUrl"] != null)
            {
                redirectPath = ViewState["ReturnUrl"].ToString();
            }

            if (String.IsNullOrEmpty(redirectPath) ||
            redirectPath.Contains("AccessDenied") ||
            redirectPath.Contains("Login") ||
            redirectPath.Contains("SignIn") ||
            redirectPath.Contains("ConfirmRegistration.aspx") ||
            redirectPath.Contains("RecoverPassword.aspx") ||
            redirectPath.Contains("Register")
            )
                return siteRoot;

            if (Page.Request.Params["r"] == "h")
                return siteRoot;

            return redirectPath;
        }
    }
}
