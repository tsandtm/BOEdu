using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nvn.Library.Frameworks
{
    public static class Validations
    {
        /// <summary>
        /// Example: Validations.CheckNull("Ngày trực", txtNgayTruc.Text)
        /// </summary>
        /// <param name="controlName"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string CheckNull(string controlName, string text)
        {
            text = text.Replace(" ", "");
            if (text == null || text == string.Empty)
                return "- Kiểm tra lại dữ liệu: " + controlName + "<br />";
            return string.Empty;
        }
    }
}
