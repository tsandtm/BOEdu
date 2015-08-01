using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;


namespace nvn.Library.Utility
{
    public static class ShowMessage
    {
        /// <summary>
        /// Hien thi popup loi 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string Error( string messess)
        {
            return
                @"
                <script type='text/javascript'>
                     $(function () {
                                function showmessageerror(title, message,oftion) {
                                    var opts, container;
                                    opts = {};
                                    opts.classes = ['simple'];
                                    if(oftion==1)
                                        opts.classes.push('error');
                                    if(oftion==2)                                    
                                        opts.classes.push('saveok');
                                    if(oftion==3)
                                        opts.classes.push('waning');
                                    opts.hideStyle = {
                                        opacity: 0,
                                        left: '400px'
                                    };
                                    opts.showStyle = {
                                        opacity: 1,
                                        left: 0
                                    };

                                    container = '#Error';
                                    $(container).freeow(title, message, opts);
                                };
                                   showmessageerror('','" + messess + @"'," + 1 + @");
                                });
                        </script>";
        }
        public static string Waning( string messess)
        {
            return
                @"
                <script type='text/javascript'>
                     $(function () {
                                function showmessageerror(title, message,oftion) {
                                    var opts, container;
                                    opts = {};
                                    opts.classes = ['simple'];
                                    if(oftion==1)
                                        opts.classes.push('error');
                                    if(oftion==2)                                    
                                        opts.classes.push('saveok');
                                    if(oftion==3)
                                        opts.classes.push('waning');
                                    opts.hideStyle = {
                                        opacity: 0,
                                        left: '400px'
                                    };
                                    opts.showStyle = {
                                        opacity: 1,
                                        left: 0
                                    };

                                    container = '#Error';
                                    $(container).freeow(title, message, opts);
                                };
                                   showmessageerror('','" + messess + @"'," + 3 + @");
                                });
                        </script>";
        }
        public static string Success(string messess)
        {
            return
                @"
                <script type='text/javascript'>
                     $(function () {
                                function showmessageerror(title, message,oftion) {
                                    var opts, container;
                                    opts = {};
                                    opts.classes = ['simple'];
                                    if(oftion==1)
                                        opts.classes.push('error');
                                    if(oftion==2)                                    
                                        opts.classes.push('saveok');
                                    if(oftion==3)
                                        opts.classes.push('waning');
                                    opts.hideStyle = {
                                        opacity: 0,
                                        left: '400px'
                                    };
                                    opts.showStyle = {
                                        opacity: 1,
                                        left: 0
                                    };

                                    container = '#Error';
                                    $(container).freeow(title, message, opts);
                                };
                                   showmessageerror('','" + messess + @"'," + 2 + @");
                                });
                        </script>";
        }

    }
}
