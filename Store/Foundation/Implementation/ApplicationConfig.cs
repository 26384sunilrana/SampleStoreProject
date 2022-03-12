using Store.Foundation.Interface;
using System.Configuration;

namespace Store.Foundation.Implementation
{
    public class ApplicationConfig : IApplicationConfig
    {
        public string GetConfigValueByKey(string key)
        {            
            return ConfigurationManager.AppSettings[key];
        }
    }
}
