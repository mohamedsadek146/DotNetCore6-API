using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DotNetCore6.ViewModels;
using DotNetCore6.Helpers;
using DotNetCore6.ViewModels.Shared;

namespace DotNetCore6.Services.Helpers
{
    public static class ADOHelper
    {
        public static List<T> ExcuteStored<T>(string storedName, Dictionary<string, object> parameters = null) where T : new()
        {
            //string connectionString = ConfigurationHelper.GetConnectionString();
            string connectionString = ConfigurationHelper.GetConnectionString();
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand;
            SqlDataAdapter dataAdapter;
            DataTable dataTable;
            sqlCommand = new SqlCommand(storedName, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            if (parameters != null)
                foreach (var param in parameters)
                {
                    sqlCommand.Parameters.AddWithValue("@" + param.Key, param.Value);
                }
            dataAdapter = new SqlDataAdapter(sqlCommand);
            dataTable = new DataTable();
            dataAdapter.Fill(dataTable);

            return dataTable.ConvertTo<T>();
        }

        public static PagingViewModel<T> ExcutePaginationStored<T>(string storedName, int pageIndex, int pageSize, Dictionary<string, object> parameters) where T : new()
        {
            //string connectionString = ConfigurationHelper.GetConnectionString();
            string connectionString = ConfigurationHelper.GetConnectionString();
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand;
            SqlDataAdapter dataAdapter;
            DataSet dataSet;
            sqlCommand = new SqlCommand(storedName, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            if (parameters != null)
                foreach (var param in parameters)
                {
                    sqlCommand.Parameters.AddWithValue("@" + param.Key, param.Value);
                }
            dataAdapter = new SqlDataAdapter(sqlCommand);
            dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
            var result = dataSet.Tables[1].ConvertTo<T>();
            int records = int.Parse(dataSet.Tables[0].Rows[0][0].ToString());
            if (records <= pageSize || pageIndex <= 0) pageIndex = 1;
            int pages = (int)Math.Ceiling((double)records / pageSize);
            return new PagingViewModel<T>() { PageIndex = pageIndex, Pages = pages, PageSize = pageSize, Records = records, Items = result };
        }

        public static double ExcuteAggregateStored(string storedName, Dictionary<string, object> parameters)
        {
            SqlConnection sqlConnection = new SqlConnection(ConfigurationHelper.GetConnectionString()); ;
            SqlCommand sqlCommand;
            SqlDataAdapter dataAdapter;
            DataSet dataSet;
            sqlCommand = new SqlCommand(storedName, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            foreach (var param in parameters)
            {
                sqlCommand.Parameters.AddWithValue("@" + param.Key, param.Value);
            }
            dataAdapter = new SqlDataAdapter(sqlCommand);
            dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
            return (int)dataSet.Tables[0].Rows[0][0];
        }

        public static DataSet ExcuteStored(string storedName, Dictionary<string, object> parameters)
        {
            SqlConnection sqlConnection = new SqlConnection(ConfigurationHelper.GetConnectionString()); ;
            SqlCommand sqlCommand;
            SqlDataAdapter dataAdapter;
            DataSet dataSet;
            sqlCommand = new SqlCommand(storedName, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            foreach (var param in parameters)
            {
                sqlCommand.Parameters.AddWithValue("@" + param.Key, param.Value);
            }
            dataAdapter = new SqlDataAdapter(sqlCommand);
            dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
            return dataSet;
        }

        private static List<T> ConvertTo<T>(this DataSet dataSet) where T : new()
        {
            DataTable datatable = dataSet.Tables[0];
            List<T> Temp = new List<T>();
            try
            {
                List<string> columnsNames = new List<string>();
                foreach (DataColumn DataColumn in datatable.Columns)
                    columnsNames.Add(DataColumn.ColumnName);
                Temp = datatable.AsEnumerable().ToList().ConvertAll<T>(row => getObject<T>(row, columnsNames));
                return Temp;
            }
            catch
            {
                return Temp;
            }

        }
        private static List<T> ConvertTo<T>(this DataTable datatable) where T : new()
        {
            List<T> Temp = new List<T>();
            try
            {
                List<string> columnsNames = new List<string>();
                foreach (DataColumn DataColumn in datatable.Columns)
                    columnsNames.Add(DataColumn.ColumnName);
                Temp = datatable.AsEnumerable().ToList().ConvertAll<T>(row => getObject<T>(row, columnsNames));
                return Temp;
            }
            catch
            {
                return Temp;
            }

        }

        private static T getObject<T>(DataRow row, List<string> columnsName) where T : new()
        {
            T obj = new T();

            string columnname = "";
            string value = "";
            PropertyInfo[] Properties;
            Properties = typeof(T).GetProperties();
            foreach (PropertyInfo objProperty in Properties)
            {
                try
                {
                    columnname = columnsName.Find(name => name.ToLower() == objProperty.Name.ToLower());
                    if (!string.IsNullOrEmpty(columnname))
                    {
                        value = row[columnname].ToString();
                        if (!string.IsNullOrEmpty(value))
                        {
                            if (Nullable.GetUnderlyingType(objProperty.PropertyType) != null)
                            {
                                value = row[columnname].ToString().Replace("$", "").Replace(",", "");
                                objProperty.SetValue(obj, Convert.ChangeType(value, Type.GetType(Nullable.GetUnderlyingType(objProperty.PropertyType).ToString())), null);
                            }
                            else
                            {
                                value = row[columnname].ToString().Replace("%", "");
                                objProperty.SetValue(obj, Convert.ChangeType(value, Type.GetType(objProperty.PropertyType.ToString())), null);
                            }
                        }
                    }
                }
                catch
                {
                    //return obj;
                }
            }
            return obj;
        }

    }
}
