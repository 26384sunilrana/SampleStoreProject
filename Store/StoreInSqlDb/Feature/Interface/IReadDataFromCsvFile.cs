using System.Xml.Linq;

namespace Store.Feature.Interface
{
    public interface IReadDataFromCsvFile
    {        
        XElement ReadCsvFileIntoXml(string inputFilePath, string field1, string field2, string field3);
    }
}
