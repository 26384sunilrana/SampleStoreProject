using StoreInSqlDb.Foundation.Interface;
using System.Data;
using System.Data.SqlClient;

namespace StoreInSqlDb.Foundation.Implementation
{
    public class SqlParametersModelForProductCdnUrl : ISqlParametersProductCdnUrlModel
    {
        public SqlParameter[] CreateSqlParameters(string ean, string cdnUrl, string latestUpdated)
        {
            SqlParameter[] parameters = new SqlParameter[]
                   {
                        new SqlParameter() {ParameterName = "@ean", SqlDbType = SqlDbType.NVarChar, Direction = ParameterDirection.Input, Value= ean},
                        new SqlParameter() {ParameterName = "@cdnUrl", SqlDbType = SqlDbType.NVarChar, Direction = ParameterDirection.Input, Value = cdnUrl},
                        new SqlParameter() {ParameterName = "@latestUpdated", SqlDbType = SqlDbType.NVarChar, Direction = ParameterDirection.Input, Value = latestUpdated}
                   };

            return parameters;
        }
    }
}
