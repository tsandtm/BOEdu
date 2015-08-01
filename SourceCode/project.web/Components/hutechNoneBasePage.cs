/// <summary>
/// Lớp cơ sở cho tất cả các trang webform. 
/// Lớp này thể hiện các phương thức, sự kiện dùng chung cho tất cả các webform.
/// Tất cả các webform phải thừa kế lớp này.
///
/// Tạo bởi:  LE XUAN MANH
/// Ngày tạo: 24/03/2010
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
using thanhdai18htquanlyphanquyen.Library.Framework;
using thanhdai18htquanlyphanquyen.Library.WebHelpers;


namespace project.web
{
    public class hutechNoneBasePage : System.Web.UI.Page
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
        private string siteRoot = null;
        private string secureSiteRoot = null;
        private string imageSiteRoot = null;
        private ScriptManager scriptController;

        private bool appendQueryStringToAction = false;


        public string DefaultpageTitle
        {
            get
            {
                return "Hutech Application";
            }
        }

        public string PageTitle
        {
            get
            {
                return this.Page.Title;
            }
            set
            {
                this.Page.Title = this.DefaultpageTitle + " - " + value;
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
                if (!SiteUtils.SslIsAvailable())
                    return SiteRoot;
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

        #region "Setup Page"

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
        }

        #endregion
    }
}
