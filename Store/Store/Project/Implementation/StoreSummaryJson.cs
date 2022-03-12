using Store.Feature.Implementation;
using Store.Feature.Interface;
using Store.Foundation.Implementation;
using Store.Foundation.Interface;
using Store.Project.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Project.Implementation
{
    public class StoreSummaryJson : IStoreSummaryJson
    {
        private IReadDataFromCsvFile _ReadDataFromCsvFile;
        private string _inputFilePath, _outputFilePath;

        public StoreSummaryJson(IReadDataFromCsvFile readDataFromCsvFile, string inputFilePath, string outputFilepath)
        {
            _ReadDataFromCsvFile = readDataFromCsvFile;
            _inputFilePath = inputFilePath;
            _outputFilePath = outputFilepath;
        }
        public bool CreateStoreSummaryJson()
        {
            bool result = true;

            try
            {
                _ReadDataFromCsvFile.FetchDataInJsonFormat(_inputFilePath, _outputFilePath);
            }
            catch (Exception ex)
            {
                result = false;
                Console.WriteLine(ex.Message);
            }



            return result;
        }
    }
}
