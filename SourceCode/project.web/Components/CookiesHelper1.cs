﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace project.web.Components
{

    public static class CookieHelper1
    {


        /// <summary>
        /// 获取一个数组形式的Cookies
        /// </summary>
        public static HttpCookie GetCookie(string name)
        {
            return HttpContext.Current.Request.Cookies[name];
        }

        /// <summary>
        /// 移除Cookies
        /// </summary>
        public static void RemoveCookie(string name)
        {
            RemoveCookie(GetCookie(name));
        }

        /// <summary>
        /// 移除Cookies
        /// </summary>
        public static void RemoveCookie(HttpCookie cookie)
        {
            if (cookie != null)
            {
                cookie.Expires = new DateTime(1983, 1, 2);
                Save(cookie);
            }
        }

        /// <summary>
        /// 保存Cookies
        /// </summary>
        public static void Save(HttpCookie cookie)
        {

            cookie.Domain = "";
            HttpContext.Current.Response.AppendCookie(cookie);
        }

        /// <summary>
        /// 获取一个新的Cookies
        /// </summary>
        public static HttpCookie GetNewCookie(string name)
        {
            HttpCookie hc=new HttpCookie(name);

            return hc;
        }

        /// <summary>
        /// 取得指定名称的单值Cookie
        /// </summary>
        /// <returns></returns>
        public static string GetCookieValue(string name)
        {
            HttpCookie cookie = GetCookie(name);
            if (cookie == null || cookie.Value == null)
            {
                return string.Empty;
            }
            else
            {
                return cookie.Value;
            }
        }

        /// <summary>
        /// 保存指定名称的单值Cookie
        /// </summary>
        /// <returns></returns>
        public static void SetCookie(string name, string value)
        {
            SetCookie(name, value, DateTime.Now.AddDays(1));
        }

        /// <summary>
        /// 保存指定名称的单值Cookie
        /// </summary>
        /// <returns></returns>
        public static void SetCookie(string name, string value, DateTime expires)
        {
            HttpCookie cookie = GetCookie(name);
            if (cookie == null)
            {
                cookie = GetNewCookie(name);
            }
            cookie.Value = value;
            cookie.Expires = expires;
            Save(cookie);
        }
    }
}