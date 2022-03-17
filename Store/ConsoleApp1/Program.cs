using UsingEntityFramework.Foundation.MainContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsingEntityFramework.Foundation.TableModels;
using UsingEntityFramework.Foundation.EntityFramework;
using Microsoft.Extensions.DependencyInjection;
using UsingEntityFramework.Project.Interface;

namespace UsingEntityFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            WithDependencyinjectionMapping(args);
        }

        private static void WithDependencyinjectionMapping(string[] args)
        {
            var host = Startup.CreateHostBuilder(args).Build();

            var serviceScope = host.Services.CreateScope();

            var provider = serviceScope.ServiceProvider;

            IExportMergedObject exportMergedObject = provider.GetRequiredService<IExportMergedObject>();

            exportMergedObject.ExportToJsonFile();
        }       
    }
}
