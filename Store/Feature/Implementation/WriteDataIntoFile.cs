using Store.Feature.Interface;
using Store.Foundation.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Feature.Implementation
{
    public class WriteDataIntoFile : IWriteDataIntoFile
    {
        private IApplicationConfig _applicationConfig;

        public WriteDataIntoFile(IApplicationConfig applicationConfig)
        {
            _applicationConfig = applicationConfig;
        }
        public  void WriteIntoJsonFile(string data, string outFilePath)
        {
            // Write from CSV to a JSON file
            File.WriteAllText(_applicationConfig.GetConfigValueByKey(outFilePath), data);
        }
    }
}
