using System.Configuration;
namespace WebApi.Common
{
    public class ConfigHelper
    {
        public static string GetByKey(string key)
        {
            var value = System.Configuration.ConfigurationManager.AppSettings?[key];
            return value ?? string.Empty;
        }
    }
}
