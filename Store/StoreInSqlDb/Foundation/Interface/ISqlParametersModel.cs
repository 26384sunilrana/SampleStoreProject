using System.Data.SqlClient;

namespace StoreInSqlDb.Foundation.Interface
{
    public interface ISqlParametersModel
    {
        SqlParameter[] CreateSqlParameters(string ean, string name, string description);
    }
}
