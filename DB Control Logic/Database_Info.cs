using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Kepping.DB_Control_Logic
{
    class Database_Info
    {
        private static string databaseName;
        private static string tableName;
        public static string GetDatabaseName()
        {
            return databaseName;
        }
        public static string GetCashMethodTableName()
        {
            return tableName;
        }
        public static void SetDatabaseName(string payload)
        {
            databaseName = payload;
        }
        public static void SetTableName(string payload)
        {
            tableName = payload;
        }
    }
}
