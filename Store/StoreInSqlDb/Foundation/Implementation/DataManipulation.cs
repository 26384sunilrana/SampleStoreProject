using Newtonsoft.Json;
using Store.Foundation.Constants;
using Store.Foundation.Interface;
using StoreInSqlDb.Foundation.Interface;
using System;
using System.Data;
using System.Data.SqlClient;

namespace StoreInSqlDb.Foundation.Implementation
{
    public class DataManipulation : IDataManipulation
    {
        private IApplicationConfig _applicationConfig;
        private string _connectionString = string.Empty;
        public DataManipulation(IApplicationConfig applicationConfig)
        {
            _applicationConfig = applicationConfig;
            _connectionString = _applicationConfig.GetConfigValueByKey(GlobalConstants.CONNECTION_STRING);
        }

        public void ExecuteStoreProcedure(string storProcedureName, SqlParameter[] parameters)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(storProcedureName, connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    foreach (SqlParameter eachSqlParameter in parameters)
                    {
                        cmd.Parameters.Add(eachSqlParameter);
                    }

                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public string GetDataFromSp(string storProcedureName)
        {
            SqlDataReader sqlDataReader = null;
            string convertToJson = string.Empty;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(storProcedureName, connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    connection.Open();
                    sqlDataReader = cmd.ExecuteReader();
                    convertToJson = SqlDatoToJson(sqlDataReader);
                }
            }
            return convertToJson;
        }

        private String SqlDatoToJson(SqlDataReader dataReader)
        {
            var dataTable = new DataTable();
            dataTable.Load(dataReader);
            string JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(dataTable);
            return JSONString;
        }
    }
}
