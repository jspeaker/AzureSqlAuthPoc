using System.Configuration;

namespace AzureSqlAuth.Configuration
{
    public class Configuration : IConfiguration
    {
        public string ConnectionString(string connectionStringName)
        {
            var configurationElement = ConfigurationManager.ConnectionStrings[connectionStringName];
            if (configurationElement == null) return string.Empty;

            return configurationElement.ConnectionString;
        }

        public string Authority()
        {
            return $"{ConfigurationManager.AppSettings["ida:AadInstance"]}{ConfigurationManager.AppSettings["ida:TenantId"]}";
        }

        public string ClientId()
        {
            return ConfigurationManager.AppSettings["ida:ClientId"];
        }

        public string ClientSecret()
        {
            return ConfigurationManager.AppSettings["ida:ClientSecret"];
        }

        public string AdventureWorksDbResource()
        {
            return ConfigurationManager.AppSettings["AwDbResource"];
        }

        public string CertificateThumbprint()
        {
            return ConfigurationManager.AppSettings["CertificateThumbprint"];
        }
    }
}