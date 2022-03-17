using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsingEntityFramework.Foundation.TableModels
{
    public class ProductCDNUrl
    {
        public int ID { get; set; }
        public string Ean { get; set; }
        public string CdnUrl { get; set; }
        public string LatestUpdated{ get; set; }
    }
}
