using Store.Feature.Interface;
using Aspose.Cells;
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

        public void FetchDataInJsonFormat(string inputFilePath, string outFilePath)
        {
            Workbook workbook;
            Cell lastCell;

            LoadCsvFile(out workbook, out lastCell, inputFilePath);

            string data = SetExportToJsonOption(workbook, lastCell);

            _writeDataIntoFile.WriteIntoJsonFile(data, outFilePath);
        }
        private void LoadCsvFile(out Workbook workbook, out Cell lastCell, string inputFilePath)
        {

            Aspose.Cells.LoadOptions loadOptions = new Aspose.Cells.LoadOptions(LoadFormat.Csv);

            workbook = new Workbook(_applicationConfig.GetConfigValueByKey(inputFilePath), loadOptions);
            lastCell = workbook.Worksheets[0].Cells.LastCell;
        }
        private string SetExportToJsonOption(Workbook workbook, Cell lastCell)
        {

            Aspose.Cells.Utility.ExportRangeToJsonOptions options = new Aspose.Cells.Utility.ExportRangeToJsonOptions();
            Aspose.Cells.Range range = workbook.Worksheets[0].Cells.CreateRange(0, 0, lastCell.Row + 1, lastCell.Column + 1);
            string data = Aspose.Cells.Utility.JsonUtility.ExportRangeToJson(range, options);
            return data;
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
