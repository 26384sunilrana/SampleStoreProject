using Store.Feature.Interface;
using Store.Foundation.Interface;
using System.IO;
using System.Xml.Linq;
using System.Linq;

namespace Store.Feature.Implementation
{
    public class ReadDataFromCsvFile : IReadDataFromCsvFile
    {
        private IApplicationConfig _applicationConfig;
        private IWriteDataIntoFile _writeDataIntoFile;

        public ReadDataFromCsvFile(IApplicationConfig applicationConfig, IWriteDataIntoFile writeDataIntoFile)
        {
            _applicationConfig = applicationConfig;
            _writeDataIntoFile = writeDataIntoFile;
        }

        public XElement ReadCsvFileIntoXml(string inputFilePath, string field1, string field2, string field3)
        {
            string[] source = File.ReadAllLines(_applicationConfig.GetConfigValueByKey(inputFilePath));
            XElement StoreData = new XElement("Root",
                from str in source
                let fields = str.Split(',')
                select new XElement("Product",
                       new XElement(field1, fields[0]),
                       new XElement(field2, fields[1]),
                       new XElement(field3, fields[2])
                                    )
                        );

            return StoreData;

        }
      
    }
}
