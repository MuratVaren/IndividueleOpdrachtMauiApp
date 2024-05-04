using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibAutheur.Data.Framework
{
    static class LocalSettings
    {
        public static string GetConnectionString()
        {
            //string connectionString = "Trusted_Connection=True;;
            string connectionString = "user id = sa;";
            connectionString += "Password = pxl;";
            connectionString += $@"Server=DESKTOP-SEAUBM4\SQLEXPRES;";
            connectionString += $"Database=DB_MURAT_VAREN";
            return connectionString;
        }
    }
}
