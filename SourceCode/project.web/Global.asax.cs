using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Routing;

namespace project.web
{
    public class Global : System.Web.HttpApplication
    {
        void RegisterRoute(RouteCollection route)
        {
            route.MapPageRoute("default1", "home", "~/default.aspx");
            route.MapPageRoute("default", "", "~/default.aspx");
            route.MapPageRoute("tintuc2", "tin-tuc", "~/Page/TinTuc.aspx");
            route.MapPageRoute("tintuc3", "tin-tuc/{id}_{title}.html", "~/Page/TinTuc.aspx");
            route.MapPageRoute("nhomtin", "tin-tuc/{cato}_{title}/", "~/Page/TinTuc.aspx");
            //route.MapPageRoute("timkiem", "tim-kiem/{key}.html", "~/Page/TimKiem.aspx");
            route.MapPageRoute("chuyenmuc", "chuyen-muc/{cm}_{title}.html", "~/Page/ChuyenMuc.aspx");
            route.MapPageRoute("dondathang", "don-dat-hang", "~/Page/FolderGioHang/DatHang.aspx");

            route.MapPageRoute("sanpham", "san-pham/{cat}/{catname}", "~/Page/SanPham.aspx");
			route.MapPageRoute("chitietsanpham", "san-pham/{sx}/{cat}_{title3}/{id}_{title1}", "~/Page/ChiTietSanPham.aspx");
        }
        protected void Application_Start(object sender, EventArgs e)
        {
            RegisterRoute(RouteTable.Routes);
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}