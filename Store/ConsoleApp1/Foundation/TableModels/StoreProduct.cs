using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsingEntityFramework.Foundation.TableModels
{
    public class StoreProduct
    {
        public int ID { get; set; }
        public string Ean{ get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
