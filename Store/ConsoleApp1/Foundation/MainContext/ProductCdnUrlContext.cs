using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsingEntityFramework.Foundation.TableModels;

namespace UsingEntityFramework.Foundation.MainContext
{
    public class ProductCdnUrlContext : DbContext
    {
        public ProductCdnUrlContext() : base("name=MallContext")
        {
            
        }
        public DbSet<ProductCDNUrl> ProductCdnUrls { get; set; }
    }
}
