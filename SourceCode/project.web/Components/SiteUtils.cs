using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Web.UI;
using System.Globalization;
using System.Net;
using System.IO;
using log4net;
using thanhdai18htquanlyphanquyen.Library.Models;
using System.Web.UI.WebControls;
using thanhdai18htquanlyphanquyen.Library.Framework;
using thanhdai18htquanlyphanquyen.Library.WebHelpers;

namespace project.web
{
    public static class SiteUtils
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(SiteUtils));

        //tên ứng dụng cài đặt ở đây file này chép lên project web và được thay đổi theo từng ứng dụng
        public static string GetSiteId()
        {
            return "QL-HoatDongHopTacDoanhNhiep";
        }
///////////////////////
        public static CultureInfo GetCulture()
        {
            return System.Globalization.CultureInfo.GetCultureInfo("vi-VN");
        }

        //trả về trang thái của quyền được phép hay không
        public static bool GetPermuission(int level)
        {
            string permission = "";
            if (HttpContext.Current.Session["permissionvalue"] != null)
                permission = HttpContext.Current.Session["permissionvalue"].ToString();
            else
                HttpContext.Current.Response.Redirect(SiteUtils.GetNavigationSiteRoot() + "/Secure/Logoff.aspx");
            char cherl=' ';
            try
            {
                cherl = permission[level];
            }
            catch { }
            return cherl == '1' ? true : false;
        }
        //trả về list thông tin quản lý
        /// <summary>
        /// 1=loại hình lao động
        /// 2=đơn vị
        /// 3=user
        /// 0= mặc đinh 
        /// </summary>
        /// <param name="UserGuid"></param>
        /// <param name="Loaiquanly"></param>
        /// <returns></returns>
        public static List<ListItem> GetListThongTinQuanLy(Guid UserGuid,out int Loaiquanly)
        {
            ThongTinQuanLyBAL ItemBAL = new ThongTinQuanLyBAL();
            Loaiquanly = 0;//mặc định không quản lý nào 
            Guid loaiHinhQuanLyGuid=Guid.Empty;
            List<ListItem> list = ItemBAL.GetThongTinQuanLyByUserApp(UserGuid, GetSiteId(),out  loaiHinhQuanLyGuid);
            switch (loaiHinhQuanLyGuid.ToString().ToLower())
            {
                case "037083b5-b90a-472d-bc28-176accc826b5"://loại hình lao động
                    Loaiquanly = 1;
                    break;
                case "e03e3f8d-fca0-4e31-921c-379c0d07161c"://đơn vị
                    Loaiquanly = 2;
                    break;
                case "6cc87cc4-83fb-48c4-82d3-e36b168a1b20"://user
                    Loaiquanly = 3;
                     break;
                default:
                    break;
            }
            
            return list;
        }
        public static Guid GetCurrentUserId()
        {
            if (HttpContext.Current == null || HttpContext.Current.User == null)
                return Guid.Empty;
            if (!HttpContext.Current.Request.IsAuthenticated)
                return Guid.Empty;
            if (HttpContext.Current.Session["LoggedUserId"] != null)
            {
                return new Guid(HttpContext.Current.Session["LoggedUserId"].ToString());
            }
            else
            {

                UserBAL itemBAL = new UserBAL();
                User item = itemBAL.GetUserByLoginName(HttpContext.Current.User.Identity.Name.Trim());
                return item.UserGuid;
            }
        }

        public static void RedirectToSignOut()
        {
            if (HttpContext.Current == null)
            {
                return;
            }
            if (HttpContext.Current.Request == null)
            {
                return;
            }

            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.Redirect(SiteUtils.GetNavigationSiteRoot() + "/Secure/Logoff.aspx", true);

        }

        #region obsolete

        //public static string GetNavigationSiteRoot()
        //{
        //    if (HttpContext.Current == null) return string.Empty;

        //    if (HttpContext.Current.Items["navigationRoot"] != null)
        //    {
        //        return HttpContext.Current.Items["navigationRoot"].ToString();
        //    }

        //    string navigationRoot =  WebUtils.GetSiteRoot();


        //    HttpContext.Current.Items["navigationRoot"] = navigationRoot;

        //    return navigationRoot;

        //}

        ////public static string GetInsecureNavigationSiteRoot()
        ////{
        ////    return GetNavigationSiteRoot().Replace("https", "http");
        ////}

        //public static string GetSecureNavigationSiteRoot()
        //{
        //    if (HttpContext.Current == null) return string.Empty;

        //    if (HttpContext.Current.Items["securenavigationRoot"] != null)
        //    {
        //        return HttpContext.Current.Items["securenavigationRoot"].ToString();
        //    }

        //    string navigationRoot =  WebUtils.GetSecureSiteRoot();
        //    bool useFolderForSiteDetection = ConfigHelper.GetBoolProperty("UseFoldersInsteadOfHostnamesForMultipleSites", false);

        //    HttpContext.Current.Items["securenavigationRoot"] = navigationRoot;

        //    return navigationRoot;

        //}

        //public static bool SslIsAvailable()
        //{
        //    if (WebConfigSettings.SslisAvailable) { return true; }

        //    string key = "Site" + "-SSLIsAvailable";
        //    if (ConfigurationManager.AppSettings[key] != null)
        //    {
        //        return ConfigHelper.GetBoolProperty(key, false);
        //    }

        //    return false;

        //}

        //public static void ForceSsl()
        //{
        //    if (WebConfigSettings.UseFoldersInsteadOfHostnamesForMultipleSites)
        //    {
        //        bool proxyPreventsSSLDetection;
        //        bool.TryParse(ConfigurationManager.AppSettings["ProxyPreventsSSLDetection"], out proxyPreventsSSLDetection);
        //        // proxyPreventsSSLDetection is false if parsing failed for any reason

        //        if (!proxyPreventsSSLDetection)
        //        {
        //            string pageUrl = HttpContext.Current.Request.Url.ToString();
        //            if (pageUrl.StartsWith("http:"))
        //            {
        //                string secureUrl =  WebUtils.GetSecureSiteRoot()
        //                    + HttpContext.Current.Request.RawUrl;

        //                HttpContext.Current.Response.Redirect(secureUrl, true);
        //            }
        //        }
        //    }
        //    else
        //    {
        //         WebUtils.ForceSsl();
        //    }
        //}

        //public static void ClearSsl()
        //{
        //    string pageUrl = HttpContext.Current.Request.Url.ToString();
        //    if (pageUrl.StartsWith("https:"))
        //    {
        //        string insecureUrl =  WebUtils.GetInSecureSiteRoot()
        //            + HttpContext.Current.Request.RawUrl;

        //        HttpContext.Current.Response.Redirect(insecureUrl, true);
        //    }
        //}

        //public static void RedirectToLoginPage(Control pageOrControl)
        //{
        //    string redirectUrl
        //        = string.Format(CultureInfo.InvariantCulture, "{0}" + GetLoginRelativeUrl() + "?returnurl={1}",
        //                       GetNavigationSiteRoot(),
        //                       HttpUtility.UrlEncode(HttpContext.Current.Request.RawUrl));

        //     WebUtils.SetupRedirect(pageOrControl, redirectUrl);
        //}

        //public static void RedirectToLoginPage(Control pageOrControl, string returnUrl)
        //{
        //    string redirectUrl
        //        = string.Format(CultureInfo.InvariantCulture, "{0}" + GetLoginRelativeUrl() + "?returnurl={1}",
        //                       GetNavigationSiteRoot(),
        //                       HttpUtility.UrlEncode(returnUrl));

        //     WebUtils.SetupRedirect(pageOrControl, redirectUrl);
        //}

        //public static void RedirectToLoginPage(Control pageOrControl, bool useHardRedirect)
        //{
        //    if (!useHardRedirect)
        //    {
        //        RedirectToLoginPage(pageOrControl);
        //        return;
        //    }

        //    string redirectUrl
        //        = string.Format(CultureInfo.InvariantCulture, "{0}" + GetLoginRelativeUrl() + "?returnurl={1}",
        //                       GetNavigationSiteRoot(),
        //                       HttpUtility.UrlEncode(HttpContext.Current.Request.RawUrl));

        //    pageOrControl.Page.Response.Redirect(redirectUrl);

        //    // WebUtils.SetupRedirect(pageOrControl, redirectUrl);
        //}

        //public static string GetLoginRelativeUrl()
        //{
        //    if (ConfigurationManager.AppSettings["LoginPageRelativeUrl"] != null)
        //        return ConfigurationManager.AppSettings["LoginPageRelativeUrl"];

        //    return "~/Secure/Loginx.aspx";

        //}

        //public static void RedirectToUrl(string url)
        //{
        //    if (HttpContext.Current == null) { return; }

        //    HttpContext.Current.Response.RedirectLocation = url;
        //    HttpContext.Current.Response.StatusCode = 302;
        //    HttpContext.Current.Response.StatusDescription = "Redirecting to " + url;
        //    HttpContext.Current.Response.Write("Redirecting to " + url);
        //    HttpContext.Current.ApplicationInstance.CompleteRequest();

        //}

        //public static void RedirectToEditAccessDeniedPage()
        //{
        //    HttpContext.Current.Response.Redirect(GetNavigationSiteRoot() + "/EditAccessDenied.aspx", true);
        //    //RedirectToUrl(GetNavigationSiteRoot() + "/EditAccessDenied.aspx");
        //}


        //public static void RedirectToAccessDeniedPage()
        //{
        //    //HttpContext.Current.Response.Redirect(GetNavigationSiteRoot() + "/AccessDenied.aspx", false);
        //    RedirectToUrl(GetNavigationSiteRoot() + "/AccessDenied.aspx");
        //}

        //public static void RedirectToAccessDeniedPage(Control pageOrControl)
        //{
        //    string redirectUrl
        //        = GetNavigationSiteRoot() + "/AccessDenied.aspx";

        //     WebUtils.SetupRedirect(pageOrControl, redirectUrl);
        //}

        //public static void RedirectToAccessDeniedPage(Control pageOrControl, bool useHardRedirect)
        //{
        //    if (!useHardRedirect)
        //    {
        //        RedirectToAccessDeniedPage(pageOrControl);
        //        return;
        //    }

        //    string redirectUrl
        //        = GetNavigationSiteRoot() + "/AccessDenied.aspx";

        //    pageOrControl.Page.Response.Redirect(redirectUrl);

        //    // WebUtils.SetupRedirect(pageOrControl, redirectUrl);
        //}


        //public static void RedirectToDefault()
        //{
        //    //HttpContext.Current.Response.Redirect(GetNavigationSiteRoot() + "/default.aspx", false);
        //    RedirectToUrl(GetNavigationSiteRoot() + "/Default.aspx");
        //}


        //public static string GetRoleCookieName()
        //{
        //    String hostName =  WebUtils.GetHostName();

        //    return hostName + "portalroles1";

        //}

        #endregion

        //public static String SuggestFriendlyUrl(
        //    String pageName,
        //    SiteSettings siteSettings)
        //{
        //    String friendlyUrl = CleanStringForUrl(pageName);
        //    if (WebConfigSettings.AlwaysUrlEncode)
        //    {
        //        friendlyUrl = HttpUtility.UrlEncode(friendlyUrl);
        //    }


        //    switch (siteSettings.DefaultFriendlyUrlPattern)
        //    {
        //        case SiteSettings.FriendlyUrlPattern.PageNameWithDotASPX:
        //            friendlyUrl += ".aspx";
        //            break;

        //    }

        //    int i = 1;
        //    while (FriendlyUrl.Exists(siteSettings.SiteId, friendlyUrl))
        //    {
        //        friendlyUrl = i.ToString() + friendlyUrl;
        //    }



        //    if (WebConfigSettings.ForceFriendlyUrlsToLowerCase) { return friendlyUrl.ToLower(); }

        //    return friendlyUrl;
        //}

        public static string RemoveInvalidUrlChars(string input)
        {
            return input.Replace(":", string.Empty).Replace("?", string.Empty).Replace("&", "-").Replace("#", string.Empty);
        }

        public static String CleanStringForUrl(String input)
        {
            String outputString = RemovePunctuation(input.Replace("&", "-")).Replace(" - ", "-").Replace("--", "-").Replace(" ", "-").Replace("/", String.Empty).Replace("\"", String.Empty).Replace("'", String.Empty).Replace("#", String.Empty).Replace("~", String.Empty).Replace("`", String.Empty).Replace("@", String.Empty).Replace("$", String.Empty).Replace("*", String.Empty).Replace("^", String.Empty).Replace("(", String.Empty).Replace(")", String.Empty).Replace("+", String.Empty).Replace("=", String.Empty).Replace("%", String.Empty).Replace(">", String.Empty).Replace("<", String.Empty);

            //if (WebConfigSettings.UseClosestAsciiCharsForUrls) { return outputString.ToAsciiIfPossible(); }

            return outputString;
        }

        private static String RemovePunctuation(String input)
        {
            String outputString = String.Empty;
            if (input != null)
            {
                outputString = input.Replace(".", String.Empty).Replace(",", String.Empty).Replace(":", String.Empty).Replace("?", String.Empty).Replace("!", String.Empty).Replace(";", String.Empty).Replace("&", String.Empty).Replace("{", String.Empty).Replace("}", String.Empty).Replace("[", String.Empty).Replace("]", String.Empty);
            }
            return outputString;
        }

        //public static void SetupEditor(EditorControl editor)
        //{
        //    SetupEditor(editor, WebConfigSettings.UseSkinCssInEditor);
        //}

        //public static void SetupEditor(EditorControl editor, bool useSkinCss)
        //{
        //    SetupEditor(editor, useSkinCss, string.Empty);
        //}

        ///// <summary>
        ///// You should pass your editor to this method during pre-init or init
        ///// </summary>
        ///// <param name="editor"></param>
        //public static void SetupEditor(EditorControl editor, bool useSkinCss, string preferredProvider)
        //{
        //    if (HttpContext.Current == null) return;
        //    if (HttpContext.Current.Request == null) return;
        //    if (editor == null) return;

        //    SiteSettings siteSettings = CacheHelper.GetCurrentSiteSettings();
        //    if (siteSettings == null) return;

        //    string providerName = siteSettings.EditorProviderName;
        //    if (siteSettings.AllowUserEditorPreference)
        //    {
        //        SiteUser siteUser = GetCurrentUser();
        //        if ((siteUser != null) && (siteUser.EditorPreference.Length > 0))
        //        {
        //            providerName = siteUser.EditorPreference;
        //        }

        //    }


        //    string loweredBrowser = string.Empty;

        //    if (HttpContext.Current.Request.UserAgent != null)
        //    {
        //        loweredBrowser = HttpContext.Current.Request.UserAgent.ToLower();
        //    }


        //    if (
        //        (loweredBrowser.Contains("safari"))
        //        && (WebConfigSettings.ForceTinyMCEInSafari)
        //        )
        //    {
        //        providerName = "TinyMCEProvider";
        //    }

        //    if (
        //        (loweredBrowser.Contains("opera"))
        //        && (WebConfigSettings.ForceTinyMCEInOpera)
        //        )
        //    {
        //        providerName = "TinyMCEProvider";
        //    }

        //    if (
        //        (loweredBrowser.Contains("iphone"))
        //        && (WebConfigSettings.ForcePlainTextInIphone)
        //        )
        //    {
        //        providerName = "TextAreaProvider";
        //    }

        //    if (
        //        (loweredBrowser.Contains("ipad"))
        //        && (WebConfigSettings.ForcePlainTextInIpad)
        //        )
        //    {
        //        providerName = "TextAreaProvider";
        //    }

        //    if (
        //        (loweredBrowser.Contains("android"))
        //        && (WebConfigSettings.ForcePlainTextInAndroid)
        //        )
        //    {
        //        providerName = "TextAreaProvider";
        //    }

        //    string siteRoot = null;
        //    if (siteSettings.SiteFolderName.Length > 0)
        //    {
        //        siteRoot = siteSettings.SiteRoot;
        //    }
        //    if (siteRoot == null) siteRoot =  WebUtils.GetSiteRoot();

        //    if (!string.IsNullOrEmpty(preferredProvider)) { providerName = preferredProvider; }

        //    editor.ProviderName = providerName;
        //    editor.WebEditor.SiteRoot = siteRoot;
        //    //editor.WebEditor.SkinName = siteSettings.EditorSkin.ToString();
        //    if (useSkinCss)
        //    {
        //        editor.WebEditor.EditorCSSUrl = GetEditorStyleSheetUrl();
        //    }

        //    CultureInfo defaultCulture = ResourceHelper.GetDefaultCulture();
        //    if (defaultCulture.TextInfo.IsRightToLeft)
        //    {
        //        editor.WebEditor.TextDirection = Direction.RightToLeft;
        //    }



        //}

        ///// <summary>
        ///// You should pass your editor to this method during pre-init or init
        ///// </summary>
        ///// <param name="editor"></param>
        //public static void SetupNewsletterEditor(EditorControl editor)
        //{
        //    if (HttpContext.Current == null) { return; }
        //    if (HttpContext.Current.Request == null) { return; }
        //    if (editor == null) return;

        //    SiteSettings siteSettings = CacheHelper.GetCurrentSiteSettings();
        //    if (siteSettings == null) { return; }

        //    string providerName = siteSettings.NewsletterEditor;

        //    string loweredBrowser = string.Empty;

        //    if (HttpContext.Current.Request.UserAgent != null)
        //    {
        //        loweredBrowser = HttpContext.Current.Request.UserAgent.ToLower();
        //    }

        //    if (
        //        (loweredBrowser.Contains("iphone"))
        //        && (WebConfigSettings.ForcePlainTextInIphone)
        //        )
        //    {
        //        providerName = "TextAreaProvider";
        //    }

        //    if (
        //        (loweredBrowser.Contains("android"))
        //        && (WebConfigSettings.ForcePlainTextInAndroid)
        //        )
        //    {
        //        providerName = "TextAreaProvider";
        //    }

        //    string siteRoot = null;
        //    if (siteSettings.SiteFolderName.Length > 0)
        //    {
        //        siteRoot = siteSettings.SiteRoot;
        //    }
        //    if (siteRoot == null) siteRoot =  WebUtils.GetSiteRoot();

        //    editor.ProviderName = providerName;
        //    editor.WebEditor.SiteRoot = siteRoot;

        //    CultureInfo defaultCulture = ResourceHelper.GetDefaultCulture();
        //    if (defaultCulture.TextInfo.IsRightToLeft)
        //    {
        //        editor.WebEditor.TextDirection = Direction.RightToLeft;
        //    }
        //}

        public static string GetIP4Address()
        {
            string ip4Address = string.Empty;
            if (HttpContext.Current == null)
            {
                return ip4Address;
            }
            if (HttpContext.Current.Request == null)
            {
                return ip4Address;
            }
            if (HttpContext.Current.Request.UserHostAddress == null)
            {
                return ip4Address;
            }

            try
            {
                IPAddress ip = IPAddress.Parse(HttpContext.Current.Request.UserHostAddress);
                if (ip.AddressFamily.ToString() == "InterNetwork")
                {
                    return ip.ToString();
                }
            }
            catch (FormatException)
            {
            }
            catch (ArgumentNullException)
            {
            }

            try
            {
                foreach (IPAddress IPA in Dns.GetHostAddresses(HttpContext.Current.Request.UserHostAddress))
                {
                    if (IPA.AddressFamily.ToString() == "InterNetwork")
                    {
                        ip4Address = IPA.ToString();
                        break;
                    }
                }
            }
            catch (ArgumentException)
            {
            }
            catch (System.Net.Sockets.SocketException)
            {
            }

            if (ip4Address != string.Empty)
            {
                return ip4Address;
            }

            //this part makes no sense it would get the local server ip address
            try
            {
                foreach (IPAddress IPA in Dns.GetHostAddresses(Dns.GetHostName()))
                {
                    if (IPA.AddressFamily.ToString() == "InterNetwork")
                    {
                        ip4Address = IPA.ToString();
                        break;
                    }
                }
            }
            catch (ArgumentException)
            {
            }
            catch (System.Net.Sockets.SocketException)
            {
            }

            return ip4Address;
        }

        //public static string BuildStylesListForTinyMce()
        //{
        //    StringBuilder styles = new StringBuilder();

        //    string comma = string.Empty;

        //    if (WebConfigSettings.AddSystemStyleTemplatesAboveSiteTemplates)
        //    {
        //        styles.Append("FloatPanel=floatpanel,Image on Right=floatrightimage,Image on Left=floatleftimage");
        //        comma = ",";
        //    }


        //    SiteSettings siteSettings = CacheHelper.GetCurrentSiteSettings();
        //    if (siteSettings != null)
        //    {
        //        using (IDataReader reader = ContentStyle.GetAllActive(siteSettings.SiteGuid))
        //        {
        //            while (reader.Read())
        //            {
        //                styles.Append(comma + reader["Name"].ToString() + "=" + reader["CssClass"].ToString());
        //                comma = ",";
        //            }
        //        }

        //    }

        //    if (WebConfigSettings.AddSystemStyleTemplatesBelowSiteTemplates)
        //    {
        //        styles.Append(comma + "FloatPanel=floatpanel,Image on Right=floatrightimage,Image on Left=floatleftimage");
        //    }

        //    return styles.ToString();
        //}

        public static bool IsImageFileExtension(string fileExtension)
        {
            List<string> allowedExtensions = new List<string>();
            allowedExtensions.Add(".jpg");
            allowedExtensions.Add(".jpeg");
            allowedExtensions.Add(".png");
            allowedExtensions.Add(".gif");

            foreach (string ext in allowedExtensions)
            {
                if (string.Equals(fileExtension, ext, StringComparison.InvariantCultureIgnoreCase))
                {
                    return true;
                }
            }

            return false;
        }

        //public static string ImageFileExtensions()
        //{
        //    return ".gif|.jpg|.jpeg|.png";
        //}

        //public static bool IsAllowedMediaFile(this FileInfo fileInfo)
        //{
        //    List<string> allowedExtensions = StringHelper.SplitOnPipes(WebConfigSettings.AllowedMediaFileExtensions);
        //    foreach (string ext in allowedExtensions)
        //    {
        //        if (string.Equals(fileInfo.Extension, ext, StringComparison.InvariantCultureIgnoreCase)) { return true; }
        //    }

        //    return false;

        //}

        //public static bool IsAllowedUploadBrowseFile(this FileInfo fileInfo, string allowedExtensions)
        //{
        //    List<string> allowed = StringHelper.SplitOnPipes(allowedExtensions);
        //    foreach (string ext in allowed)
        //    {
        //        if (string.Equals(fileInfo.Extension, ext, StringComparison.InvariantCultureIgnoreCase)) { return true; }
        //    }

        //    return false;
        //}

        //public static bool IsAllowedUploadBrowseFile(string fileExtension, string allowedExtensions)
        //{
        //    List<string> allowed = StringHelper.SplitOnPipes(allowedExtensions);
        //    foreach (string ext in allowed)
        //    {
        //        if (string.Equals(fileExtension, ext, StringComparison.InvariantCultureIgnoreCase)) { return true; }
        //    }

        //    return false;
        //}

        //public static string GetEditorStyleSheetUrl()
        //{
        //    if (WebConfigSettings.EditorCssUrlOverride.Length > 0) { return WebConfigSettings.EditorCssUrlOverride; }

        //    string editorCss = "csshandler.ashx";
        //    if (WebConfigSettings.UsingOlderSkins)
        //    {
        //        editorCss = "style.css";
        //    }

        //    string skinName = "styleshout-techmania";

        //    SiteSettings siteSettings = CacheHelper.GetCurrentSiteSettings();

        //    string basePath =  WebUtils.GetSiteRoot() + "/Data/Sites/" + siteSettings.SiteId.ToString(CultureInfo.InvariantCulture) + "/skins/";

        //    //SiteSettings siteSettings = (SiteSettings) HttpContext.Current.Items["SiteSettings"];

        //    PageSettings currentPage = CacheHelper.GetCurrentPage();
        //    if (siteSettings != null)
        //    {
        //        // very old skins were .ascx
        //        skinName = siteSettings.Skin.Replace(".ascx", string.Empty);

        //        if (siteSettings.AllowUserSkins)
        //        {
        //            string skinCookieName = "mojoUserSkin" + siteSettings.SiteId.ToString(CultureInfo.InvariantCulture);

        //            if (CookieHelper.CookieExists(skinCookieName))
        //            {
        //                string cookieValue = CookieHelper.GetCookieValue(skinCookieName);
        //                if (cookieValue.Length > 0)
        //                {
        //                    skinName = cookieValue.Replace(".ascx", string.Empty);
        //                }
        //            }
        //        }

        //        if ((currentPage != null) && (siteSettings.AllowPageSkins))
        //        {
        //            if (currentPage.Skin.Length > 0)
        //            {
        //                skinName = currentPage.Skin.Replace(".ascx", string.Empty);

        //            }
        //        }



        //        if (HttpContext.Current.Request.Params.Get("skin") != null)
        //        {
        //            skinName = HttpContext.Current.Request.Params.Get("skin");

        //        }

        //        if (editorCss == "csshandler.ashx")
        //        {
        //            return basePath + skinName + "/" + editorCss + "?skin=" + skinName;
        //        }

        //        return basePath + skinName + "/" + editorCss;

        //    }

        //    return "/Data/Sites/1/skins/styleshout-tecmania/style.css";
        //}


        //public static void SetButtonAccessKey(Button button, string accessKey)
        //{
        //    if (!WebConfigSettings.UseShortcutKeys) return;

        //    button.AccessKey = accessKey;
        //    button.Text += GetButtonAccessKeyPostfix(accessKey);
        //}


        //public static string GetButtonAccessKeyPostfix(string accessKey)
        //{
        //    if (HttpContext.Current == null) return String.Empty;

        //    string browser = HttpContext.Current.Request.Browser.Browser;
        //    string browserAccessKey = browser.ToLower().Contains("opera")
        //                                  ? AccessKeys.BrowserOperaAccessKey
        //                                  : AccessKeys.BrowserAccessKey;

        //    return string.Format(CultureInfo.InvariantCulture, " [{0}+{1}]", browserAccessKey, accessKey);
        //}

        //public static string RolesThatCanUploadAndBrowse()
        //{
        //    // TODO: make this site specific

        //    return WebConfigSettings.RolesThatCanUploadAndBrowse;


        //}

        //public static string RolesThatCanManageUsers()
        //{
        //    // TODO: make this site specific

        //    return WebConfigSettings.RolesThatCanManageUsers;


        //}

        /// <summary>
        /// this method is deprecated
        /// </summary>
        [Obsolete("This method is obsolete. You should use if(!Request.IsAuthenticated) SiteUtils.RedirectToLogin(PageorControl); return;")]
        public static void AllowOnlyAuthenticated()
        {
            if (HttpContext.Current == null)
                return;
            if (!HttpContext.Current.Request.IsAuthenticated)
                RedirectToLoginPage();
        }

        [Obsolete("This method is obsolete. You should use if(!Request.IsAuthenticated) SiteUtils.RedirectToLogin(PageorControl); return;")]
        public static void AllowOnlyAuthenticated(Control pageOrControl)
        {
            if (HttpContext.Current == null)
                return;
            if (!HttpContext.Current.Request.IsAuthenticated)
                RedirectToLoginPage(pageOrControl);
        }

        [Obsolete("This method is obsolete. You should use if(!WebUser.IsAdmin) SiteUtils.RedirectToAccessDenied(PageorControl); return;")]
        public static void AllowOnlyAdmin()
        {
            if (HttpContext.Current == null)
                return;
            AllowOnlyAuthenticated();
            if (!HttpContext.Current.Request.IsAuthenticated)
                return;
            if (!WebUser.IsAdmin)
                RedirectToEditAccessDeniedPage();
        }

        [Obsolete("This method is obsolete. You should use if(!WebUser.IsAdminOrRoleAdmin) SiteUtils.RedirectToAccessDenied(PageorControl); return;")]
        public static void AllowOnlyAdminAndRoleAdmin()
        {
            if (HttpContext.Current == null)
                return;
            AllowOnlyAuthenticated();
            if (!HttpContext.Current.Request.IsAuthenticated)
                return;
            if (!WebUser.IsAdmin)
            {
                RedirectToEditAccessDeniedPage();
            }
        }

        //public static void AllowOnlyAdminAndNewsletterAdmin()
        //{
        //    if (HttpContext.Current == null) return;
        //    AllowOnlyAuthenticated();
        //    if (!HttpContext.Current.Request.IsAuthenticated) return;
        //    if ((!WebUser.IsAdmin) && (!WebUser.IsNewsletterAdmin))
        //    {
        //        RedirectToEditAccessDeniedPage();
        //    }
        //}

        [Obsolete("This method is obsolete. You should use if(!WebUser.IsAdminOrContentAdmin) SiteUtils.RedirectToAccessDenied(PageorControl); return;")]
        public static void AllowOnlyAdminAndContentAdmin()
        {
            if (HttpContext.Current == null)
                return;
            AllowOnlyAuthenticated();
            if (!HttpContext.Current.Request.IsAuthenticated)
                return;
            if (!WebUser.IsAdminOrContentAdmin)
                RedirectToEditAccessDeniedPage();
        }

        [Obsolete("This method is obsolete. You should use if(!WebUser.IsAdminOrContentAdminOrRoleAdmin) SiteUtils.RedirectToAccessDenied(PageorControl); return;")]
        public static void AllowOnlyAdminAndContentAdminAndRoleAdmin()
        {
            if (HttpContext.Current == null)
                return;
            AllowOnlyAuthenticated();
            if (!HttpContext.Current.Request.IsAuthenticated)
                return;
            if (!WebUser.IsAdminOrContentAdmin)
                RedirectToEditAccessDeniedPage();
        }

        [Obsolete("This method is obsolete. You should use RedirectToLoginPage(pageOrControl); return;")]
        public static void RedirectToLoginPage()
        {
            HttpContext.Current.Response.Redirect
            (string.Format(CultureInfo.InvariantCulture, "{0}" + GetLoginRelativeUrl() + "?returnurl={1}",
            GetNavigationSiteRoot(),
            HttpUtility.UrlEncode(HttpContext.Current.Request.RawUrl)),
            true);
        }

        public static void RedirectToLoginPage(Control pageOrControl)
        {
            string redirectUrl
            = string.Format(CultureInfo.InvariantCulture, "{0}" + GetLoginRelativeUrl() + "?returnurl={1}",
            GetNavigationSiteRoot(),
            HttpUtility.UrlEncode(HttpContext.Current.Request.RawUrl));

            WebUtils.SetupRedirect(pageOrControl, redirectUrl);
        }

        public static void RedirectToLoginPage(Control pageOrControl, string returnUrl)
        {
            string redirectUrl
            = string.Format(CultureInfo.InvariantCulture, "{0}" + GetLoginRelativeUrl() + "?returnurl={1}",
            GetNavigationSiteRoot(),
            HttpUtility.UrlEncode(returnUrl));

            WebUtils.SetupRedirect(pageOrControl, redirectUrl);
        }

        public static void RedirectToLoginPage(Control pageOrControl, bool useHardRedirect)
        {
            if (!useHardRedirect)
            {
                RedirectToLoginPage(pageOrControl);
                return;
            }

            string redirectUrl
            = string.Format(CultureInfo.InvariantCulture, "{0}" + GetLoginRelativeUrl() + "?returnurl={1}",
            GetNavigationSiteRoot(),
            HttpUtility.UrlEncode(HttpContext.Current.Request.RawUrl));

            pageOrControl.Page.Response.Redirect(redirectUrl);

            // WebUtils.SetupRedirect(pageOrControl, redirectUrl);
        }

        public static string GetLoginRelativeUrl()
        {
            if (ConfigurationManager.AppSettings["LoginPageRelativeUrl"] != null)
                return ConfigurationManager.AppSettings["LoginPageRelativeUrl"];

            return "/Secure/Login.aspx";
        }

        public static void RedirectToUrl(string url)
        {
            if (HttpContext.Current == null)
            {
                return;
            }

            HttpContext.Current.Response.RedirectLocation = url;
            HttpContext.Current.Response.StatusCode = 302;
            HttpContext.Current.Response.StatusDescription = "Redirecting to " + url;
            HttpContext.Current.Response.Write("Redirecting to " + url);
            HttpContext.Current.ApplicationInstance.CompleteRequest();
        }

        public static void RedirectToEditAccessDeniedPage()
        {
            HttpContext.Current.Response.Redirect(GetNavigationSiteRoot() + "/EditAccessDenied.aspx", true);
            //RedirectToUrl(GetNavigationSiteRoot() + "/EditAccessDenied.aspx");
        }


        public static void RedirectToAccessDeniedPage()
        {
            //HttpContext.Current.Response.Redirect(GetNavigationSiteRoot() + "/AccessDenied.aspx", false);
            RedirectToUrl(GetNavigationSiteRoot() + "/AccessDenied.aspx");
        }

        public static void RedirectToAccessDeniedPage(Control pageOrControl)
        {
            string redirectUrl
            = GetNavigationSiteRoot() + "/AccessDenied.aspx";

            WebUtils.SetupRedirect(pageOrControl, redirectUrl);
        }

        public static void RedirectToAccessDeniedPage(Control pageOrControl, bool useHardRedirect)
        {
            if (!useHardRedirect)
            {
                RedirectToAccessDeniedPage(pageOrControl);
                return;
            }

            string redirectUrl
            = GetNavigationSiteRoot() + "/AccessDenied.aspx";

            pageOrControl.Page.Response.Redirect(redirectUrl);

            // WebUtils.SetupRedirect(pageOrControl, redirectUrl);
        }


        public static void RedirectToDefault()
        {
            //HttpContext.Current.Response.Redirect(GetNavigationSiteRoot() + "/default.aspx", false);
            RedirectToUrl(GetNavigationSiteRoot() + "/Default.aspx");
        }


        public static void SetFormAction(System.Web.UI.Page page, string action)
        {
            page.Form.Action = action;
        }

        //public static void SetMasterPage(
        //    Page page,
        //    SiteSettings siteSettings,
        //    bool allowOverride)
        //{
        //    String skinFolder;
        //    String skinName;
        //    PageSettings currentPage = CacheHelper.GetCurrentPage();

        //    if (
        //        (HttpContext.Current != null)
        //        && (page != null)
        //        && (siteSettings != null)
        //        )
        //    {

        //        skinFolder = "~/Data/Sites/" + siteSettings.SiteId.ToString(CultureInfo.InvariantCulture) + "/skins/";
        //        skinName = siteSettings.Skin.Replace(".ascx", "") + "/layout.Master";

        //        // implement user skins
        //        if (siteSettings.AllowUserSkins)
        //        {
        //            string skinCookieName = "mojoUserSkin" + siteSettings.SiteId.ToString(CultureInfo.InvariantCulture);
        //            if (CookieHelper.CookieExists(skinCookieName))
        //            {
        //                string cookieValue = CookieHelper.GetCookieValue(skinCookieName);
        //                if (File.Exists(HttpContext.Current.Server.MapPath(skinFolder + cookieValue.Replace(".ascx", "") + "/layout.Master")))
        //                {
        //                    skinName = cookieValue.Replace(".ascx", "") + "/layout.Master";

        //                }

        //            }
        //        }

        //        // implement per page skins
        //        if (
        //            (allowOverride)
        //            && (siteSettings.AllowPageSkins)
        //            )
        //        {
        //            if (
        //                (currentPage != null)
        //                && (currentPage.Skin.Length > 0)
        //                )
        //            {
        //                if (File.Exists(HttpContext.Current.Server.MapPath(skinFolder + currentPage.Skin.Replace(".ascx", "") + "/layout.Master")))
        //                {
        //                    skinName = currentPage.Skin.Replace(".ascx", "") + "/layout.Master";
        //                }
        //            }
        //        }


        //        // implement skin preview using querystring param
        //        if (HttpContext.Current.Request.Params.Get("skin") != null)
        //        {
        //            string previewSkin = SanitizeSkinParam(HttpContext.Current.Request.Params.Get("skin"));

        //            if (!previewSkin.EndsWith("/layout.ascx"))
        //            {
        //                previewSkin += "/layout.Master";
        //            }


        //            if (File.Exists(HttpContext.Current.Server.MapPath(skinFolder + previewSkin)))
        //            {
        //                skinName = previewSkin;

        //            }

        //        }
        //    }
        //    else
        //    {
        //        // hard coded only at design time, at runtime we get this from siteSettings
        //        skinFolder = "~/Data/Sites/1/skins/";
        //        skinName = "styleshout-techmania/layout.Master";

        //    }

        //    page.MasterPageFile = skinFolder + skinName;

        //}

        //public static string SanitizeSkinParam(string skinName)
        //{
        //    if (string.IsNullOrEmpty(skinName)) { return skinName; }

        //    // protected against this xss attack
        //    // ?skin=1%00'"><ScRiPt%20%0a%0d>alert(403326057258)%3B</ScRiPt>
        //    return skinName.Replace("%", string.Empty).Replace(" ", string.Empty).Replace(">", string.Empty).Replace("<", string.Empty).Replace("'", string.Empty).Replace("\"", string.Empty);


        //}

        //public static void SetMasterPage(
        //    Page page,
        //    SiteSettings siteSettings,
        //    string skinName)
        //{

        //    if (HttpContext.Current == null) { return; }
        //    if (page == null) { return; }
        //    if (siteSettings == null) { return; }
        //    if (string.IsNullOrEmpty(skinName)) { return; }

        //    string masterPagePath = "~/Data/Sites/"
        //        + siteSettings.SiteId.ToString(CultureInfo.InvariantCulture)
        //        + "/skins/" + SanitizeSkinParam(skinName) + "/layout.master";

        //    page.MasterPageFile = masterPagePath;

        //}


        //public static void SetSkinCookie(SiteUser siteUser)
        //{
        //    if (siteUser == null) return;
        //    string skinCookieName = "mojoUserSkin" + siteUser.SiteId.ToString(CultureInfo.InvariantCulture);
        //    HttpCookie cookie = HttpContext.Current.Request.Cookies[skinCookieName];
        //    bool setCookie = (cookie == null) || (cookie.Value != siteUser.Skin);
        //    if (setCookie)
        //    {
        //        HttpCookie userSkinCookie = new HttpCookie(skinCookieName, siteUser.Skin);
        //        userSkinCookie.Expires = DateTime.Now.AddYears(1);
        //        HttpContext.Current.Response.Cookies.Add(userSkinCookie);

        //    }
        //}


        public static void SetDisplayNameCookie(string displayName)
        {
            if (String.IsNullOrEmpty(displayName))
                return;

            HttpCookie cookie = HttpContext.Current.Request.Cookies["DisplayName"];
            bool setCookie = (cookie == null) || (cookie.Value != displayName);
            if (setCookie)
            {
                HttpCookie userNameCookie = new HttpCookie("DisplayName", HttpUtility.HtmlEncode(displayName));
                userNameCookie.Expires = DateTime.Now.AddYears(1);
                HttpContext.Current.Response.Cookies.Add(userNameCookie);
            }
        }



        //public static FileInfo[] GetLogoList(SiteSettings siteSettings)
        //{
        //    if (siteSettings == null) return null;

        //    string logoPath = HttpContext.Current.Server.MapPath
        //        ( WebUtils.GetApplicationRoot() + "/Data/Sites/" + siteSettings.SiteId.ToString(CultureInfo.InvariantCulture) + "/logos/");

        //    DirectoryInfo dir = new DirectoryInfo(logoPath);
        //    return dir.Exists ? dir.GetFiles() : null;
        //}

        //public static FileInfo[] GetContentTemplateImageList(SiteSettings siteSettings)
        //{
        //    if (siteSettings == null) return null;

        //    string filePath = HttpContext.Current.Server.MapPath
        //        ( WebUtils.GetApplicationRoot() + "/Data/Sites/" + siteSettings.SiteId.ToString(CultureInfo.InvariantCulture) + "/htmltemplateimages/");

        //    DirectoryInfo dir = new DirectoryInfo(filePath);
        //    return dir.Exists ? dir.GetFiles() : null;
        //}

        //public static Gravatar.RatingType GetMaxAllowedGravatarRating()
        //{
        //    switch (WebConfigSettings.GravatarMaxAllowedRating)
        //    {
        //        case "PG":
        //            return Gravatar.RatingType.PG;

        //        case "R":
        //            return Gravatar.RatingType.R;

        //        case "X":
        //            return Gravatar.RatingType.X;


        //    }

        //    return Gravatar.RatingType.G;
        //}




        //public static FileInfo[] GetAvatarList(SiteSettings siteSettings)
        //{
        //    if (siteSettings == null) return null;

        //    string p =  WebUtils.GetApplicationRoot() + "/Data/Sites/" + siteSettings.SiteId.ToString(CultureInfo.InvariantCulture) + "/avatars";
        //    string avatarPath = HttpContext.Current.Server.MapPath(p);

        //    DirectoryInfo dir = new DirectoryInfo(avatarPath);
        //    return dir.Exists ? dir.GetFiles("*.gif") : null;
        //}


        public static FileInfo[] GetFeatureIconList()
        {
            string p = WebUtils.GetApplicationRoot() + "/Data/SiteImages/FeatureIcons";
            string filePath = HttpContext.Current.Server.MapPath(p);

            //HttpContext.Current.Request.PhysicalApplicationPath;


            DirectoryInfo dir = new DirectoryInfo(filePath);
            return dir.Exists ? dir.GetFiles("*.*") : null;
        }


        public static FileInfo[] GetFileIconList()
        {
            string p = WebUtils.GetApplicationRoot() + "/Data/SiteImages/Icons";
            string filePath = HttpContext.Current.Server.MapPath(p);

            DirectoryInfo dir = new DirectoryInfo(filePath);
            return dir.Exists ? dir.GetFiles("*.png") : null;
        }

        /// <summary>
        /// deprecated, better to just call IOHelper.GetMimeType
        /// </summary>
        /// <param name="fileExtension"></param>
        /// <returns></returns>
        public static string GetMimeType(string fileExtension)
        {
            return IOHelper.GetMimeType(fileExtension);
        }

        /// <summary>
        /// deprecated, better to just call IOHelper.IsNonAttacmentFileType
        /// </summary>
        /// <param name="fileExtension"></param>
        /// <returns></returns>
        public static bool IsNonAttacmentFileType(string fileExtension)
        {
            return IOHelper.IsNonAttacmentFileType(fileExtension);
        }

        //public static string GetSiteSystemFolder()
        //{
        //    if (HttpContext.Current == null) { return string.Empty; }
        //    SiteSettings siteSettings = CacheHelper.GetCurrentSiteSettings();
        //    if (siteSettings == null) { return string.Empty; }

        //    return HttpContext.Current.Server.MapPath("~/Data/Sites/" + siteSettings.SiteId.ToInvariantString() + "/systemfiles/");


        //}

        //public static DirectoryInfo[] GetSkinList(SiteSettings siteSettings)
        //{
        //    if (siteSettings == null) return null;

        //    string skinPath = HttpContext.Current.Server.MapPath
        //        ( WebUtils.GetApplicationRoot() + "/Data/Sites/" + siteSettings.SiteId.ToString(CultureInfo.InvariantCulture) + "/skins/");

        //    DirectoryInfo dir = new DirectoryInfo(skinPath);
        //    return dir.Exists ? dir.GetDirectories() : null;
        //}

        //public static FileInfo[] GetCodeTemplateList()
        //{
        //    string filePath = HttpContext.Current.Server.MapPath("~/DevAdmin/CodeTemplates");

        //    DirectoryInfo dir = new DirectoryInfo(filePath);
        //    return dir.Exists ? dir.GetFiles("*.aspx") : null;
        //}


        //public static SmtpSettings GetSmtpSettings()
        //{
        //    SmtpSettings smtpSettings = new SmtpSettings();

        //    if (WebConfigSettings.EnableSiteSettingsSmtpSettings)
        //    {
        //        SiteSettings siteSettings = CacheHelper.GetCurrentSiteSettings();
        //        if (siteSettings != null)
        //        {
        //            if (siteSettings.SMTPUser.Length > 0)
        //            {
        //                smtpSettings.User = CryptoHelper.Decrypt(siteSettings.SMTPUser);
        //            }

        //            if (siteSettings.SMTPPassword.Length > 0)
        //            {
        //                smtpSettings.Password = CryptoHelper.Decrypt(siteSettings.SMTPPassword);
        //            }

        //            smtpSettings.Server = siteSettings.SMTPServer;
        //            smtpSettings.Port = siteSettings.SMTPPort;
        //            smtpSettings.RequiresAuthentication = siteSettings.SMTPRequiresAuthentication;
        //            smtpSettings.UseSsl = siteSettings.SMTPUseSsl;
        //            smtpSettings.PreferredEncoding = siteSettings.SMTPPreferredEncoding;


        //        }

        //    }
        //    else
        //    {
        //        if (ConfigurationManager.AppSettings["SMTPUser"] != null)
        //        {
        //            smtpSettings.User = ConfigurationManager.AppSettings["SMTPUser"];
        //        }

        //        if (ConfigurationManager.AppSettings["SMTPPassword"] != null)
        //        {
        //            smtpSettings.Password = ConfigurationManager.AppSettings["SMTPPassword"];
        //        }
        //        if (ConfigurationManager.AppSettings["SMTPServer"] != null)
        //        {
        //            smtpSettings.Server = ConfigurationManager.AppSettings["SMTPServer"];
        //        }

        //        smtpSettings.Port = ConfigHelper.GetIntProperty("SMTPPort", 25);

        //        bool byPassContext = true;
        //        smtpSettings.RequiresAuthentication = ConfigHelper.GetBoolProperty("SMTPRequiresAuthentication", false, byPassContext); ;
        //        smtpSettings.UseSsl = ConfigHelper.GetBoolProperty("SMTPUseSsl", false, byPassContext);

        //        if (
        //       (ConfigurationManager.AppSettings["SmtpPreferredEncoding"] != null)
        //       && (ConfigurationManager.AppSettings["SmtpPreferredEncoding"].Length > 0)
        //       )
        //        {
        //            smtpSettings.PreferredEncoding = ConfigurationManager.AppSettings["SmtpPreferredEncoding"];
        //        }

        //    }

        //    return smtpSettings;
        //}

        ///// <summary>
        ///// deprecated, you should pass in the Page
        ///// </summary>
        ///// <returns></returns>
        //public static string GetSkinBaseUrl()
        //{
        //    return GetSkinBaseUrl(null);
        //}

        //public static string GetSkinBaseUrl(Page page)
        //{
        //    bool allowPageOverride = true;
        //    return GetSkinBaseUrl(allowPageOverride, page);
        //}


        //public static string GetSkinBaseUrl(bool allowPageOverride, Page page)
        //{
        //    if (allowPageOverride) return GetSkinBaseUrlWithOverride(page);

        //    return GetSkinBaseUrlNoOverride(page);
        //}

        //private static string GetSkinBaseUrlNoOverride(Page page)
        //{
        //    if (HttpContext.Current == null) return String.Empty;

        //    string baseUrl = HttpContext.Current.Items["skinBaseUrlfalse"] as string;
        //    if (baseUrl == null)
        //    {
        //        baseUrl = DetermineSkinBaseUrl(false, page);
        //        if (baseUrl != null)
        //            HttpContext.Current.Items["skinBaseUrlfalse"] = baseUrl;
        //    }
        //    return baseUrl;


        //}

        //private static string GetSkinBaseUrlWithOverride(Page page)
        //{
        //    if (HttpContext.Current == null) return String.Empty;

        //    string baseUrl = HttpContext.Current.Items["skinBaseUrltrue"] as string;
        //    if (baseUrl == null)
        //    {
        //        baseUrl = DetermineSkinBaseUrl(true, page);
        //        if (baseUrl != null)
        //            HttpContext.Current.Items["skinBaseUrltrue"] = baseUrl;
        //    }
        //    return baseUrl;


        //}

        //private static string DetermineSkinBaseUrl(bool allowPageOverride, Page page)
        //{
        //    bool fullUrl = true;

        //    return DetermineSkinBaseUrl(allowPageOverride, fullUrl, page);


        //}

        //public static string DetermineSkinBaseUrl(string skinName)
        //{
        //    if (string.IsNullOrEmpty(skinName)) { return  WebUtils.GetSiteRoot() + "/Data/Skins/styleshout-refresh/"; }

        //    SiteSettings siteSettings = CacheHelper.GetCurrentSiteSettings();
        //    if (siteSettings == null) { return  WebUtils.GetSiteRoot() + "/Data/Skins/styleshout-refresh/"; }


        //    string skinUrl =  WebUtils.GetSiteRoot() + "/Data/Sites/"
        //            + siteSettings.SiteId.ToInvariantString()
        //            + "/skins/" + skinName + "/";

        //    return skinUrl;

        //}

        //public static string DetermineSkinBaseUrl(bool allowPageOverride, bool fullUrl, Page page)
        //{
        //    string skinFolder;
        //    string siteRoot = string.Empty;

        //    if (fullUrl)
        //    {
        //        siteRoot =  WebUtils.GetSiteRoot();
        //        skinFolder = siteRoot + "/Data/Sites/1/skins/";
        //    }
        //    else
        //    {
        //        siteRoot =  WebUtils.GetRelativeSiteRoot();
        //        skinFolder = "/Data/Sites/1/skins/";
        //    }

        //    string currentSkin = "styleshout-refresh/";

        //    SiteSettings siteSettings = CacheHelper.GetCurrentSiteSettings();
        //    PageSettings currentPage = CacheHelper.GetCurrentPage();

        //    if (siteSettings != null)
        //    {
        //        currentSkin = siteSettings.Skin + "/";

        //        if (siteSettings.AllowUserSkins)
        //        {
        //            string skinCookieName = "mojoUserSkin" + siteSettings.SiteId.ToInvariantString();
        //            if (CookieHelper.CookieExists(skinCookieName))
        //            {
        //                string cookieValue = CookieHelper.GetCookieValue(skinCookieName);
        //                if (cookieValue.Length > 0)
        //                {
        //                    currentSkin = cookieValue + "/";
        //                }
        //            }
        //        }

        //        if (
        //            (allowPageOverride)
        //            && (currentPage != null)
        //            && (siteSettings.AllowPageSkins)
        //            && ((page != null)
        //                && (!(page is NonCmsBasePage))
        //               )
        //            )
        //        {
        //            if (currentPage.Skin.Length > 0)
        //            {
        //                currentSkin = currentPage.Skin + "/";

        //            }
        //        }

        //        skinFolder = siteRoot + "/Data/Sites/"
        //            + siteSettings.SiteId.ToInvariantString() + "/skins/";


        //        if (HttpContext.Current.Request.Params.Get("skin") != null)
        //        {
        //            currentSkin = SanitizeSkinParam(HttpContext.Current.Request.Params.Get("skin")) + "/";
        //        }
        //    }

        //    return skinFolder + currentSkin;
        //}

        //public static int ParseSiteIdFromSkinRequestUrl()
        //{
        //    int siteId = -1;

        //    if (HttpContext.Current == null) { return siteId; }
        //    if (HttpContext.Current.Request == null) { return siteId; }

        //    if (
        //        (HttpContext.Current.Request.RawUrl.IndexOf("Data/Sites/") == -1)
        //        || (HttpContext.Current.Request.RawUrl.IndexOf("/skins/") == -1)
        //        )
        //    {
        //        SiteSettings siteSettings = CacheHelper.GetCurrentSiteSettings();
        //        if (siteSettings != null) { return siteSettings.SiteId; }

        //    }

        //    string tagged = HttpContext.Current.Request.RawUrl.Replace("/Sites/", "|").Replace("/skins/", "|");
        //    try
        //    {
        //        string strId = tagged.Substring(tagged.IndexOf("|") + 1, tagged.LastIndexOf("|") - tagged.IndexOf("|") - 1);

        //        //log.Info("Parsing siteId to " + strId);

        //        int.TryParse(strId, NumberStyles.Integer, CultureInfo.InvariantCulture, out siteId);
        //    }
        //    catch (ArgumentOutOfRangeException)
        //    {
        //        log.Error("Could not parse siteid from skin url so using SiteSettings.");
        //        SiteSettings siteSettings = CacheHelper.GetCurrentSiteSettings();
        //        if (siteSettings != null) { return siteSettings.SiteId; }

        //    }

        //    return siteId;


        //}

        //public static string GetCssHandlerBaseUrl(string skinName)
        //{
        //    if (string.IsNullOrEmpty(skinName)) { return GetCssHandlerBaseUrl(false); }

        //    SiteSettings siteSettings = CacheHelper.GetCurrentSiteSettings();
        //    if (siteSettings == null) { return GetNavigationSiteRoot() + "/Data/Skins/styleshout-refresh/"; }


        //    string skinUrl = GetNavigationSiteRoot() + "/Data/Sites/"
        //            + siteSettings.SiteId.ToString(CultureInfo.InvariantCulture)
        //            + "/skins/" + skinName + "/";

        //    return skinUrl;

        //}

        //public static string GetCssHandlerBaseUrl(bool allowPageOverride)
        //{
        //    string skinFolder;
        //    string siteRoot = string.Empty;


        //    siteRoot = GetNavigationSiteRoot();
        //    skinFolder = siteRoot + "/Data/Sites/1/skins/";

        //    string currentSkin = "styleshout-refresh/";

        //    SiteSettings siteSettings = CacheHelper.GetCurrentSiteSettings();
        //    PageSettings currentPage = CacheHelper.GetCurrentPage();

        //    if (siteSettings != null)
        //    {
        //        currentSkin = siteSettings.Skin + "/";

        //        if (siteSettings.AllowUserSkins)
        //        {
        //            string skinCookieName = "mojoUserSkin" + siteSettings.SiteId.ToString(CultureInfo.InvariantCulture);
        //            if (CookieHelper.CookieExists(skinCookieName))
        //            {
        //                string cookieValue = CookieHelper.GetCookieValue(skinCookieName);
        //                if (cookieValue.Length > 0)
        //                {
        //                    currentSkin = cookieValue + "/";
        //                }
        //            }
        //        }

        //        if (
        //            (allowPageOverride)
        //            && (currentPage != null)
        //            && (siteSettings.AllowPageSkins)
        //            && (IsContentPage())
        //            )
        //        {
        //            if (currentPage.Skin.Length > 0)
        //            {
        //                currentSkin = currentPage.Skin + "/";

        //            }
        //        }

        //        skinFolder = siteRoot + "/Data/Sites/"
        //            + siteSettings.SiteId.ToString(CultureInfo.InvariantCulture) + "/skins/";


        //        if (HttpContext.Current.Request.Params.Get("skin") != null)
        //        {
        //            currentSkin = SanitizeSkinParam(HttpContext.Current.Request.Params.Get("skin")) + "/";
        //        }
        //    }

        //    return skinFolder + currentSkin;
        //}

        //public static string GetSkinName(bool allowPageOverride, Page page)
        //{

        //    string currentSkin = "styleshout-refresh";

        //    SiteSettings siteSettings = CacheHelper.GetCurrentSiteSettings();
        //    PageSettings currentPage = CacheHelper.GetCurrentPage();

        //    if (siteSettings != null)
        //    {
        //        currentSkin = siteSettings.Skin;

        //        if (siteSettings.AllowUserSkins)
        //        {
        //            string skinCookieName = "mojoUserSkin" + siteSettings.SiteId.ToString(CultureInfo.InvariantCulture);
        //            if (CookieHelper.CookieExists(skinCookieName))
        //            {
        //                string cookieValue = CookieHelper.GetCookieValue(skinCookieName);
        //                if (cookieValue.Length > 0)
        //                {
        //                    currentSkin = cookieValue;
        //                }
        //            }
        //        }

        //        if (
        //            (allowPageOverride)
        //            && (currentPage != null)
        //            && (siteSettings.AllowPageSkins)
        //             && ((page != null) && (!(page is NonCmsBasePage)))
        //            )
        //        {
        //            if (currentPage.Skin.Length > 0)
        //            {
        //                currentSkin = currentPage.Skin;

        //            }
        //        }

        //        if (HttpContext.Current.Request.Params.Get("skin") != null)
        //        {
        //            currentSkin = SanitizeSkinParam(HttpContext.Current.Request.Params.Get("skin"));
        //        }

        //    }

        //    return currentSkin;
        //}

        //public static string GetStyleSheetLinks(bool allowPageOverride)
        //{
        //    string styleLinks;
        //    string baseSkinUrl = SiteUtils.GetSkinBaseUrl(allowPageOverride);

        //    if (WebConfigSettings.IncludeTextSizeCss)
        //    {
        //        styleLinks
        //            = "\n<link href='" + baseSkinUrl
        //            + "style.css' type='text/css' rel='stylesheet' />"
        //            + "\n<link href='" + baseSkinUrl
        //            + "styletext.css' type='text/css' rel='stylesheet' title='"
        //            + Resource.NormalTextLabel + "' />"
        //            + "\n<link href='" + baseSkinUrl
        //            + "styletextmedium.css' type='text/css' rel='alternate stylesheet' title='"
        //            + Resource.MediumTextLabel + "' />"
        //            + "\n<link href='" + baseSkinUrl
        //            + "styletextlarge.css' type='text/css' rel='alternate stylesheet' title='"
        //            + Resource.LargeTextLabel + "' />"
        //            + "\n<link href='" + baseSkinUrl
        //            + "styleprinter.css' type='text/css' rel='stylesheet' media='print' />";
        //    }
        //    else
        //    {
        //        styleLinks
        //            = "\n<link href='" + baseSkinUrl
        //            + "style.css' type='text/css' rel='stylesheet' />"
        //            + "\n<link href='" + baseSkinUrl
        //            + "styletext.css' type='text/css' rel='stylesheet' title='"
        //            + Resource.NormalTextLabel + "' />"
        //            + "\n<link href='" + baseSkinUrl
        //            + "styleprinter.css' type='text/css' rel='stylesheet' media='print' />";
        //    }

        //    return styleLinks;

        //}


        //public static string GetStyleSheetUrl(Page page)
        //{
        //    bool allowPageOverride = false;
        //    string cssUrl = SiteUtils.GetSkinBaseUrl(allowPageOverride, page)
        //    + "csshandler.ashx?skin=" + SiteUtils.GetSkinName(allowPageOverride, page)
        //            + "&amp;config=style.config";

        //    return cssUrl;
        //}

        public static string ChangeRelativeUrlsToFullyQuailifiedUrls(string navigationSiteRoot, string imageSiteRoot, string htmlContent)
        {
            if (string.IsNullOrEmpty(htmlContent))
            {
                return htmlContent;
            }
            if (string.IsNullOrEmpty(navigationSiteRoot))
            {
                return htmlContent;
            }
            if (string.IsNullOrEmpty(imageSiteRoot))
            {
                return htmlContent;
            }

            return htmlContent.Replace("href=\"/", "href=\"" + navigationSiteRoot + "/").Replace("href='/", "href='" + navigationSiteRoot + "/").Replace("src=\"/", "src=\"" + imageSiteRoot + "/").Replace("src='/", "src='" + imageSiteRoot + "/");
        }

        //public static string GetRegexRelativeImageUrlPatern()
        //{
        //    return "^" +  WebUtils.GetSiteRoot() + @"/.*[_a-zA-Z0-9]+\.(png|jpg|jpeg|gif|PNG|JPG|JPEG|GIF)$";
        //}


        public static string GetNavigationSiteRoot()
        {
            if (HttpContext.Current == null)
                return string.Empty;

            if (HttpContext.Current.Items["navigationRoot"] != null)
            {
                return HttpContext.Current.Items["navigationRoot"].ToString();
            }

            string navigationRoot = WebUtils.GetSiteRoot();

            HttpContext.Current.Items["navigationRoot"] = navigationRoot;

            return navigationRoot;
        }

        public static string GetRelativeNavigationSiteRoot()
        {
            if (HttpContext.Current == null)
                return string.Empty;

            if (HttpContext.Current.Items["relativenavigationRoot"] != null)
            {
                return HttpContext.Current.Items["relativenavigationRoot"].ToString();
            }

            string navigationRoot = WebUtils.GetRelativeSiteRoot();
            //bool useFolderForSiteDetection = ConfigHelper.GetBoolProperty("UseFoldersInsteadOfHostnamesForMultipleSites", false);

            //if (useFolderForSiteDetection)
            //{
            //    SiteSettings siteSettings = CacheHelper.GetCurrentSiteSettings();

            //    if ((siteSettings != null)
            //        && (siteSettings.SiteFolderName.Length > 0))
            //    {
            //        navigationRoot = siteSettings.SiteRoot;
            //    }
            //}

            HttpContext.Current.Items["relativenavigationRoot"] = navigationRoot;

            return navigationRoot;
        }

        //public static string GetInsecureNavigationSiteRoot()
        //{
        //    return GetNavigationSiteRoot().Replace("https", "http");
        //}

        public static string GetSecureNavigationSiteRoot()
        {
            if (HttpContext.Current == null)
                return string.Empty;

            if (HttpContext.Current.Items["securenavigationRoot"] != null)
            {
                return HttpContext.Current.Items["securenavigationRoot"].ToString();
            }

            string navigationRoot = WebUtils.GetSecureSiteRoot();
            //bool useFolderForSiteDetection = ConfigHelper.GetBoolProperty("UseFoldersInsteadOfHostnamesForMultipleSites", false);

            //if (useFolderForSiteDetection)
            //{
            //    SiteSettings siteSettings = CacheHelper.GetCurrentSiteSettings();

            //    if ((siteSettings != null)
            //        && (siteSettings.SiteFolderName.Length > 0))
            //    {
            //        navigationRoot = navigationRoot + "/" + siteSettings.SiteFolderName;
            //    }
            //}

            HttpContext.Current.Items["securenavigationRoot"] = navigationRoot;

            return navigationRoot;
        }

        //public static string GetCurrentPageUrl()
        //{
        //    PageSettings currentPage = CacheHelper.GetCurrentPage();
        //    return GetPageUrl(currentPage);

        //}

        //private static string PageTitleFormatName()
        //{
        //    if (HttpContext.Current == null) { return string.Empty; }

        //    if (HttpContext.Current.Items["PageTitleFormatName"] != null)
        //    {
        //        return HttpContext.Current.Items["PageTitleFormatName"].ToString();
        //    }

        //    HttpContext.Current.Items["PageTitleFormatName"] = WebConfigSettings.PageTitleFormatName;

        //    return HttpContext.Current.Items["PageTitleFormatName"].ToString();

        //}

        //private static string PageTitleSeparatorString()
        //{
        //    if (HttpContext.Current == null) { return string.Empty; }

        //    if (HttpContext.Current.Items["PageTitleSeparatorString"] != null)
        //    {
        //        return HttpContext.Current.Items["PageTitleSeparatorString"].ToString();
        //    }

        //    HttpContext.Current.Items["PageTitleSeparatorString"] = WebConfigSettings.PageTitleSeparatorString;

        //    return HttpContext.Current.Items["PageTitleSeparatorString"].ToString();

        //}

        //public const string TitleFormat_TitleOnly = "TitleOnly";
        //public const string TitleFormat_SitePlusTitle = "SitePlusTitle";
        //public const string TitleFormat_TitlePlusSite = "TitlePlusSite";

        //public static string FormatPageTitle(SiteSettings siteSettings, string topicTitle)
        //{
        //    if (siteSettings == null) { return topicTitle; }

        //    string pageTitle;
        //    switch (PageTitleFormatName())
        //    {
        //        case TitleFormat_TitleOnly:
        //            pageTitle = topicTitle;
        //            break;
        //        case TitleFormat_TitlePlusSite:
        //            pageTitle = topicTitle + PageTitleSeparatorString() + siteSettings.SiteName;
        //            break;
        //        case TitleFormat_SitePlusTitle:
        //        default:
        //            pageTitle = siteSettings.SiteName + PageTitleSeparatorString() + topicTitle;
        //            break;
        //    }

        //    if ((pageTitle.Length > 65) && (WebConfigSettings.AutoTruncatePageTitles))
        //    {
        //        pageTitle = UIHelper.CreateExcerpt(pageTitle, 65);
        //    }

        //    return pageTitle;

        //}

        //public static string GetPageUrl(PageSettings pageSettings)
        //{
        //    string navigationRoot = string.Empty;
        //    bool useFolderForSiteDetection = ConfigHelper.GetBoolProperty("UseFoldersInsteadOfHostnamesForMultipleSites", false);

        //    SiteSettings siteSettings = CacheHelper.GetCurrentSiteSettings();
        //    if (
        //        (siteSettings == null)
        //        || (pageSettings == null)
        //        || (pageSettings.PageId == -1)
        //        || (pageSettings.SiteId != siteSettings.SiteId)
        //        )
        //    {
        //        navigationRoot =  WebUtils.GetSiteRoot();
        //        return navigationRoot;
        //    }

        //    if (pageSettings.Url.StartsWith("http")) return pageSettings.Url;

        //    string resolvedUrl;

        //    if (pageSettings.UseUrl)
        //    {

        //        if ((pageSettings.Url.StartsWith("~/")) && (pageSettings.Url.EndsWith(".aspx")))
        //        {
        //            if (pageSettings.UrlHasBeenAdjustedForFolderSites)
        //            {
        //                resolvedUrl = pageSettings.Url.Replace("~/", "/");
        //            }
        //            else
        //            {
        //                resolvedUrl = siteSettings.SiteRoot
        //                    + pageSettings.Url.Replace("~/", "/");
        //            }

        //        }
        //        else
        //        {
        //            resolvedUrl = pageSettings.Url;
        //        }

        //    }
        //    else
        //    {
        //        resolvedUrl = siteSettings.SiteRoot
        //            + "/Default.aspx?pageid="
        //            + pageSettings.PageId.ToString(CultureInfo.InvariantCulture);

        //    }



        //    return resolvedUrl;

        //}

        //public static string GetFileAttachmentUploadPath()
        //{
        //    if (HttpContext.Current == null) { return string.Empty; }

        //    SiteSettings siteSettings = CacheHelper.GetCurrentSiteSettings();

        //    if (siteSettings == null) { return string.Empty; }

        //    return HttpContext.Current.Server.MapPath( WebUtils.GetApplicationRoot() + "/Data/Sites/"
        //        + siteSettings.SiteId.ToString(CultureInfo.InvariantCulture) + "/Attachments/");

        //}

        //public static void EnsureFileAttachmentFolder(SiteSettings siteSettings)
        //{
        //    if (siteSettings == null) { return; }
        //    if (HttpContext.Current == null) { return; }

        //    string filePath = HttpContext.Current.Server.MapPath( WebUtils.GetApplicationRoot() + "/Data/Sites/"
        //        + siteSettings.SiteId.ToString(CultureInfo.InvariantCulture) + "/Attachments/");

        //    if (!Directory.Exists(filePath))
        //    {
        //        try
        //        {
        //            Directory.CreateDirectory(filePath);
        //        }
        //        catch (IOException ex)
        //        {
        //            log.Error("failed to create path for file attachments " + filePath + " ", ex);
        //        }
        //    }

        //}

        public static bool SslIsAvailable()
        {
            if (WebConfigSettings.SslisAvailable)
            {
                return true;
            }

            //SiteSettings siteSettings = CacheHelper.GetCurrentSiteSettings();
            //if (siteSettings == null) { return false; }

            string key = "Site" + GetSiteId() + "-SSLIsAvailable";
            if (ConfigurationManager.AppSettings[key] != null)
            {
                return ConfigHelper.GetBoolProperty(key, false);
            }

            return false;
        }

        public static void ForceSsl()
        {
            if (WebConfigSettings.UseFoldersInsteadOfHostnamesForMultipleSites)
            {
                bool proxyPreventsSSLDetection;
                bool.TryParse(ConfigurationManager.AppSettings["ProxyPreventsSSLDetection"], out proxyPreventsSSLDetection);
                // proxyPreventsSSLDetection is false if parsing failed for any reason

                if (!proxyPreventsSSLDetection)
                {
                    string pageUrl = HttpContext.Current.Request.Url.ToString();
                    if (pageUrl.StartsWith("http:"))
                    {
                        string secureUrl = WebUtils.GetSecureSiteRoot()
                        + HttpContext.Current.Request.RawUrl;

                        HttpContext.Current.Response.Redirect(secureUrl, true);
                    }
                }
            }
            else
            {
                //if (!WebConfigSettings.EnableSslInChildSites)
                //{
                //    SiteSettings siteSettings = CacheHelper.GetCurrentSiteSettings();
                //    if (!siteSettings.IsServerAdminSite) return;

                //}
                WebUtils.ForceSsl();
            }
        }

        public static void ClearSsl()
        {
            //if (WebConfigSettings.UseFoldersInsteadOfHostnamesForMultipleSites)
            //{
            string pageUrl = HttpContext.Current.Request.Url.ToString();
            if (pageUrl.StartsWith("https:"))
            {
                string insecureUrl = WebUtils.GetInSecureSiteRoot()
                + HttpContext.Current.Request.RawUrl;

                HttpContext.Current.Response.Redirect(insecureUrl, true);
            }
            //}
            //else
            //{

            //     WebUtils.ClearSsl();
            //}
        }



        //public static string GetEditorProviderName()
        //{
        //    string providerName = "FCKeditorProvider";

        //    SiteSettings siteSettings = CacheHelper.GetCurrentSiteSettings();
        //    if (siteSettings != null)
        //    {
        //        providerName = siteSettings.EditorProviderName;
        //    }


        //    if (HttpContext.Current != null)
        //    {
        //        string loweredBrowser = HttpContext.Current.Request.Browser.Browser.ToLower();
        //        // FCKeditor doesn't work in safari or opera
        //        // so just force TinyMCE
        //        if (
        //            (loweredBrowser.Contains("safari"))
        //            && (WebConfigSettings.ForceTinyMCEInSafari)
        //            )
        //        {
        //            providerName = "TinyMCEProvider";
        //        }

        //        if (
        //            (loweredBrowser.Contains("opera"))
        //            && (WebConfigSettings.ForceTinyMCEInOpera)
        //            )
        //        {
        //            providerName = "TinyMCEProvider";
        //        }

        //    }

        //    //TODO: could have user preferences

        //    return providerName;
        //}

        //public static void SetCurrentSkinBaseUrl(SiteSettings siteSettings)
        //{
        //    string siteRoot =  WebUtils.GetSiteRoot();
        //    string skinFolder = siteRoot + "/Data/Sites/1/skins/";
        //    string currentSkin = "jwv1/";


        //    if (siteSettings != null)
        //    {
        //        currentSkin = siteSettings.Skin + "/";

        //        if (siteSettings.AllowUserSkins)
        //        {
        //            string skinCookieName = "mojoUserSkin" + siteSettings.SiteId.ToString(CultureInfo.InvariantCulture);

        //            if (CookieHelper.CookieExists(skinCookieName))
        //            {
        //                string cookieValue = CookieHelper.GetCookieValue(skinCookieName);
        //                if (cookieValue.Length > 0)
        //                {
        //                    currentSkin = cookieValue + "/";
        //                }
        //            }
        //        }

        //        //if (siteSettings.AllowPageSkins)
        //        //{
        //        //    if (siteSettings.ActivePage.Skin.Length > 0)
        //        //    {
        //        //        currentSkin = siteSettings.ActivePage.Skin + "/";

        //        //    }
        //        //}

        //        skinFolder = siteRoot + "/Data/Sites/"
        //            + siteSettings.SiteId.ToString(CultureInfo.InvariantCulture) + "/skins/";


        //        //if (HttpContext.Current.Request.Params.Get("skin") != null)
        //        //{
        //        //    currentSkin = HttpContext.Current.Request.Params.Get("skin") + "/";

        //        //}

        //        siteSettings.SkinBaseUrl = skinFolder + currentSkin;
        //    }


        //}


        #region Url Rewrite tracking

        //public static void TrackUrlRewrite()
        //{
        //    if (HttpContext.Current == null) return;

        //    HttpContext.Current.Items["urlwasrewritten"] = true;

        //}

        //public static bool UrlWasReWritten()
        //{
        //    if (HttpContext.Current.Items["urlwasrewritten"] != null)
        //    {
        //        return true;
        //    }

        //    return false;

        //}


        #endregion


        //public static string GetRoleCookieName()
        //{
        //    SiteSettings siteSettings = CacheHelper.GetCurrentSiteSettings();
        //    return GetRoleCookieName(siteSettings);
        //}

        public static string GetRoleCookieName()
        {
            String hostName = WebUtils.GetHostName();
            //if (WebConfigSettings.UseRelatedSiteMode)
            //{
            //    return hostName + "portalroles";
            //}


            return hostName + "portalroles" + GetSiteId();
        }

        //public static void RedirectToSignOut()
        //{
        //    if (HttpContext.Current == null) { return; }
        //    if (HttpContext.Current.Request == null) { return; }

        //    HttpContext.Current.Response.Clear();
        //    HttpContext.Current.Response.Redirect(SiteUtils.GetNavigationSiteRoot() + "/Logoff.aspx", true);

        //}

        #region Current User

        //public static Guid GetCurrentUserId()
        //{
        //    bool bypassAuthCheck = false;

        //    SiteUser currentUser = GetCurrentUser(bypassAuthCheck);

        //    if ((currentUser != null) && (currentUser.IsLockedOut))
        //    {
        //        RedirectToSignOut();
        //        return Guid.Empty;
        //    }

        //    return currentUser.UserId;
        //}

        public static SiteUser GetCurrentUser()
        {
            bool bypassAuthCheck = false;

            SiteUser currentUser = GetCurrentUser(bypassAuthCheck);

            if ((currentUser != null) && (currentUser.IsLockedOut))
            {
                RedirectToSignOut();
                return null;
            }

            return currentUser;
        }

        public static SiteUser GetCurrentUser(bool bypassAuthCheck)
        {
            if (HttpContext.Current == null)
                return null;


            if (bypassAuthCheck || (HttpContext.Current.Request.IsAuthenticated))
            {
                if (HttpContext.Current.Items["CurrentUser"] != null)
                {
                    try
                    {
                        return (SiteUser)HttpContext.Current.Items["CurrentUser"];
                    }
                    catch
                    {
                    }
                }
                IUserBAL itemBAl = new UserBAL();
                User item = itemBAl.GetUserByLoginName(HttpContext.Current.User.Identity.Name.Trim());
                SiteUser siteUser = new SiteUser();
                siteUser.UserId = item.UserGuid;
                siteUser.Name = item.UserName;
                siteUser.LoginName = item.UserID;

                if (siteUser.UserId != Guid.Empty)
                {
                    HttpContext.Current.Items["CurrentUser"] = siteUser.ToString();

                    return siteUser;
                }
            }

            return null;
        }

        //public static string SuggestLoginNameFromEmail(string email)
        //{
        //    string login = email.Substring(0, email.IndexOf("@"));
        //    int offset = 1;
        //    while (SiteUser.LoginExistsInDB(login))
        //    {
        //        login = login + offset.ToInvariantString();
        //        offset += 1;
        //    }

        //    return login;
        //}

        //public static User CreateMinimalUser(string email, bool includeInMemberList, string adminComments)
        //{
        //    if (string.IsNullOrEmpty(email))
        //    {
        //        throw new ArgumentException("a valid email address is required for this method");
        //    }

        //    if (!Email.IsValidEmailAddressSyntax(email))
        //    {
        //        throw new ArgumentException("a valid email address is required for this method");
        //    }

        //    //first make sure he doesn't exist
        //    User siteUser = User.g.GetByEmail(email);
        //    if ((siteUser != null) && (siteUser.UserGuid != Guid.Empty)) { return siteUser; }

        //    siteUser = new SiteUser(siteSettings);
        //    siteUser.Email = email;
        //    string login = SuggestLoginNameFromEmail(siteSettings.SiteId, email);
        //    //int offset = 1;
        //    //while (SiteUser.LoginExistsInDB(siteSettings.SiteId, login))
        //    //{
        //    //    login = login + offset.ToString(CultureInfo.InvariantCulture);
        //    //    offset += 1;
        //    //}

        //    siteUser.LoginName = login;
        //    siteUser.Name = login;
        //    siteUser.Password = SiteUser.CreateRandomPassword(siteSettings.MinRequiredPasswordLength + 2, WebConfigSettings.PasswordGeneratorChars);
        //    mojoMembershipProvider m = Membership.Provider as mojoMembershipProvider;
        //    if (m != null)
        //    {
        //        siteUser.Password = m.EncodePassword(siteUser.Password, siteSettings);
        //    }

        //    siteUser.ProfileApproved = true;
        //    siteUser.DisplayInMemberList = includeInMemberList;
        //    siteUser.PasswordQuestion = Resource.ManageUsersDefaultSecurityQuestion;
        //    siteUser.PasswordAnswer = Resource.ManageUsersDefaultSecurityAnswer;

        //    if (!string.IsNullOrEmpty(adminComments)) { siteUser.Comment = adminComments; }

        //    siteUser.Save();

        //    Role.AddUserToDefaultRoles(siteUser);

        //    return siteUser;

        //}



        //public static bool UserIsSiteEditor()
        //{
        //    SiteSettings siteSettings = CacheHelper.GetCurrentSiteSettings();
        //    if (siteSettings != null)
        //    {
        //        return (WebConfigSettings.UseRelatedSiteMode) && (WebUser.IsInRoles(siteSettings.SiteRootEditRoles));
        //    }

        //    return false;
        //}

        //public static bool UserCanEditModule(int moduleId)
        //{
        //    if (HttpContext.Current == null) return false;
        //    if (!HttpContext.Current.Request.IsAuthenticated) return false;

        //    if (WebUser.IsAdminOrContentAdmin) return true;

        //    PageSettings currentPage = CacheHelper.GetCurrentPage();
        //    if (currentPage == null) return false;

        //    bool moduleFoundOnPage = false;
        //    foreach (Module m in currentPage.Modules)
        //    {
        //        if (m.ModuleId == moduleId) moduleFoundOnPage = true;
        //    }

        //    if (!moduleFoundOnPage) return false;

        //    if (WebUser.IsInRoles(currentPage.EditRoles)) return true;

        //    SiteUser currentUser = SiteUtils.GetCurrentUser();
        //    if (currentUser == null) return false;

        //    foreach (Module m in currentPage.Modules)
        //    {
        //        if (m.ModuleId == moduleId)
        //        {
        //            if (m.EditUserId == currentUser.UserId) return true;
        //            if (WebUser.IsInRoles(m.AuthorizedEditRoles)) return true;
        //        }
        //    }

        //    return false;

        //}


        public static void TrackUserActivity()
        {
            if (HttpContext.Current == null)
                return;
            if (HttpContext.Current.Request == null)
                return;



            if (
            (HttpContext.Current.User.Identity.IsAuthenticated)
                //&& (WebConfigSettings.TrackAuthenticatedRequests)
            )
            {
                if (
                (HttpContext.Current.Request.Path.EndsWith(".gif", StringComparison.InvariantCultureIgnoreCase))
                || (HttpContext.Current.Request.Path.EndsWith(".js", StringComparison.InvariantCultureIgnoreCase))
                || (HttpContext.Current.Request.Path.EndsWith(".jpg", StringComparison.InvariantCultureIgnoreCase))
                || (HttpContext.Current.Request.Path.EndsWith(".png", StringComparison.InvariantCultureIgnoreCase))
                || (HttpContext.Current.Request.Path.EndsWith(".gif", StringComparison.InvariantCultureIgnoreCase))
                || (HttpContext.Current.Request.Path.EndsWith(".css", StringComparison.InvariantCultureIgnoreCase))
                || (HttpContext.Current.Request.Path.EndsWith(".axd", StringComparison.InvariantCultureIgnoreCase))
                || (HttpContext.Current.Request.Path.EndsWith("upgrade.aspx", StringComparison.InvariantCultureIgnoreCase))
                || (HttpContext.Current.Request.Path.EndsWith("setup/default.aspx", StringComparison.InvariantCultureIgnoreCase))
                )
                {
                    return;
                }

                //SiteSettings siteSettings = CacheHelper.GetCurrentSiteSettings();
                //if (siteSettings != null)
                //{
                bool bypassAuthCheck = false;
                SiteUser siteUser = GetCurrentUser(bypassAuthCheck);
                //SiteUser siteUser = new SiteUser(siteSettings, HttpContext.Current.User.Identity.Name);
                if ((siteUser != null) && (siteUser.UserId != Guid.Empty))
                {
                    //siteUser.UpdateLastActivityTime(); ! bổ sung sau

                    if (HttpContext.Current.Request == null)
                        return;

                    //if (WebConfigSettings.TrackIPForAuthenticatedRequests)
                    //{
                    //    SiteSettings siteSettings = CacheHelper.GetCurrentSiteSettings();
                    //    if (siteSettings == null) return;

                    //    // track user ip address
                    //    UserLocation userLocation = new UserLocation(
                    //        siteUser.UserGuid,
                    //        GetIP4Address());

                    //    userLocation.SiteGuid = siteSettings.SiteGuid;
                    //    userLocation.Hostname = HttpContext.Current.Request.UserHostName;
                    //    userLocation.Save();


                    //}
                }
                //}
            }
        }


        #endregion

        //public static void QueueIndexing()
        //{
        //    if (!WebConfigSettings.IsSearchIndexingNode) { return; }

        //    if (IndexWriterTask.IsRunning()) { return; }

        //    IndexWriterTask indexWriter = new IndexWriterTask();

        //    indexWriter.StoreContentForResultsHighlighting = WebConfigSettings.EnableSearchResultsHighlighting;

        //    // Commented out 2009-01-24
        //    // seems to cause errors for some languages if we localize this
        //    // perhaps because the background thread is not running on the same culture as the
        //    // web ui which is driven by browser language preferecne.
        //    // if we do localize it we should localize to the site default culture, not the user's
        //    //indexWriter.TaskName = Resource.IndexWriterTaskName;
        //    //indexWriter.StatusCompleteMessage = Resource.IndexWriterTaskCompleteMessage;
        //    //indexWriter.StatusQueuedMessage = Resource.IndexWriterTaskQueuedMessage;
        //    //indexWriter.StatusStartedMessage = Resource.IndexWriterTaskStartedMessage;
        //    //indexWriter.StatusRunningMessage = Resource.IndexWriterTaskRunningFormatString;

        //    indexWriter.QueueTask();

        //    WebTaskManager.StartOrResumeTasks();

        //}

        //public static String GetFullPathToThemeFile()
        //{
        //    string pathToFile = null;

        //    if (HttpContext.Current != null)
        //    {
        //        SiteSettings siteSettings = CacheHelper.GetCurrentSiteSettings();
        //        pathToFile = HttpContext.Current.Server.MapPath(
        //            "~/Data/Sites/" + siteSettings.SiteId.ToString(CultureInfo.InvariantCulture) + "/skins/"
        //            + siteSettings.Skin + "/theme.skin");

        //    }

        //    return pathToFile;
        //}


        //public static int GetCurrentPageDepth(SiteMapNode rootNode)
        //{

        //    PageSettings pageSettings = CacheHelper.GetCurrentPage();
        //    if ((pageSettings == null)
        //        || (pageSettings.ParentId == -1)
        //        )
        //    {
        //        return 0;
        //    }

        //    SiteMapNode currentPageNode = GetSiteMapNodeForPage(rootNode, pageSettings);
        //    if (currentPageNode == null) { return 0; }

        //    if (!(currentPageNode is hhtSiteMapNode)) { return 0; }

        //    hhtSiteMapNode node = currentPageNode as hhtSiteMapNode;
        //    return node.Depth;


        //}

        //public static String GetActivePageValuePath(SiteMapNode rootNode, int offSet)
        //{
        //    String valuePath = String.Empty;

        //    PageSettings pageSettings = CacheHelper.GetCurrentPage();

        //    SiteMapNode currentPageNode = GetSiteMapNodeForPage(rootNode, pageSettings);
        //    if (currentPageNode == null) { return string.Empty; }

        //    if (!(currentPageNode is hhtSiteMapNode)) { return string.Empty; }

        //    hhtSiteMapNode node = currentPageNode as hhtSiteMapNode;


        //    valuePath = node.PageGuid.ToString();

        //    while ((node != null) && (node.ParentId > -1))
        //    {
        //        if (node.ParentNode != null)
        //        {
        //            node = node.ParentNode as hhtSiteMapNode;

        //            valuePath = node.PageGuid.ToString() + "|" + valuePath;
        //        }

        //    }


        //    if (offSet > 0)
        //    {
        //        for (int i = 1; i <= offSet; i++)
        //        {
        //            if (valuePath.IndexOf("|") > -1)
        //            {
        //                valuePath = valuePath.Remove(0, valuePath.IndexOf("|") + 1);
        //            }

        //        }

        //    }

        //    return valuePath;
        //}

        ///// <summary>
        ///// this overload was added to supp-ort menu highlighting on physical .aspx pages added to the menu
        ///// </summary>
        ///// <param name="rootNode"></param>
        ///// <param name="offSet"></param>
        ///// <param name="currentUrl"></param>
        ///// <returns></returns>
        //public static String GetActivePageValuePath(SiteMapNode rootNode, int offSet, string currentUrl)
        //{
        //    string valuePath = string.Empty;

        //    SiteMapNode currentPageNode = GetSiteMapNodeForPage(rootNode, currentUrl);
        //    if (currentPageNode == null) { return string.Empty; }

        //    if (!(currentPageNode is hhtSiteMapNode)) { return string.Empty; }

        //    hhtSiteMapNode node = currentPageNode as hhtSiteMapNode;


        //    valuePath = node.PageGuid.ToString();

        //    while ((node != null) && (node.ParentId > -1))
        //    {
        //        if (node.ParentNode != null)
        //        {
        //            node = node.ParentNode as hhtSiteMapNode;

        //            valuePath = node.PageGuid.ToString() + "|" + valuePath;
        //        }

        //    }


        //    if (offSet > 0)
        //    {
        //        for (int i = 1; i <= offSet; i++)
        //        {
        //            if (valuePath.IndexOf("|") > -1)
        //            {
        //                valuePath = valuePath.Remove(0, valuePath.IndexOf("|") + 1);
        //            }

        //        }

        //    }

        //    return valuePath;


        //    // return valuePath;
        //}


        //public static String GetTopParentUrlForPageMenu(SiteMapNode rootNode)
        //{
        //    //String pageUrl = String.Empty;

        //    PageSettings pageSettings = CacheHelper.GetCurrentPage();

        //    SiteMapNode currentPageNode = GetSiteMapNodeForPage(rootNode, pageSettings);
        //    if (currentPageNode == null) { return string.Empty; }

        //    SiteMapNode topMostParentNode = GetTopLevelParentNode(currentPageNode);
        //    if (topMostParentNode == null) { return string.Empty; }

        //    return topMostParentNode.Url;




        //}



        //public static String GetPageMenuActivePageValuePath(SiteMapNode rootNode)
        //{

        //    String valuePath = GetActivePageValuePath(rootNode, 0);

        //    // need to remove the topmost level from value path
        //    // which is from the beginning to the first separator
        //    if (valuePath.IndexOf("|") > -1)
        //    {
        //        valuePath = valuePath.Remove(0, valuePath.IndexOf("|") + 1);
        //    }


        //    return valuePath;
        //}


        //public static bool TopPageHasChildren(SiteMapNode rootNode)
        //{
        //    return TopPageHasChildren(rootNode, 0);
        //}

        //public static hhtSiteMapNode GetCurrentPageSiteMapNode(SiteMapNode rootNode)
        //{
        //    if (rootNode == null) { return null; }
        //    PageSettings currentPage = CacheHelper.GetCurrentPage();
        //    if (currentPage == null) { return null; }

        //    return GetSiteMapNodeForPage(rootNode, currentPage);

        //}

        //public static hhtSiteMapNode GetSiteMapNodeForPage(SiteMapNode rootNode, PageSettings pageSettings)
        //{
        //    if (rootNode == null) { return null; }
        //    if (pageSettings == null) { return null; }
        //    if (!(rootNode is hhtSiteMapNode)) { return null; }

        //    foreach (SiteMapNode childNode in rootNode.ChildNodes)
        //    {
        //        if (!(childNode is hhtSiteMapNode)) { return null; }

        //        hhtSiteMapNode node = childNode as hhtSiteMapNode;
        //        if (node.PageId == pageSettings.PageId) { return node; }

        //        hhtSiteMapNode foundNode = GetSiteMapNodeForPage(node, pageSettings);
        //        if (foundNode != null) { return foundNode; }


        //    }

        //    return null;

        //}

        ///// <summary>
        ///// this overload was added to implement support for menu highlighting in inline code .aspx pages
        ///// added to the menu
        ///// </summary>
        ///// <param name="rootNode"></param>
        ///// <param name="currentUrl"></param>
        ///// <returns></returns>
        //public static hhtSiteMapNode GetSiteMapNodeForPage(SiteMapNode rootNode, string currentUrl)
        //{
        //    if (rootNode == null) { return null; }
        //    if (string.IsNullOrEmpty(currentUrl)) { return null; }
        //    if (!(rootNode is hhtSiteMapNode)) { return null; }

        //    foreach (SiteMapNode childNode in rootNode.ChildNodes)
        //    {
        //        if (!(childNode is hhtSiteMapNode)) { return null; }

        //        hhtSiteMapNode node = childNode as hhtSiteMapNode;
        //        if (string.Equals(node.Url.Replace("~", string.Empty), currentUrl, StringComparison.InvariantCultureIgnoreCase)) { return node; }

        //        hhtSiteMapNode foundNode = GetSiteMapNodeForPage(node, currentUrl);
        //        if (foundNode != null) { return foundNode; }


        //    }

        //    return null;

        //}

        //public static hhtSiteMapNode GetTopLevelParentNode(SiteMapNode siteMapNode)
        //{
        //    if (siteMapNode == null) { return null; }
        //    if (!(siteMapNode is hhtSiteMapNode)) { return null; }

        //    hhtSiteMapNode node = siteMapNode as hhtSiteMapNode;

        //    if (node.ParentId < 0) { return node; }

        //    while ((node != null) && (node.ParentId > -1))
        //    {
        //        if (node.ParentNode != null)
        //        {
        //            node = node.ParentNode as hhtSiteMapNode;
        //        }
        //        else
        //        {
        //            return node;
        //        }
        //    }

        //    return node;


        //}


        //public static bool NodeHasVisibleChildrenAtDepth(hhtSiteMapNode node, int depth)
        //{
        //    bool recurse = true;
        //    return NodeHasVisibleChildrenAtDepth(node, depth, recurse);
        //}


        //public static bool NodeHasVisibleChildrenAtDepth(hhtSiteMapNode node, int depth, bool recurse)
        //{
        //    foreach (SiteMapNode cNode in node.ChildNodes)
        //    {
        //        if (!(cNode is hhtSiteMapNode)) { return false; }

        //        hhtSiteMapNode childNode = cNode as hhtSiteMapNode;
        //        if (childNode.Depth >= depth)
        //        {
        //            if ((childNode.IncludeInMenu) && (WebUser.IsInRoles(childNode.ViewRoles))) { return true; }
        //        }
        //        else
        //        {
        //            if (recurse)
        //            {
        //                if (NodeHasVisibleChildrenAtDepth(childNode, depth, recurse)) { return true; }
        //            }
        //        }

        //    }

        //    return false;
        //}

        ///// <summary>
        ///// A helper method for determining if the top level page has children at this offsetlevel
        ///// used to determine whether to show or hide left or right div if it contains a menu.
        ///// </summary>
        ///// <param name="startingNodeOffset"></param>
        ///// <returns></returns>
        //public static bool TopPageHasChildren(SiteMapNode rootNode, int startingNodeOffset)
        //{
        //    if (rootNode == null) { return false; }

        //    PageSettings pageSettings = CacheHelper.GetCurrentPage();

        //    if (pageSettings == null) return false;

        //    if (
        //        (pageSettings.ParentId == -1)
        //        && (startingNodeOffset > 0)
        //        )
        //    {
        //        return false;
        //    }

        //    if (
        //        (pageSettings.ParentId > -1)
        //        && (pageSettings.IncludeInMenu) //added 2009-05-06
        //        && (startingNodeOffset == 0)
        //        )
        //    {
        //        return true;
        //    }

        //    hhtSiteMapNode currentPageNode = GetSiteMapNodeForPage(rootNode, pageSettings);
        //    if (currentPageNode == null) { return false; }

        //    if (startingNodeOffset >= 2)
        //    {
        //        if ((currentPageNode.Depth >= startingNodeOffset) && (currentPageNode.IncludeInMenu)) { return true; }

        //        bool recurse = false;
        //        hhtSiteMapNode parent;

        //        if (NodeHasVisibleChildrenAtDepth(currentPageNode, startingNodeOffset, recurse)) { return true; }

        //        if (currentPageNode.ParentNode != null)
        //        {
        //            parent = currentPageNode.ParentNode as hhtSiteMapNode;
        //            if (parent.Depth >= startingNodeOffset)
        //            {
        //                return NodeHasVisibleChildrenAtDepth(parent, startingNodeOffset, recurse);
        //            }
        //        }

        //        return false;

        //    }

        //    hhtSiteMapNode topParent = GetTopLevelParentNode(currentPageNode);
        //    if (topParent == null) { return false; }

        //    if (NodeHasVisibleChildrenAtDepth(topParent, startingNodeOffset)) { return true; }

        //    return false;


        //}

        //public static String GetStartUrlForPageMenu(SiteMapNode rootNode, int startingNodeOffset)
        //{

        //    PageSettings pageSettings = CacheHelper.GetCurrentPage();

        //    SiteMapNode currentPageNode = GetSiteMapNodeForPage(rootNode, pageSettings);
        //    if (currentPageNode == null) { return string.Empty; }

        //    if (startingNodeOffset == 0)
        //    {
        //        SiteMapNode startingNode = GetTopLevelParentNode(currentPageNode);
        //        if (startingNode == null) { return string.Empty; }

        //        return startingNode.Url;
        //    }

        //    //work our way up from the current page to the parent node at the offset depth
        //    hhtSiteMapNode n = currentPageNode as hhtSiteMapNode;

        //    while ((n.ParentNode != null) && (n.Depth > startingNodeOffset))
        //    {
        //        n = n.ParentNode as hhtSiteMapNode;
        //    }


        //    return n.Url;


        //}





        //public static bool IsContentPage()
        //{

        //    if (HttpContext.Current != null)
        //    {
        //        String rawUrl = HttpContext.Current.Request.RawUrl;
        //        if ((HttpContext.Current.Request.RawUrl.Contains("Login.aspx"))
        //            || (HttpContext.Current.Request.RawUrl.Contains("Register.aspx"))
        //            || (HttpContext.Current.Request.RawUrl.Contains("ChangePassword.aspx"))
        //            || (HttpContext.Current.Request.RawUrl.Contains("RecoverPassword.aspx"))
        //            || (HttpContext.Current.Request.RawUrl.Contains("UserProfile.aspx"))
        //            || (HttpContext.Current.Request.RawUrl.Contains("SiteMail"))
        //            || (HttpContext.Current.Request.RawUrl.Contains("MyPage.aspx"))
        //            || (HttpContext.Current.Request.RawUrl.Contains("SearchResults.aspx"))
        //            || (HttpContext.Current.Request.RawUrl.Contains("Admin"))
        //            || (HttpContext.Current.Request.RawUrl.Contains("Edit.aspx"))
        //            || (HttpContext.Current.Request.RawUrl.Contains("SiteMap.aspx"))
        //            )
        //        {
        //            return false;
        //        }

        //    }

        //    return true;

        //}

        //// TODO: this really shouldn't be here as it is specific to mojoportal.com
        //// purpose is to not show unsecure image on ssl pages
        //public static string GetSiteScoreImageMarkup()
        //{

        //    string markup = "<img src='http://sitescore.silktide.com/index.php?siteScoreUrl=http%3A%2F%2Fwww.hht.vn' "
        //        + "alt='Silktide Sitescore for this website' style='border: 0' />";

        //    if (HttpContext.Current != null)
        //    {
        //        if (HttpContext.Current.Request.ServerVariables["HTTPS"] == "on")
        //        {
        //            markup = String.Empty;
        //        }
        //    }

        //    return markup;

        //}

        public static string GetProfileLink(object objUserId, object userName)
        {
            string result = string.Empty;
            if (objUserId != null)
            {
                int userId = Convert.ToInt32(objUserId, CultureInfo.InvariantCulture);

                if (userName.ToString().Length > 0)
                {
                    result = "<a  href='" + GetNavigationSiteRoot() + "/ProfileView.aspx?userid="
                    + userId.ToString(CultureInfo.InvariantCulture) + "'>" + userName.ToString() + "</a>";
                }
            }

            return result;
        }

        public static string GetProfileLink(System.Web.UI.Page page, object objUserId, object userName)
        {
            string result = string.Empty;
            if (objUserId != null)
            {
                int userId = Convert.ToInt32(objUserId, CultureInfo.InvariantCulture);

                if (userName.ToString().Length > 0)
                {
                    result = "<a  href='"
                    + GetNavigationSiteRoot()
                    + "/ProfileView.aspx?userid="
                    + userId.ToInvariantString() + "'>"
                    + userName.ToString() + "</a>";
                }
            }

            return result;
        }

        public static string GetProfileAvatarLink(
        System.Web.UI.Page page,
        object objUserId,
        int siteId,
        String avatar,
        String toolTip)
        {
            string result = string.Empty;
            if (objUserId != null)
            {
                int userId = Convert.ToInt32(objUserId);


                if ((avatar == null) || (avatar == String.Empty))
                {
                    avatar = "blank.gif";
                }
                String avaterImageMarkup = "<img title='" + toolTip
                + "'  alt='" + toolTip + "' src='"
                + page.ResolveUrl("~/Data/Sites/" + siteId.ToString(CultureInfo.InvariantCulture) + "/useravatars/" + avatar)
                + "' />";

                result = "<a title='" + toolTip + "' href='"
                + GetNavigationSiteRoot()
                + "/ProfileView.aspx?userid="
                + userId.ToString(CultureInfo.InvariantCulture) + "'>"
                + avaterImageMarkup + "</a>";
            }

            return result;
        }

        //public static string GetGmapApiKey()
        //{
        //    SiteSettings siteSettings = CacheHelper.GetCurrentSiteSettings();
        //    if (siteSettings.GmapApiKey.Length > 0)
        //        return siteSettings.GmapApiKey;

        //    return WebConfigSettings.GoogleMapsAPIKey;


        //}

        //public static string GetBingApiId()
        //{
        //    if (WebConfigSettings.BingAPIId.Length > 0)
        //    {
        //        return WebConfigSettings.BingAPIId;

        //    }
        //    else
        //    {
        //        SiteSettings siteSettings = CacheHelper.GetCurrentSiteSettings();
        //        if (siteSettings != null)
        //        {
        //            return siteSettings.BingAPIId;
        //        }

        //    }

        //    return string.Empty;

        //}

        //public static string GetSearchDomain()
        //{
        //    if (WebConfigSettings.CustomSearchDomain.Length > 0)
        //    {
        //        return WebConfigSettings.CustomSearchDomain.Trim();

        //    }
        //    else
        //    {
        //        return  WebUtils.GetHostName();
        //    }
        //}

        //public static string GetGoogleCustomSearchId()
        //{
        //    if (WebConfigSettings.GoogleCustomSearchId.Length > 0)
        //    {
        //        return WebConfigSettings.GoogleCustomSearchId;
        //    }

        //    SiteSettings siteSettings = CacheHelper.GetCurrentSiteSettings();
        //    if (siteSettings != null) { return siteSettings.GoogleCustomSearchId; }


        //    return string.Empty;

        //}

        //public static string GetPrimarySearchProvider()
        //{

        //    if (WebConfigSettings.PrimarySearchEngine.Length > 0)
        //    {
        //        return WebConfigSettings.PrimarySearchEngine;
        //    }

        //    SiteSettings siteSettings = CacheHelper.GetCurrentSiteSettings();
        //    if (siteSettings != null)
        //    {
        //        string result = siteSettings.PrimarySearchEngine;
        //        switch (result)
        //        {
        //            case "bing":
        //                if (siteSettings.BingAPIId.Length > 0) { return result; }
        //                break;

        //            case "google":
        //                if (siteSettings.GoogleCustomSearchId.Length > 0) { return result; }
        //                break;

        //            default:
        //                return "internal";

        //        }
        //    }

        //    return "internal";

        //}

        //public static bool ShowAlternateSearchIfConfigured()
        //{
        //    if (WebConfigSettings.ShowAlternateSearchIfConfigured) { return true; }

        //    SiteSettings siteSettings = CacheHelper.GetCurrentSiteSettings();
        //    if (siteSettings != null) { return siteSettings.ShowAlternateSearchIfConfigured; }

        //    return false;
        //}

        public static CultureInfo GetDefaultCulture()
        {

            //if (WebConfigSettings.UseCultureOverride)
            //{
            //    string siteCultureKey = "site" + GetSiteId() + "culture";

            //        if (ConfigurationManager.AppSettings[siteCultureKey] != null)
            //        {
            //            try
            //            {
            //                string cultureName = ConfigurationManager.AppSettings[siteCultureKey];

            //               // change these neutral cultures which cannot be used to reasonable specific cultures
            //                if (cultureName == "zh-CHS") { cultureName = "zh-CN"; }
            //                if (cultureName == "zh-CHT") { cultureName = "zh-HK"; }

            //                CultureInfo siteCulture = new CultureInfo(cultureName);
            //                return siteCulture;
            //            }
            //            catch { }
            //        }
            //}

            return ResourceHelper.GetDefaultCulture();
        }

        public static Guid GetDefaultCountry()
        {

            // US
            Guid defaultCountry = new Guid("a71d6727-61e7-4282-9fcb-526d1e7bc24f");

            // TODO: add config setting, siteSetting ?

            return defaultCountry;
        }

        public static string GetTimeZoneLabel(double timeOffset)
        {
            string key = "TZ" + timeOffset.ToString(CultureInfo.InvariantCulture).Replace(".", string.Empty).Replace("-", "minus");
            return ResourceHelper.GetResourceString("TimeZoneResources", key);
        }

        public static List<TimeZoneInfo> GetTimeZoneList()
        {
            if (HttpContext.Current == null)
                return null;

            List<TimeZoneInfo> timeZones = HttpContext.Current.Items["tzlist"] as List<TimeZoneInfo>;
            if (timeZones == null)
            {
                //if (WebConfigSettings.CacheTimeZoneList)
                //{
                //    timeZones = CacheHelper.GetTimeZones();
                //}
                //else
                //{
                timeZones = DateTimeHelper.GetTimeZoneList();
                //}

                if (timeZones != null)
                {
                    HttpContext.Current.Items["tzlist"] = timeZones;
                }
            }
            return timeZones;
        }

        public static TimeZoneInfo GetTimeZone(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return null;
            }
            List<TimeZoneInfo> timeZones = GetTimeZoneList();
            return DateTimeHelper.GetTimeZone(timeZones, id);
        }


        public static TimeZoneInfo GetSiteTimeZone()
        {
            string result = "Vietnam Standard Time";

            return GetTimeZone(result);
        }

        public static TimeZoneInfo GetUserTimeZone()
        {
            //User siteUser = GetCurrentUser();
            //if ((siteUser != null) && (siteUser.TimeZoneId.Length > 0))
            //{
            //    return GetTimeZone(siteUser.TimeZoneId);
            //}
            return GetSiteTimeZone();
        }

        private static Double GetSiteTimeZoneOffset()
        {
            Double timeOffset = 0;

            string cacheKey = "sitetzoffset_" + GetSiteId();
            object o = HttpContext.Current.Items[cacheKey];

            try
            {
                if (o != null)
                {
                    return Convert.ToDouble(o);
                }
                else
                {
                    TimeZoneInfo tz = GetTimeZone("Vietnam Standard Time");
                    if (tz == null)
                    {
                        return timeOffset;
                    }
                    Double siteTimeOffset = tz.GetUtcOffset(DateTime.UtcNow).TotalHours;
                    HttpContext.Current.Items[cacheKey] = siteTimeOffset;
                    return siteTimeOffset;
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
                return timeOffset;
            }
        }

        public static double GetUserTimeOffset()
        {
            Double timeOffset = 0;
            if (HttpContext.Current == null)
            {
                return timeOffset;
            }
            if (HttpContext.Current.Request == null)
            {
                return timeOffset;
            }


            if (!HttpContext.Current.Request.IsAuthenticated)
            {
                return GetSiteTimeZoneOffset();
            }

            timeOffset = GetSiteTimeZoneOffset();

            //User siteUser = GetCurrentUser();
            //if (siteUser != null)
            //{
            //    if (siteUser.TimeZoneId.Length == 0) { return siteUser.TimeOffsetHours; }
            //    string cacheKey = "tzoffset_" + siteUser.UserId.ToInvariantString();
            //    object o = HttpContext.Current.Items[cacheKey];

            //    try
            //    {
            //        if (o != null)
            //        {
            //            return Convert.ToDouble(o);
            //        }
            //        else
            //        {
            //            TimeZoneInfo tz = GetTimeZone(siteUser.TimeZoneId);
            //            if (tz == null) { return siteUser.TimeOffsetHours; }
            //            Double userTimeOffset = tz.GetUtcOffset(DateTime.UtcNow).TotalHours;
            //            HttpContext.Current.Items[cacheKey] = userTimeOffset;
            //            return userTimeOffset;
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        log.Error(ex);
            //        return siteUser.TimeOffsetHours;
            //    }

            //}

            return timeOffset;
        }


        public static string SanitizeSkinParam(string skinName)
        {
            if (string.IsNullOrEmpty(skinName))
            {
                return skinName;
            }

            // protected against this xss attack
            // ?skin=1%00'"><ScRiPt%20%0a%0d>alert(403326057258)%3B</ScRiPt>
            return skinName.Replace("%", string.Empty).Replace(" ", string.Empty).Replace(">", string.Empty).Replace("<", string.Empty).Replace("'", string.Empty).Replace("\"", string.Empty);
        }

        public static CultureInfo GetDefaultUICulture()
        {
            return GetCulture();
        }

        //internal static string GetGmapApiKey()
        //{
        //    return WebConfigSettings.GoogleMapsAPIKey;
        //}

        internal static bool IsSecureRequest()
        {
            if ((HttpContext.Current != null) && (HttpContext.Current.Request != null))
            {
                // default this works when the SSL certificate is installed in the site but not when using load balancers or other proxy server
                if (HttpContext.Current.Request.IsSecureConnection)
                {
                    return true;
                }

                if (WebConfigSettings.SecureConnectionServerVariableForPresenceCheck.Length > 0)
                {
                    if (HttpContext.Current.Request.ServerVariables[WebConfigSettings.SecureConnectionServerVariableForPresenceCheck] != null)
                    {
                        return true;
                    }
                }

                if ((WebConfigSettings.SecureConnectionServerVariableForValueCheck.Length > 0) && (WebConfigSettings.SecureConnectionServerVariableSecureValue.Length > 0))
                {
                    if (HttpContext.Current.Request.ServerVariables[WebConfigSettings.SecureConnectionServerVariableForValueCheck] != null)
                    {
                        if (HttpContext.Current.Request.ServerVariables[WebConfigSettings.SecureConnectionServerVariableForValueCheck] == WebConfigSettings.SecureConnectionServerVariableSecureValue)
                        {
                            return true;
                        }
                    }
                }
            }


            return false;
        }
    }
}
