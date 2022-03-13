using Store.Feature.Implementation;
using Store.Feature.Interface;
using Store.Foundation.Implementation;
using Store.Foundation.Interface;
using StoreInSqlDb.Foundation.Implementation;
using StoreInSqlDb.Foundation.Interface;
using StoreInSqlDb.Project.Implementation;
using StoreInSqlDb.Project.Interface;

namespace StoreInSqlDb
{
    class Program
    {
        static void Main(string[] args)
        {
            IApplicationConfig applicationConfig = new ApplicationConfig();
            IWriteDataIntoFile writeDataIntoFile = new WriteDataIntoFile(applicationConfig);
            IReadDataFromCsvFile readDataFromCsvFile = new ReadDataFromCsvFile(applicationConfig, writeDataIntoFile);
            ISqlParametersModel sqlParametersModelForStoreProduct = new SqlParametersModelForStoreProduct();
            ISqlParametersModel sqlParametersModelForProductCdnUrl = new SqlParametersModelForProductCdnUrl();
            IDataManipulation dataManipulation = new DataManipulation(applicationConfig);

            IStoreProduct storeProduct = new StoreProduct(applicationConfig, writeDataIntoFile, 
                                        readDataFromCsvFile, sqlParametersModelForStoreProduct,
                                        sqlParametersModelForProductCdnUrl, dataManipulation);
            storeProduct.InsertandCreateJsonFile();
        }
    }
}
