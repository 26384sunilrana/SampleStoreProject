using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsingEntityFramework.Foundation.TableModels;

namespace UsingEntityFramework.Foundation.MainContext
{
    public class StoreProductDbContext : DbContext
    {
        public StoreProductDbContext() : base("name=MallContext")
        {
            
        }
        public DbSet<StoreProduct> StoreProducts { get; set; }
    }
}
