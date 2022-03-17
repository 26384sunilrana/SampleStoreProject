using UsingEntityFramework.Project.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsingEntityFramework.Feature.Interface;
using UsingEntityFramework.Foundation.Model.Implementation;

namespace UsingEntityFramework.Project.Implementation
{
    public class ExportMergedObject : IExportMergedObject
    {
        private ICombinedResultOfProductAndCdn _combinedResultOfProductAndCdn;
        private IWriteDataIntoFile _writeDataIntoFile;

        public ExportMergedObject(ICombinedResultOfProductAndCdn combinedResultOfProductAndCdn, IWriteDataIntoFile writeDataIntoFile)
        {
            _combinedResultOfProductAndCdn = combinedResultOfProductAndCdn;
            _writeDataIntoFile = writeDataIntoFile;
        }

        public void ExportToJsonFile()
        {
            string jsonResult = ConvertIntoJsonFormat();

            _writeDataIntoFile.WriteIntoJsonFile(jsonResult, UsingEntityFramework.Foundation.Constants.GlobalConstants.SUMMARY_JSON_EXPORT);
        }

        private string ConvertIntoJsonFormat()
        {
            List<StoreProductWithCdnUrlData> storeProductWithCdnUrlDatasList = _combinedResultOfProductAndCdn.MergeStoreProductAndProductCdn();

            string jsonResult = Newtonsoft.Json.JsonConvert.SerializeObject(storeProductWithCdnUrlDatasList);
            Console.WriteLine(jsonResult);
            return jsonResult;
        }
    }
}
