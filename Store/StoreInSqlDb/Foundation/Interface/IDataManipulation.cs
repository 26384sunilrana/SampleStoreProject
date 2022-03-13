using System.Data.SqlClient;

namespace StoreInSqlDb.Foundation.Interface
{
    public interface IDataManipulation
    {
        void ExecuteStoreProcedure(string storProcedureName, SqlParameter[] parameters);
        string GetDataFromSp(string storProcedureName);
    }
}
