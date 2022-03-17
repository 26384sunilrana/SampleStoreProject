using System.IO;
using UsingEntityFramework.Feature.Interface;
using UsingEntityFramework.Foundation.Interface;

namespace UsingEntityFramework.Implementation.Feature
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
