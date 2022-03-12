using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Feature.Interface
{
    public interface IWriteDataIntoFile
    {
        void WriteIntoJsonFile(string data, string outFilePath);
    }
}
