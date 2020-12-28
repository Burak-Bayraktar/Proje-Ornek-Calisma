using Dapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Text;

namespace Fluent.Interface.Sample
{
    public class FluentProduct : FluentBase
    {
        private StringBuilder command;
        private Product product;
        private PropertyInfo propertyInfo;
        private Type type = typeof(Product);
        private List<string> tableColumns;
        private string tableName;
        private DynamicParameters values = new DynamicParameters();

        public FluentProduct()
        {

            tableColumns = new List<string>();
            command = new StringBuilder();
            type = typeof(Product);
            product = new Product();
            tableName = GetTableNameFromAttribute(type);
        }

        public FluentProduct Id(int productId)
        {
            propertyInfo = type.GetProperty("ProductID");
            tableColumns.Add(propertyInfo.Name);

            values.Add(propertyInfo.Name, productId);

            return this;
        }

        public FluentProduct Name(string productName)
        {
            propertyInfo = type.GetProperty("ProductName");
            tableColumns.Add(propertyInfo.Name);

            values.Add(propertyInfo.Name, productName);

            return this;
        }

        public FluentProduct UnitPrice(decimal unitPrice)
        {
            propertyInfo = type.GetProperty("UnitPrice");
            tableColumns.Add(propertyInfo.Name);

            values.Add(propertyInfo.Name, unitPrice);

            return this;
        }

        public FluentProduct UnitsOnOrder(short unitsOnOrder)
        {
            propertyInfo = type.GetProperty("UnitsOnOrder");
            tableColumns.Add(propertyInfo.Name);

            values.Add(propertyInfo.Name, unitsOnOrder);

            return this;
        }

        public FluentProduct UnitsInStock(short unitsInStock)
        {
            propertyInfo = type.GetProperty("UnitsInStock");
            tableColumns.Add(propertyInfo.Name);

            values.Add(propertyInfo.Name, unitsInStock);

            return this;
        }

        public FluentProduct Discontinued(bool discontinued)
        {
            propertyInfo = type.GetProperty("Discontinued");
            tableColumns.Add(propertyInfo.Name);

            values.Add(propertyInfo.Name, discontinued);

            return this;
        }

        // Create
        /// <summary>
        /// Using to Create a new object that will Insert to the database. Make sure you using on last line in your code, otherwise it throws exception.
        /// </summary>
        /// <returns></returns>
        public FluentProduct Create()
        {
            using (SqlConnection connection = new SqlConnection(conStr))
            {                
                command.Append(SetInsertMethod(tableName, tableColumns));
                connection.Open();
                connection.Execute(command.ToString(), values);

                return this;
            }
        }
    }
}
