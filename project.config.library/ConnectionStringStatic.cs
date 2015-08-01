using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace project.config.library
{
    public static class ConnectionStringStatic
    {
        #region demo
        public static string GetReadConnectionString()
        {
            return ConfigurationManager.AppSettings["DefaultConnection"];
        }

        public static string GetWriteConnectionString()
        {
            if (ConfigurationManager.AppSettings["DefaultConnection"] != null)
            {
                return ConfigurationManager.AppSettings["DefaultConnection"];
            }

            return ConfigurationManager.AppSettings["DefaultConnection"];
        }
        #endregion
       

    }
}
