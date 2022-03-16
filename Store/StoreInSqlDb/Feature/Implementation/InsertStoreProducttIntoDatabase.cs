using Store.Feature.Interface;
using Store.Foundation.Constants;
using StoreInSqlDb.Feature.Interface;
using StoreInSqlDb.Foundation.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Xml.Linq;

namespace StoreInSqlDb.Feature.Implementation
{
    public class InsertStoreProducttIntoDatabase : IInsertStoreProducttIntoDatabase
    {
        private IReadDataFromCsvFile _readDataFromCsvFile;
        private string _storeInputFilePath = string.Empty;
        private string _productInputFilePath;
        private ISqlParametersModel _sqlParametersModelForStoreProduct;
        private ISqlParametersProductCdnUrlModel _sqlParametersModelForProductCdn;
        private IDataManipulation _dataManipulation;
        private IWriteDataIntoFile _writeDataIntoFile;

        public InsertStoreProducttIntoDatabase(IReadDataFromCsvFile readDataFromCsvFile, string storeInputFilePath, string productInputFilePath,
                                                ISqlParametersModel sqlParametersModelForStoreProduct, ISqlParametersProductCdnUrlModel sqlParametersModelForProductCdn, 
                                                IDataManipulation dataManipulation, IWriteDataIntoFile writeDataIntoFile)
        {
            _readDataFromCsvFile = readDataFromCsvFile;
            _storeInputFilePath = storeInputFilePath;
            _productInputFilePath = productInputFilePath;
            _sqlParametersModelForStoreProduct = sqlParametersModelForStoreProduct;
            _sqlParametersModelForProductCdn = sqlParametersModelForProductCdn;
            _dataManipulation = dataManipulation;
            _writeDataIntoFile = writeDataIntoFile;
        }
        public bool TransferStoreDataIntoDatabase() 
        {
            bool result = true;
            try
            {
                XElement storeData = GetXmlDataforGivenField(_storeInputFilePath, GlobalConstants.EAN, GlobalConstants.NAME, GlobalConstants.DESCRIPTION);
                XElement productCdnData = GetXmlDataforGivenField(_productInputFilePath, GlobalConstants.EAN, GlobalConstants.CDN, GlobalConstants.DATE);

                FillFromStoreDataIntoDB(storeData);

                UpdateDataFromProductCdn(productCdnData);

            }
            catch (Exception ex) {
                result = false;
                Console.WriteLine(ex.Message);
            }
            return result;
        }

        public void CreateSummaryJsonFileForStorProduct()
        {
            string convertedJsonResult =  _dataManipulation.GetDataFromSp(GlobalConstants.SP_FULL_DATA_STORE_PROCEDURE);            
            _writeDataIntoFile.WriteIntoJsonFile(convertedJsonResult, GlobalConstants.SUMMARY_JSON_EXPORT);
        }

        public void CreateCustomJsonFileForProductCdnUrl()
        {
            string convertedJsonResult = _dataManipulation.GetDataFromSp(GlobalConstants.SP_GET_CUSTOM_PRODUCT_CDN_URL);            
            _writeDataIntoFile.WriteIntoJsonFile(convertedJsonResult, GlobalConstants.CUSTOM_JSON_EXPORT);
        }

       

        private void FillFromStoreDataIntoDB(XElement storeData)
        {
            IEnumerable<XElement> productList = from element in storeData.Elements(GlobalConstants.PRODUCT_ELEMENT) select element;
            
            int count = 0;
            
            foreach (XElement eachProduct in productList)
            {
                if (count == 0)
                {
                    count++;
                    continue;
                }
                string ean=string.Empty, name = string.Empty, description = string.Empty;

                foreach (XElement eachProductElement in eachProduct.Descendants())
                {
                    if (eachProductElement.Name == GlobalConstants.NAME)
                        name = eachProductElement.Value;
                    else if (eachProductElement.Name == GlobalConstants.EAN)
                        ean = eachProductElement.Value;
                    else if (eachProductElement.Name == GlobalConstants.DESCRIPTION)
                        description = eachProductElement.Value;

                }
                SqlParameter[] parameterList = _sqlParametersModelForStoreProduct.CreateSqlParameters(ean, name, description);
                _dataManipulation.ExecuteStoreProcedure(GlobalConstants.SP_INSERT_INTO_STOREPRODUCTS, parameterList);
            }
        }

        private void UpdateDataFromProductCdn(XElement productCdnData)
        {
            IEnumerable<XElement> productList = from element in productCdnData.Elements(GlobalConstants.PRODUCT_ELEMENT)                                                
                                                select element;
            int count = 0;

            foreach (XElement eachProduct in productList)
            {

                if (count == 0)
                {
                    count++;
                    continue;
                }
                string ean = string.Empty, cdnUrl = string.Empty, updatedDate = string.Empty;
                foreach (XElement eachProductElement in eachProduct.Descendants())
                {
                    if (eachProductElement.Name == GlobalConstants.CDN)
                        cdnUrl = eachProductElement.Value;
                    else if (eachProductElement.Name == GlobalConstants.EAN)
                        ean = eachProductElement.Value;
                    else if (eachProductElement.Name == GlobalConstants.DATE)
                        updatedDate = eachProductElement.Value;
                }

                SqlParameter[] parameterList = _sqlParametersModelForProductCdn.CreateSqlParameters(ean, cdnUrl, updatedDate);
                _dataManipulation.ExecuteStoreProcedure(GlobalConstants.SP_INSERT_INTO_PRODUCT_CDN, parameterList);
            }
        }

        private XElement GetXmlDataforGivenField(string inputFilePath, string field1, string field2, string field3)
        {
            return _readDataFromCsvFile.ReadCsvFileIntoXml(inputFilePath, field1, field2, field3);
        }
    }
}
