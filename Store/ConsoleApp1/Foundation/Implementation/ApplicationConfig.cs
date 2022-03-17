using System.Configuration;
using UsingEntityFramework.Foundation.Interface;

namespace UsingEntityFramework.Foundation.Implementation
{
    public class ApplicationConfig : IApplicationConfig
    {
        public string GetConfigValueByKey(string key)
        {            
            return ConfigurationManager.AppSettings[key];
        }
    }
}
