using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using UsingEntityFramework.Feature.Interface;
using UsingEntityFramework.Foundation.Implementation;
using UsingEntityFramework.Foundation.Interface;
using UsingEntityFramework.Implementation.Feature;
using UsingEntityFramework.Project.Implementation;
using UsingEntityFramework.Project.Interface;

namespace UsingEntityFramework.Foundation.EntityFramework
{
    public class Startup
    {      

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureServices((_, services) =>
                    services.AddScoped<IApplicationConfig, ApplicationConfig>()
                            .AddScoped<IWriteDataIntoFile, WriteDataIntoFile>()
                           .AddScoped<IReadDataFromCsvFile, ReadDataFromCsvFile>()
                           .AddScoped<ICombinedResultOfProductAndCdn, CombinedResultOfProductAndCdn>()
                           .AddScoped<IExportMergedObject, ExportMergedObject>());
        }
    }
}
