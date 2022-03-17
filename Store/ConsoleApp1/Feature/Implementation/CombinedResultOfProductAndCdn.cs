using UsingEntityFramework.Foundation.Model.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsingEntityFramework.Foundation.MainContext;
using UsingEntityFramework.Foundation.TableModels;
using UsingEntityFramework.Feature.Interface;

namespace UsingEntityFramework.Implementation.Feature
{
    public class CombinedResultOfProductAndCdn : ICombinedResultOfProductAndCdn
    {
        public List<StoreProductWithCdnUrlData> MergeStoreProductAndProductCdn()
        {
            List<StoreProduct> storeProductsList = GetStorProductInformation();

            List<ProductCDNUrl> productCdnUrlsList = GetProductCdnInformation();

            return CombineProductAndCdnInformation(storeProductsList, productCdnUrlsList);


        }

        private List<StoreProductWithCdnUrlData> CombineProductAndCdnInformation(List<StoreProduct> storeProductsList, List<ProductCDNUrl> productCdnUrlsList)
        {
            //combine the Result
            List<StoreProductWithCdnUrlData> storeProductWithCdnUrlDatas = new List<StoreProductWithCdnUrlData>();

            foreach (StoreProduct eachStoreProduct in storeProductsList)
            {
                StoreProductWithCdnUrlData storeProductWithCdnUrlData = new StoreProductWithCdnUrlData
                {
                    Ean = eachStoreProduct.Ean,
                    Name = eachStoreProduct.Name,
                    Description = eachStoreProduct.Description
                };
                ProductCDNUrl productCdnUrl = productCdnUrlsList.FirstOrDefault(x => x.Ean == eachStoreProduct.Ean);

                if (!string.IsNullOrWhiteSpace(productCdnUrl.Ean))
                {
                    storeProductWithCdnUrlData.CdnUrl = productCdnUrl.CdnUrl;
                    storeProductWithCdnUrlData.LatestUpdated = productCdnUrl.LatestUpdated;
                }

                storeProductWithCdnUrlDatas.Add(storeProductWithCdnUrlData);
            }

            return storeProductWithCdnUrlDatas;
        }

        private List<ProductCDNUrl> GetProductCdnInformation()
        {
            //Get ProductCdn Information
            ProductCdnUrlContext productCdnUrlContext = new ProductCdnUrlContext();
            List<ProductCDNUrl> productCdnUrlsList = productCdnUrlContext.ProductCdnUrls.ToList<ProductCDNUrl>();
            return productCdnUrlsList;
        }

        private List<StoreProduct> GetStorProductInformation()
        {
            //Get StoreProduct Information
            StoreProductDbContext storeProductDbContext = new StoreProductDbContext();
            List<StoreProduct> storeProductsList = storeProductDbContext.StoreProducts.ToList<StoreProduct>();
            return storeProductsList;
        }
    }
}
