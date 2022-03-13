using StoreInSqlDb.Foundation.Interface;
using System.Data;
using System.Data.SqlClient;

namespace StoreInSqlDb.Foundation.Implementation
{
    public class SqlParametersModelForStoreProduct : ISqlParametersModel
    {
        public SqlParameter[] CreateSqlParameters(string ean, string name, string description)
        {
            SqlParameter[] parameters = new SqlParameter[]
                   {
                        new SqlParameter() {ParameterName = "@ean", SqlDbType = SqlDbType.NVarChar, Direction = ParameterDirection.Input, Value= ean},
                        new SqlParameter() {ParameterName = "@name", SqlDbType = SqlDbType.NVarChar, Direction = ParameterDirection.Input, Value = name},
                        new SqlParameter() {ParameterName = "@description", SqlDbType = SqlDbType.NVarChar, Direction = ParameterDirection.Input, Value = description}
                   };

            return parameters;
        }
    }
}
