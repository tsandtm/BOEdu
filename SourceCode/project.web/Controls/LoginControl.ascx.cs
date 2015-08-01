using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using nvn.Library;

namespace project.web.Controls
{
    public partial class LoginControl : System.Web.UI.UserControl
    {
        //Constituent controls inside LoginControl
        private Label lblUserID;
        //private SiteLabel lblEmail;
        private TextBox txtUserName;
        private CheckBox chkRememberMe;
        private LinkButton btnLogin;
        private HyperLink lnkRecovery;
        private HyperLink lnkExtraLink;
        private TextBox txtPassword;
        private Panel divCaptcha = null;
        //private CaptchaControl captcha = null;

        private string siteRoot = string.Empty;

        private bool setFocus = false;
        public bool SetFocus
        {
            get
            {
                return setFocus;
            }
            set
            {
                setFocus = value;
            }
        }

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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.IsAuthenticated)
            {
                // user is logged in
                this.Visible = false;
                return;
            }

            LoadSettings();
            PopulateLabels();

            PopulateControls();
        }

        private void PopulateControls()
        {
            LoginCtrl.SetRedirectUrl = setRedirectUrl;

            lblUserID = (Label)this.LoginCtrl.FindControl("lblUserID");
            //lblEmail = (SiteLabel)this.LoginCtrl.FindControl("lblEmail");
            txtUserName = (TextBox)this.LoginCtrl.FindControl("UserName");
            txtPassword = (TextBox)this.LoginCtrl.FindControl("Password");
            chkRememberMe = (CheckBox)this.LoginCtrl.FindControl("RememberMe");
            btnLogin = (LinkButton)this.LoginCtrl.FindControl("Login");
            lnkRecovery = (HyperLink)this.LoginCtrl.FindControl("lnkPasswordRecovery");
            lnkExtraLink = (HyperLink)this.LoginCtrl.FindControl("lnkRegisterExtraLink");

            divCaptcha = (Panel)LoginCtrl.FindControl("divCaptcha");
            //captcha = (CaptchaControl)LoginCtrl.FindControl("captcha");
            //if (!siteSettings.RequireCaptchaOnLogin)
            //{
            //    if (divCaptcha != null) { divCaptcha.Visible = false; }
            //    if (captcha != null) { captcha.Captcha.Enabled = false; }
            //}
            //else
            //{
            //    captcha.ProviderName = siteSettings.CaptchaProvider;
            //    captcha.RecaptchaPrivateKey = siteSettings.RecaptchaPrivateKey;
            //    captcha.RecaptchaPublicKey = siteSettings.RecaptchaPublicKey;

            //}

            //if ((siteSettings.UseEmailForLogin) && (!siteSettings.UseLdapAuth))
            //{
            //    if (!WebConfigSettings.AllowLoginWithUsernameWhenSiteSettingIsUseEmailForLogin)
            //    {
            //        RegularExpressionValidator regexEmail = new RegularExpressionValidator();
            //        regexEmail.ControlToValidate = txtUserName.ID;
            //        //regexEmail.ValidationExpression = @"^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@(([0-9a-zA-Z])+([-\w]*[0-9a-zA-Z])*\.)+[a-zA-Z]{2,9})$";
            //        regexEmail.ValidationExpression = SecurityHelper.RegexEmailValidationPattern;
            //        regexEmail.ErrorMessage = Resource.LoginFailedInvalidEmailFormatMessage;
            //        this.LoginCtrl.Controls.Add(regexEmail);
            //    }

            //}

            //if (siteSettings.UseEmailForLogin && !siteSettings.UseLdapAuth)
            //{
            //    this.lblUserID.Visible = false;
            //}
            //else
            //{
            //    this.lblEmail.Visible = false;
            //}

            if (setFocus)
            {
                txtUserName.Focus();
            }

            lnkRecovery.Visible = false;// ((siteSettings.AllowPasswordRetrieval || siteSettings.AllowPasswordReset) && (!siteSettings.UseLdapAuth ||
            //                                   (siteSettings.UseLdapAuth && WebConfigSettings.UseLDAPFallbackAuthentication)));

            lnkRecovery.NavigateUrl = this.LoginCtrl.PasswordRecoveryUrl;
            lnkRecovery.Text = this.LoginCtrl.PasswordRecoveryText;

            lnkExtraLink.NavigateUrl = siteRoot + "/Secure/Register.aspx";
            lnkExtraLink.Text = "Đăng ký";//Resource.RegisterLink;
            lnkExtraLink.Visible = false;// siteSettings.AllowNewRegistration;

            string returnUrlParam = Page.Request.Params.Get("returnurl");
            if (!String.IsNullOrEmpty(returnUrlParam))
            {
                //string redirectUrl = returnUrlParam;
                lnkExtraLink.NavigateUrl += "?returnurl=" + returnUrlParam;
            }

            chkRememberMe.Visible = true;// WebConfigSettings.AllowPersistentLoginCookie;
            chkRememberMe.Text = this.LoginCtrl.RememberMeText;

            btnLogin.Text = this.LoginCtrl.LoginButtonText;
            //SiteUtils.SetButtonAccessKey(btnLogin, AccessKeys.LoginAccessKey);

        }

        private void PopulateLabels()
        {
        }

        private void LoadSettings()
        {
            siteRoot = SiteUtils.GetNavigationSiteRoot();
        }


        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            Load += new EventHandler(Page_Load);
        }
    }
}
