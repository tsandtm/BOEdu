using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.IO;

//Example
//try
//{
//    int so1 = Convert.ToInt32(TextBox1.Text);
//}
//catch (Exception ex)
//{
//    LogError.SaveLogEvent(
//        Request.RawUrl,
//        ex.Message,ex.StackTrace,Guid.Empty,Guid.Empty);
//}

namespace nvn.Library
{
    public static class LogError
    {
        //DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")+"- (Controller:DangKiNgoaiKeHoach/index) :"+ exx.Message
        public static void SaveLogEvent(string controller, string chuoilog)
        {
            StreamWriter f = null;
            try
            {
                string path = HttpContext.Current.Server.MapPath("~/Log/error_" + DateTime.Now.ToString("dd/MM/yyyy") + ".txt");
                if (File.Exists(path))              //kiem tra xem file co ton tai ko
                {
                    f = File.AppendText(path); //neu ko thi ghi noi vao cuoi file
                    f.WriteLine(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + "- (Controller:"+controller+") :" +chuoilog);
                }
                else
                {
                    f = File.CreateText(path); //  neu file ko ton tai thi tao ra file moi
                    f.WriteLine(chuoilog);
                }
            }
            finally
            {
                if (f != null)
                    f.Close();
            }
        }

        public static void SaveLogEvent(
            string ErrorPageURL,
            string ErrorMessage,
            string ErrorStackTrace,
            Guid CodeGuid,
            string CodeName,
            Guid UserGuid
            )
        {
            // Get the error details     
            //SqlConnection sqlcon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectStringErrorForAll"]);

            //    try
            //    {
            //    SqlCommand sqlcmd = new SqlCommand();
            //    sqlcmd.CommandType = CommandType.StoredProcedure;
            //    sqlcmd.Connection = sqlcon;
            //    sqlcmd.Parameters.Add(new SqlParameter("@ErrorPageURL", SqlDbType.NVarChar, 500)).Value = ErrorPageURL;
            //    sqlcmd.Parameters.Add(new SqlParameter("@ErrorMessage", SqlDbType.NVarChar, 2000)).Value = ErrorMessage;
            //    sqlcmd.Parameters.Add(new SqlParameter("@ErrorStackTrace", SqlDbType.NVarChar,-1)).Value = ErrorStackTrace;
            //    sqlcmd.Parameters.Add(new SqlParameter("@CreatedDateTime", SqlDbType.DateTime)).Value = DateTime.Now;
            //    sqlcmd.Parameters.Add(new SqlParameter("@UserData", SqlDbType.NVarChar,1000)).Value = GetUserData();
            //    sqlcmd.Parameters.Add(new SqlParameter("@CodeGuid", SqlDbType.UniqueIdentifier)).Value = CodeGuid;
            //    sqlcmd.Parameters.Add(new SqlParameter("@UserGuid", SqlDbType.UniqueIdentifier)).Value = UserGuid;

            //    sqlcmd.CommandText = "sp_LogError_Insert";  // Procedure Name

            //    if (sqlcon.State == ConnectionState.Closed)
            //        sqlcon.Open();

            //    sqlcmd.ExecuteNonQuery();

            //    if (sqlcon.State == ConnectionState.Open)
            //        sqlcon.Close();
            //}

            //catch
            //{
            //    if (sqlcon.State == ConnectionState.Open)
            //        sqlcon.Close();
            //}
        }

        #region Private method
        private static string GetUserData()
        {
            System.Web.HttpBrowserCapabilities browser = HttpContext.Current.Request.Browser;
            string s = "Browser Capabilities\n"
                + "IP Address = " + HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"].ToString() + "\n"
                + "Type = " + browser.Type + "\n"
                + "Name = " + browser.Browser + "\n"
                + "Version = " + browser.Version + "\n"
                + "Major Version = " + browser.MajorVersion + "\n"
                + "Minor Version = " + browser.MinorVersion + "\n"
                + "Platform = " + browser.Platform + "\n"
                + "Is Beta = " + browser.Beta + "\n"
                + "Is Crawler = " + browser.Crawler + "\n"
                + "Is AOL = " + browser.AOL + "\n"
                + "Is Win16 = " + browser.Win16 + "\n"
                + "Is Win32 = " + browser.Win32 + "\n"
                + "Supports Frames = " + browser.Frames + "\n"
                + "Supports Tables = " + browser.Tables + "\n"
                + "Supports Cookies = " + browser.Cookies + "\n"
                + "Supports VBScript = " + browser.VBScript + "\n"
                //+ "Supports JavaScript = " + browser.JavaScript + "\n"
                + "Supports Java Applets = " + browser.JavaApplets + "\n"
                + "Supports BackgroundSounds = " + browser.BackgroundSounds + "\n"
                + "Supports ActiveX Controls = " + browser.ActiveXControls + "\n"
                + "Browser = " + browser.Browser + "\n"
                + "CDF = " + browser.CDF + "\n"
                + "CLR Version = " + browser.ClrVersion + "\n"
                + "ECMA Script version = " + browser.EcmaScriptVersion + "\n"
                + "MSDOM version = " + browser.MSDomVersion + "\n"
                + "Supports tables = " + browser.Tables + "\n"
                + "W3C DOM version = " + browser.W3CDomVersion + "\n";
            return s;

        }
        #endregion
    }
}
