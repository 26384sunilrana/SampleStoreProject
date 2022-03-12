using Store.Feature.Implementation;
using Store.Feature.Interface;
using Store.Foundation.Constants;
using Store.Foundation.Implementation;
using Store.Foundation.Interface;
using Store.Project.Implementation;
using Store.Project.Interface;
using Store.Project.Model.Interface;
using System;
using System.Collections.Generic;

namespace Store
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--------------Custom Process Started-------------");
            
            IApplicationConfig applicationConfig = new ApplicationConfig();
            IWriteDataIntoFile writeDataIntoFile = new WriteDataIntoFile(applicationConfig);
            IReadDataFromCsvFile readDataFromCsvFile = new ReadDataFromCsvFile(applicationConfig, writeDataIntoFile);
            List<ICustomProductInformation> customProductInformationList = new List<ICustomProductInformation>();

            IStoreProcuctCdn storeProcuctCdn = new StoreProcuctCdn(readDataFromCsvFile, customProductInformationList, 
                                                                   GlobalConstants.STORE_PRODUCT, GlobalConstants.LINK_TO_PRODUCT, 
                                                                   GlobalConstants.CUSTOM_JSON_EXPORT, writeDataIntoFile);
            storeProcuctCdn.CreateStoreProductCdn();
            Console.WriteLine("--------------Custom Process Ended-------------");

            Console.WriteLine("--------------Summary Process Ended-------------");
            IStoreSummaryJson storeSummaryJson = new StoreSummaryJson(readDataFromCsvFile, GlobalConstants.STORE_PRODUCT, GlobalConstants.SUMMARY_JSON_EXPORT);
            storeSummaryJson.CreateStoreSummaryJson();
            Console.WriteLine("--------------Summary Process Ended-------------");
            Console.ReadLine();

        }
    }
}
