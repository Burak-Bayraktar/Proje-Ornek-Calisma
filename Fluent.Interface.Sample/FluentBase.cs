using Dapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

namespace Fluent.Interface.Sample
{
    public class FluentBase
    {
        List<string> tableColumns;
        string tableName;
        internal string conStr = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;

        internal static string GetTableNameFromAttribute(Type className)
        {
            MemberInfo info = className;
            string s = "";
            object[] atts = info.GetCustomAttributes(true);

            for (int i = 0; i < atts.Length; i++)
            {
                if (atts[i].GetType() == typeof(TableAttribute))
                    s = ((TableAttribute)atts[i]).Name;
            }

            return s;
        }

        internal static void GetTableColumnNames()
        {
            var command = string.Format("SELECT TOP 0 * FROM Products;");
            using (SqlConnection connection = new SqlConnection(conStr))
            {
                using (var reader = connection.ExecuteReader(command))
                {
                    reader.Read();
                    var table = reader.GetSchemaTable();
                    //reader.
                    foreach (DataRow row in table.Rows)
                    {
                        foreach (string column in row.ItemArray)
                        {
                            Console.WriteLine(row.ItemArray[0]);
                            break;
                        }
                    }
                }
            }
        }
        internal static string[] GetTableNames()
        {
            var command = "SELECT name FROM sys.Tables;";
            List<string> tables = new List<string>();
            using (SqlConnection connection = new SqlConnection(conStr))
            {
                connection.Open();
                using (var reader = connection.ExecuteReader(command))
                {
                    while (reader.Read())
                    {
                        tables.Add(reader["name"].ToString());
                    }
                }
            }

            return tables.ToArray();

        }

        /// <summary>
        /// Create a dynamic INSERT method.
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="tableColumns"></param>
        /// <returns></returns>
        internal string SetInsertMethod(string tableName, List<string> tableColumns)
        {
            string commandInit;
            string s = "", _s = "";

            for (int i = 0; i < tableColumns.Count; i++)
            {
                _s += tableColumns[i] + ", ";
                s += "@" + tableColumns[i] + ", ";
            }

            _s = _s.Remove(_s.Length - 2);
            s = s.Remove(s.Length - 2);

            commandInit = string.Format("INSERT INTO {0} ({1}) Values ({2})", tableName, _s, s);

            return commandInit;
        }
    }
}