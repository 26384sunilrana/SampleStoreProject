namespace StoreInSqlDb.Feature.Interface
{
    public interface IInsertStoreProducttIntoDatabase
    {
        bool TransferStoreDataIntoDatabase();
        void CreateSummaryJsonFileForStorProduct();
        void CreateCustomJsonFileForProductCdnUrl();
    }
}
