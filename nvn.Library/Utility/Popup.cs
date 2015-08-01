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
    public static class Popup
    {
        public static string OpenPopup(string divName)
        {
            return @"
            <script type='text/javascript'> $(function () {
                function runEffect1() {
                        var bg=$('div#ts-popup-bg');
                        var obj=$('div#" + divName + @"');
                        bg.animate({opacity:0.2},0).fadeIn(200); //cho nền trong suốt
                        obj.fadeIn(200).absoluteCenter(); //căn giữa popup và thêm draggable của jquery UI cho phần header của popup

                    };
                runEffect1();
                });</script>";
        }

        public static string ExitPopup(string divName)
        {
            return @"
                <script type='text/javascript'> 
                    $(function () {
                        function runEffect() {
                            var bg=$('div#ts-popup-bg');
                            var obj=$('div#" + divName + @"');

                            bg.fadeOut(200);
			                obj.fadeOut(200);
                        };
                    runEffect();
                    });
                </script>";
        }
    }
}
