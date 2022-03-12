using Aspose.Cells;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Foundation.Interface
{
    public interface IApplicationConfig
    {
        string GetConfigValueByKey(string key);
    }
}
