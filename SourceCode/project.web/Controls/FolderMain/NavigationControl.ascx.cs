using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using thanhdai18htquanlyphanquyen.Library.Framework;


namespace project.web.Controls.FolderMain
{
    public partial class NavigationControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SecurityHelper.DisableBrowserCache();
            PopulateLabels();
        }

        private void PopulateLabels()
        {
            //liDanhMucQuanTri.Visible = WebUser.IsAdmin == true ? true : WebUser.isPermission("DanhMucQuanTri");
            //liQuanLyBaiViet.Visible = WebUser.IsAdmin == true ? true : WebUser.isPermission("QuanLyBaiViet");
            //liDanhMucThongTin.Visible = WebUser.IsAdmin == true ? true : WebUser.isPermission("QuanLyDanhMucThongTin");
            //liQuanLyTinTuc.Visible = WebUser.IsAdmin == true ? true : WebUser.isPermission("QuanLyTinTuc");
            //liQuanLyQuangCao.Visible = WebUser.IsAdmin == true ? true : WebUser.isPermission("QuanLyQuangCao");
        }
    }
}