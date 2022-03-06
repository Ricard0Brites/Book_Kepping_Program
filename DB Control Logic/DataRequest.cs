using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Dapper;
using System.Data.SqlClient;

namespace Book_Kepping.DB_Control_Logic
{
    public class DataRequest
    {
        public static bool InsertBookKeepingEntry( bool movementType, string transactionDescription, float transactionAmmount, DateTime date, string supportingFilesPath)
        {
            //makes the true or false become 1 or 0
            int movementType2 = 0;
            if (movementType)
            {
                movementType2 = 1;
            }

            //connects to the database and writes data
            if(DBConnectionStringHelper.ConnectionValue(Database_Info.GetDatabaseName()) != null)
            {
                using (IDbConnection connection = new SqlConnection(DBConnectionStringHelper.ConnectionValue(Database_Info.GetDatabaseName())))
                {
                    int id = 0;
                    try
                    {
                        var idt = connection.Query<int>($"SELECT MAX(ID)FROM [{Database_Info.GetDatabaseName()}].[dbo].{Database_Info.GetCashMethodTableName()};");
                        id = idt.First();
                    }
                    catch(Exception)
                    {
                        id = 0;
                    }
                    connection.Execute($"INSERT INTO [{Database_Info.GetDatabaseName()}].[dbo].{Database_Info.GetCashMethodTableName()} (ID, Movement_Type, [Description], Amount, [Date], [Supporting_Evidence_Path]) VALUES ({id + 1}, {movementType2}, '{transactionDescription}', ({transactionAmmount}), '{date.Year + date.Month + date.Day}', '{supportingFilesPath}');");
                    GC.Collect();
                    return true;
                }
            }
            else
            {
                GC.Collect();
                return false;
            }
        }

        public static bool TestDatabaseConnection()
        {
            if(DBConnectionStringHelper.ConnectionValue(Database_Info.GetDatabaseName()) != null)
            {
                //database connection
                using IDbConnection connection = new SqlConnection(DBConnectionStringHelper.ConnectionValue(Database_Info.GetDatabaseName()));

                //creates table, inserts data, gets data and drops table
                connection.Execute($"CREATE TABLE [{Database_Info.GetDatabaseName()}].[dbo].TestTable(id int); INSERT INTO [{Database_Info.GetDatabaseName()}].[dbo].TestTable (id) VALUES (1), (2), (3);");
                var dataReturnedByQuery = connection.Query<int>($"select * from [{Database_Info.GetDatabaseName()}].[dbo].TestTable;");
                connection.Execute($"DROP TABLE [{Database_Info.GetDatabaseName()}].[dbo].TestTable;");

                //verifies that the connection is working
                if (dataReturnedByQuery.ElementAt(0) == 1 && dataReturnedByQuery.ElementAt(1) == 2 && dataReturnedByQuery.ElementAt(2) == 3)
                {
                    GC.Collect();
                    return true;
                }
            }
            GC.Collect();
            return false;
        }

        public static int GetLastCashID()
        {
            if (DBConnectionStringHelper.ConnectionValue(Database_Info.GetDatabaseName()) != null)
            {
                using IDbConnection connection = new SqlConnection(DBConnectionStringHelper.ConnectionValue(Database_Info.GetDatabaseName()));
                int id = 0;
                try
                {
                    var queryResults = connection.Query<int>($"SELECT MAX(ID)FROM [{Database_Info.GetDatabaseName()}].[dbo].{Database_Info.GetCashMethodTableName()};");
                    id = queryResults.First();
                }
                catch (Exception)
                {
                    id = 0;
                }
                return id;
            }
            return -1;
        }
    }
}