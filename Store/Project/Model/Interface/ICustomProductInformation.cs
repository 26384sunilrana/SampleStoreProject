using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Project.Model.Interface
{
    public interface ICustomProductInformation
    {
        public string Name { get; set; }
        public string Ean { get; set; }
        public string CdnUrl { get; set; }
    }
}
