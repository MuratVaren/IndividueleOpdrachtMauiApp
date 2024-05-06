using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibAutheur.Data.Framework
{
    static class LocalSettings
    {
        // laptop connection
        public static string GetConnectionString()
        {
            string connectionString = "user id = sa;";
            connectionString += "Password = pxl;";
            connectionString += $@"Server=DESKTOP-MURAT\SQLEXPRES;";
            connectionString += $"Database=DB_MURAT_VAREN";
            return connectionString;
        }
        // pc connection

        //public static string GetConnectionString()
        //{
        //    string connectionString = "user id = sa;";
        //    connectionString += "Password = pxl;";
        //    connectionString += $@"Server=DESKTOP-SEAUBM4\SQLEXPRES;";
        //    connectionString += $"Database=DB_MURAT_VAREN";
        //    return connectionString;
        //}
    }
}
