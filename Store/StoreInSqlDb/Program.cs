using Microsoft.Extensions.DependencyInjection;
using Store.Feature.Implementation;
using Store.Feature.Interface;
using Store.Foundation.Implementation;
using Store.Foundation.Interface;
using StoreInSqlDb.Foundation.EntityFramework;
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
            

            WithDependencyinjectionMapping(args);

            //WithoutDependencyinjection();
           
        }

        private static void WithDependencyinjectionMapping(string[] args)
        {
            var host = Startup.CreateHostBuilder(args).Build();

            using var serviceScope = host.Services.CreateScope();

            var provider = serviceScope.ServiceProvider;

            var storeProduct = provider.GetRequiredService<IStoreProduct>();

            storeProduct.InsertandCreateJsonFile();
        }

        private static void WithoutDependencyinjection()
        {
            IApplicationConfig applicationConfig = new ApplicationConfig();
            IWriteDataIntoFile writeDataIntoFile = new WriteDataIntoFile(applicationConfig);
            IReadDataFromCsvFile readDataFromCsvFile = new ReadDataFromCsvFile(applicationConfig, writeDataIntoFile);
            ISqlParametersModel sqlParametersModelForStoreProduct = new SqlParametersModelForStoreProduct();
            ISqlParametersProductCdnUrlModel sqlParametersModelForProductCdnUrl = new SqlParametersModelForProductCdnUrl();
            IDataManipulation dataManipulation = new DataManipulation(applicationConfig);

            IStoreProduct storeProduct = new StoreProduct(applicationConfig, writeDataIntoFile,
                                        readDataFromCsvFile, sqlParametersModelForStoreProduct,
                                        sqlParametersModelForProductCdnUrl, dataManipulation);
            storeProduct.InsertandCreateJsonFile();
        }
    }
}
