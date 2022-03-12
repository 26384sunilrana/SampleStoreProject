using Store.Feature.Interface;
using Store.Foundation.Constants;
using Store.Project.Interface;
using Store.Project.Model.Implementation;
using Store.Project.Model.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Store.Project.Implementation
{
    public class StoreProcuctCdn : IStoreProcuctCdn
    {
        private IReadDataFromCsvFile _readDataFromCsvFile;
        private List<ICustomProductInformation> _customProductInformationList;
        private string _storeInputFilePath = string.Empty;
        private string _productInputFilePath = string.Empty;
        private string _outputFilePath = string.Empty;
        private IWriteDataIntoFile _writeDataIntoFile;

        public StoreProcuctCdn(IReadDataFromCsvFile readDataFromCsvFile, List<ICustomProductInformation> customProductInformationList, 
                               string storeInputFilePath, string productInputFilePath, string outputFilepath, IWriteDataIntoFile writeDataIntoFile)
        {
            _readDataFromCsvFile = readDataFromCsvFile;
            _customProductInformationList = customProductInformationList;
            _storeInputFilePath = storeInputFilePath;
            _productInputFilePath = productInputFilePath;
            _outputFilePath = outputFilepath;
            _writeDataIntoFile = writeDataIntoFile;
        }
        public bool CreateStoreProductCdn()
        {
            bool result = true;
            
            try
            {
                XElement storeData = GetXmlDataforGivenField(_storeInputFilePath, GlobalConstants.EAN, GlobalConstants.NAME, GlobalConstants.DESCRIPTION);
                XElement productCdnData = GetXmlDataforGivenField(_productInputFilePath, GlobalConstants.EAN, GlobalConstants.CDN, GlobalConstants.DATE);

                FillFromStoreDataIntoCustomList(storeData);

                UpdateDataFromProductCdn(productCdnData);

                SanatizeAndWriteIntoJsonFile();

            }
            catch (Exception ex) {
                result = false;
                Console.WriteLine(ex.Message);
            }

            return result;
        }

        private void SanatizeAndWriteIntoJsonFile()
        {
            _customProductInformationList.RemoveAt(0);

            var json = JsonSerializer.Serialize(_customProductInformationList);

            _writeDataIntoFile.WriteIntoJsonFile(json, _outputFilePath);
        }

        private void UpdateDataFromProductCdn(XElement productCdnData)
        {
            foreach (var eachCustomProductInformation in _customProductInformationList)
            {
                IEnumerable<XElement> productList = from element in productCdnData.Elements("Product")
                                                    where (string)element.Element(GlobalConstants.EAN) == eachCustomProductInformation.Ean
                                                    select element;
                foreach (XElement eachProductElement in productList.Descendants())
                {
                    if (eachProductElement.Name == GlobalConstants.CDN)
                        eachCustomProductInformation.CdnUrl = eachProductElement.Value;
                }
            }
        }

        private void FillFromStoreDataIntoCustomList(XElement storeData)
        {
            IEnumerable<XElement> productList = from element in storeData.Elements("Product") select element;
            foreach (XElement eachProduct in productList)
            {
                ICustomProductInformation customProductInformation = new CustomProductInformation();

                foreach (XElement eachProductElement in eachProduct.Descendants())
                {
                    if (eachProductElement.Name == GlobalConstants.NAME)
                        customProductInformation.Name = eachProductElement.Value;
                    else if (eachProductElement.Name == GlobalConstants.EAN)
                        customProductInformation.Ean = eachProductElement.Value;
                }
                _customProductInformationList.Add(customProductInformation);
            }
        }

        private XElement GetXmlDataforGivenField(string inputFilePath, string field1, string field2, string field3)
        {
            return _readDataFromCsvFile.ReadCsvFileIntoXml(inputFilePath, field1, field2, field3);
        }
    }
}
