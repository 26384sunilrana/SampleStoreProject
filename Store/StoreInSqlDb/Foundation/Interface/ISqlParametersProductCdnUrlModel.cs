using System.Data.SqlClient;

namespace StoreInSqlDb.Foundation.Interface
{
    public interface ISqlParametersProductCdnUrlModel
    {
        SqlParameter[] CreateSqlParameters(string ean, string cdn, string description);
    }
}
