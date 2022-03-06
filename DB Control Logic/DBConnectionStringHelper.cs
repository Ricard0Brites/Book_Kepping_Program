using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Kepping.DB_Control_Logic
{
    public static class DBConnectionStringHelper
    {
        public static string ConnectionValue(string name)
        {
            try
            {
                return ConfigurationManager.ConnectionStrings[name].ConnectionString;
            }
            catch (NullReferenceException)
            {
                return null;
            };
        }
    }
}
