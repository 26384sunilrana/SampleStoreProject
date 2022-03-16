using Store.Feature.Interface;
using Store.Foundation.Constants;
using Store.Foundation.Interface;
using StoreInSqlDb.Feature.Implementation;
using StoreInSqlDb.Feature.Interface;
using StoreInSqlDb.Foundation.Interface;
using StoreInSqlDb.Project.Interface;
using System;

namespace StoreInSqlDb.Project.Implementation
{
    public class StoreProduct : IStoreProduct
    {
        private IApplicationConfig _applicationConfig;
        private IWriteDataIntoFile _writeDataIntoFile;
        private IReadDataFromCsvFile _readDataFromCsvFile;
        private ISqlParametersModel _sqlParametersModelForStoreProducts;
        private ISqlParametersProductCdnUrlModel _sqlParametersModelForProductsCnd;
        private IDataManipulation _dataManipulation;

        public StoreProduct(IApplicationConfig applicationConfig, IWriteDataIntoFile writeDataIntoFile, IReadDataFromCsvFile readDataFromCsvFile,
                            ISqlParametersModel sqlParametersModelForStoreProducts, ISqlParametersProductCdnUrlModel sqlParametersModelForProductsCnd, IDataManipulation dataManipulation)
        {
            _applicationConfig = applicationConfig;
            _writeDataIntoFile = writeDataIntoFile;
            _readDataFromCsvFile = readDataFromCsvFile;
            _sqlParametersModelForStoreProducts = sqlParametersModelForStoreProducts;
            _sqlParametersModelForProductsCnd = sqlParametersModelForProductsCnd;
            _dataManipulation = dataManipulation;
            }
        public bool InsertandCreateJsonFile()
        {
            bool result = true;
            try
            {               
                IInsertStoreProducttIntoDatabase insertStoreProducttIntoDatabase = new InsertStoreProducttIntoDatabase(_readDataFromCsvFile, GlobalConstants.STORE_PRODUCT,
                                                                                    GlobalConstants.LINK_TO_PRODUCT, _sqlParametersModelForStoreProducts,
                                                                                    _sqlParametersModelForProductsCnd, _dataManipulation, _writeDataIntoFile);
                insertStoreProducttIntoDatabase.TransferStoreDataIntoDatabase();
                insertStoreProducttIntoDatabase.CreateSummaryJsonFileForStorProduct();
                insertStoreProducttIntoDatabase.CreateCustomJsonFileForProductCdnUrl();
            }
            catch (Exception ex) 
            {
                result = false;
                Console.WriteLine(ex.Message);
            }         

            return result;
        }
    }
}
