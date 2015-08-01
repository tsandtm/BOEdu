/// <summary>
/// Lớp cơ sở cho tất cả các trang webform. 
/// Lớp này thể hiện các phương thức, sự kiện dùng chung cho tất cả các webform.
/// Tất cả các webform phải thừa kế lớp này.
///
/// Tạo bởi:  TSANDTM
/// Ngày tạo: 22/2/2012
/// </summary>
/// <remarks></remarks>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Runtime.InteropServices;
using System.Text;

using System.Threading;
using System.Globalization;
using thanhdai18htquanlyphanquyen.Library.Framework;
using thanhdai18htquanlyphanquyen.Library.WebHelpers;

namespace project.web
{
    public class hutechBasePage : System.Web.UI.Page
    {
        #region Volume Infomations
        [DllImport("kernel32.dll")]
        private static extern long GetVolumeInformation(string PathName, StringBuilder VolumeNameBuffer, UInt32 VolumeNameSize, ref UInt32 VolumeSerialNumber, ref UInt32 MaximumComponentLength, ref UInt32 FileSystemFlags, StringBuilder FileSystemNameBuffer, UInt32 FileSystemNameSize);


        public string GetVolumeSerial(string strDriveLetter)
        {
            uint serNum = 0;
            uint maxCompLen = 0;
            StringBuilder VolLabel = new StringBuilder(256); // Label
            UInt32 VolFlags = new UInt32();
            StringBuilder FSName = new StringBuilder(256); // File System Name
            strDriveLetter += ":\\"; // fix up the passed-in drive letter for the API call
            long Ret = GetVolumeInformation(strDriveLetter, VolLabel, (UInt32)VolLabel.Capacity, ref serNum, ref maxCompLen, ref VolFlags, FSName, (UInt32)FSName.Capacity);

            return Convert.ToString(serNum);
        }


        #endregion

        //private ContentPlaceHolder leftPane;
        //private ContentPlaceHolder centerPane;
        //private ContentPlaceHolder rightPane;
        //private ContentPlaceHolder editPane;
        //private ContentPlaceHolder altPane1;
        //private ContentPlaceHolder altPane2;

        private string siteRoot = null;
        private string secureSiteRoot = null;
        private string imageSiteRoot = null;
        private ScriptManager scriptController;
        private bool scriptLoaderFoundInMaster = false;

        private bool appendQueryStringToAction = false;

        public int DefaultPageSize = 10;

        private ContentPlaceHolder _contentRegion;

        public ContentPlaceHolder ContentRegion
        {
            get
            {
                return _contentRegion;
            }
            set
            {
                _contentRegion = value;
            }
        }

        public string DefaultpageTitle
        {
            get
            {
                return "";
            }
        }

        public Guid SiteId
        {
            get
            {
                return new Guid();
            }
        }
		////////////////
        public string PageTitle
        {
            get
            {
                return this.Page.Title;
            }
            set
            {
                if (value != string.Empty)
                    this.Page.Title = value;
                else
                    this.Page.Title = this.DefaultpageTitle;
            }
        }
        public ScriptManager ScriptController
        {
            get
            {
                if (scriptController == null)
                {
                    scriptController = (ScriptManager)Master.FindControl("ScriptManager1");
                }
                return scriptController;
            }
        }

        public bool AppendQueryStringToAction
        {
            get
            {
                return appendQueryStringToAction;
            }
            set
            {
                appendQueryStringToAction = value;
            }
        }

        public bool ContainsPlaceHolder(string placeHoderId)
        {
            if (Master.FindControl(placeHoderId) != null)
                return true;
            return false;
        }

        public String SiteRoot
        {
            get
            {
                if (siteRoot == null)
                    siteRoot =  WebUtils.GetSiteRoot();
                return siteRoot;
            }
        }

        public String SecureSiteRoot
        {
            get
            {
                //if (!SiteUtils.SslIsAvailable()) return SiteRoot;
                if (secureSiteRoot == null)
                    secureSiteRoot =  WebUtils.GetSecureSiteRoot();
                return secureSiteRoot;
            }
        }

        public String ImageSiteRoot
        {
            get
            {
                if (imageSiteRoot == null)
                    imageSiteRoot =  WebUtils.GetSiteRoot();
                return imageSiteRoot;
            }
        }

        //public ScriptLoader ScriptConfig
        //{
        //    get
        //    {
        //        if (scriptLoader == null)
        //        {
        //            scriptLoader = Master.FindControl("ScriptLoader1") as ScriptLoader;
        //            if (scriptLoader != null) { scriptLoaderFoundInMaster = true; }
        //        }
        //        // older skins may not have the script loader so we can add it below in OnInit if scriptLoaderFoundInMaster is false
        //        if (scriptLoader == null) { scriptLoader = new ScriptLoader(); }

        //        return scriptLoader;
        //    }

        //}



        //public StyleSheetCombiner StyleCombiner
        //{
        //    get
        //    {
        //        if (styleCombiner == null)
        //        {
        //            styleCombiner = Master.FindControl("StyleSheetCombiner") as StyleSheetCombiner;

        //        }
        //        return styleCombiner;
        //    }

        //}


        #region Permission

        public bool IsAdminOrContentAdmin
        {
            get
            {
                return WebUser.IsAdminOrContentAdmin;
            }
        }

        public bool IsAdmin
        {
            get
            {
                return WebUser.IsAdmin;
            }
        }

        #endregion

        #region "Setup Master Page"

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            SetupMasterPage();

            if (!IsPostBack)
                Session["ActivePage"] = this.Page.Request.Url.ToString()
                .ToLowerInvariant()
                .Replace(SiteRoot.ToLowerInvariant() + "/", "");
        }

        private void SetupMasterPage()
        {
            try
            {
                _contentRegion = (ContentPlaceHolder)this.Master.FindControl("cphContent");
            }
            catch
            {
                _contentRegion = null;
            }
        }

        #endregion

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            //Check Valid Permissions
            if (!Request.IsAuthenticated)
            {
                SiteUtils.RedirectToLoginPage(this, Request.Url.ToString());

            }
            else
            {
                //nếu mất đi session quyền hạn thì đăng xuất luôn bắt người dùng đăng nhập lại
                if (HttpContext.Current.Session["permissionvalue"] == null)
                    SiteUtils.RedirectToSignOut();
            }
        }
    }
}
