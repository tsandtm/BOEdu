using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace project.config.library
{
    public static class ConnectionStringStatic
    {
        public static string GetReadConnectionString()
        {
            return ConfigurationManager.AppSettings["MSSQLConnectionString"];
        }

        /// <summary>
        /// Gets the connection string for write.
        /// </summary>
        /// <returns></returns>
        public static string GetWriteConnectionString()
        {
            if (ConfigurationManager.AppSettings["MSSQLWriteConnectionString"] != null)
            {
                return ConfigurationManager.AppSettings["MSSQLWriteConnectionString"];
            }

            return ConfigurationManager.AppSettings["MSSQLConnectionString"];
        }
    }
}
