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


namespace project.web
{
    public static class LoginBaoCao
    {
        public static string CreateKey(Guid UserGuid)
        {
            string key = UserGuid.ToString();
            Random random = new Random();
            int flag = random.Next(0, 32);

            key = key.Insert(flag, random.Next(0, 9).ToString());
            if (flag < 10) key = key + "0" + flag;
            else key = key + flag;

            return key;
        }

        public static Guid UnlockKey(string key)
        {
            try
            {
                int flag = Convert.ToInt32(key.Substring(key.Length - 2, 2));

                key = key.Remove(flag, 1);
                key = key.Remove(key.Length - 2, 2);

                return new Guid(key);
            }
            catch
            {
                return Guid.Empty;
            }
        }

        public static string ms(string value)
        {
            return
                @"
            <script type='text/javascript'> $(function () {
            function showmessageerror(title, message) {
                var opts, container;
                opts = {};
                opts.classes = ['simple'];

                opts.hideStyle = {
                    opacity: 0,
                    left: '400px'
                };
                opts.showStyle = {
                    opacity: 1,
                    left: 0
                };

                container = '#abc';
                $(container).freeow(title, message, opts);
            };
               showmessageerror('Thông báo','" + value + @"');
            });</script>
                ";

        }
    }
}
