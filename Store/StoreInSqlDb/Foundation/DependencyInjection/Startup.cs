using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Store.Feature.Implementation;
using Store.Feature.Interface;
using Store.Foundation.Implementation;
using Store.Foundation.Interface;
using StoreInSqlDb.Foundation.Implementation;
using StoreInSqlDb.Foundation.Interface;
using StoreInSqlDb.Project.Implementation;
using StoreInSqlDb.Project.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreInSqlDb.Foundation.EntityFramework
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IApplicationConfig, ApplicationConfig>();
            services.AddScoped<IWriteDataIntoFile, WriteDataIntoFile>();
            services.AddScoped<IReadDataFromCsvFile, ReadDataFromCsvFile>();
            services.AddScoped<IDataManipulation, DataManipulation>();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureServices((_, services) =>
                    services.AddScoped<IApplicationConfig, ApplicationConfig>()
                            .AddScoped<IWriteDataIntoFile, WriteDataIntoFile>()
                           .AddScoped<IReadDataFromCsvFile, ReadDataFromCsvFile>()
                           .AddScoped<IDataManipulation, DataManipulation>()
                           .AddScoped<ISqlParametersProductCdnUrlModel, SqlParametersModelForProductCdnUrl>()
                           .AddScoped<ISqlParametersModel, SqlParametersModelForStoreProduct>()
                           .AddScoped< IStoreProduct, StoreProduct>());
        }
    }
}
