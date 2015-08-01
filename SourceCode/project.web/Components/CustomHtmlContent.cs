using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace project.web
{
    public static class CustomHtmlContent
    {
        public static Guid GetNhanVienGuid()
        {
            if (HttpContext.Current.Request.QueryString["NhanVienGuid"] != null)
                try
                {
                    return new Guid(HttpContext.Current.Request.QueryString["NhanVienGuid"].ToString());
                }
                catch (Exception ex)
                {
                    return Guid.Empty;
                }

            return Guid.Empty;
        }

        public static string GetNhanVienID()
        {
            if (HttpContext.Current.Request.QueryString["NhanVienID"] != null)
                return HttpContext.Current.Request.QueryString["NhanVienID"].ToString();
            return string.Empty;
        }

        #region thanhdai18ht
        public static string GetShortKeySeach()
        {
            if (HttpContext.Current.Request.QueryString["khoa"] != null)
                return HttpContext.Current.Request.QueryString["khoa"].ToString();
            return string.Empty;
        }

        public static string GetKeySeach()
        {
            if (HttpContext.Current.Request.QueryString["key"] != null)
                return HttpContext.Current.Request.QueryString["key"].ToString();
            return string.Empty;
        }
        public static void SetCookies(List<ListItem> listControl)
        {
            if (listControl != null)
                foreach (ListItem item in listControl)
                    HttpContext.Current.Response.Cookies["Filter"][item.Text] = item.Value;
        }

        public static List<ListItem> GetCookies(List<ListItem> listControl)
        {
            if (HttpContext.Current.Request.Cookies["Filter"] != null)
            {
                if (listControl != null)
                    foreach (ListItem item in listControl)
                        item.Value = HttpContext.Current.Request.Cookies["Filter"][item.Text].ToString();
            }
            return listControl;
        }

        public static void DeleteCookie(string name)
        {
            HttpCookie cookie;
            if (HttpContext.Current.Request.Cookies[name] == null) return;
            else cookie = HttpContext.Current.Request.Cookies[name];
            cookie.Expires = DateTime.Now.AddDays(-1);
            HttpContext.Current.Response.Cookies.Add(cookie);
        }
        #endregion
    }
}