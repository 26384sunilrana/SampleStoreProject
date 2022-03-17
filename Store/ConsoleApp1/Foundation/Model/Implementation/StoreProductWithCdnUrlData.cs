using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsingEntityFramework.Foundation.Model.Implementation
{
    public class StoreProductWithCdnUrlData
    {
        public string Ean { get; set; }
        public string Name { get; set; }
        public string CdnUrl { get; set; }        
        public string Description { get; set; }
        public string LatestUpdated { get; set; }
    }
}
