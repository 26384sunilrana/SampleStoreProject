using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Store.Feature.Interface
{
    public interface IReadDataFromCsvFile
    {
        void FetchDataInJsonFormat(string inputFilePath, string outFilePath);
        XElement ReadCsvFileIntoXml(string inputFilePath, string field1, string field2, string field3);
    }
}
