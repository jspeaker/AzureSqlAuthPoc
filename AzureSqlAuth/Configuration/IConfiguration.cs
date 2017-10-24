namespace AzureSqlAuth.Configuration
{
    public interface IConfiguration
    {
        string ConnectionString(string connectionStringName);
        string Authority();
        string ClientId();
        string ClientSecret();
        string AdventureWorksDbResource();
        string CertificateThumbprint();
    }
}