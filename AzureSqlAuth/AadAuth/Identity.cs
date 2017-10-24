using System.Security.Cryptography.X509Certificates;
using AzureSqlAuth.Configuration;
using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace AzureSqlAuth.AadAuth
{
    public interface IIdentity
    {
        ClientAssertionCertificate Assertion();
    }

    public class Identity : IIdentity
    {
        private readonly IConfiguration _configuration;

        public Identity() : this(new Configuration.Configuration()) { }

        public Identity(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public ClientAssertionCertificate Assertion()
        {
            return new ClientAssertionCertificate(new Configuration.Configuration().ClientId(), Certificate(StoreLocation.CurrentUser));
        }

        private X509Certificate2 Certificate(StoreLocation storeLocation)
        {
            X509Certificate2 certificate;
            var store = new X509Store(storeLocation);
            try
            {
                store.Open(OpenFlags.ReadOnly);
                certificate = store.Certificates.Find(X509FindType.FindByThumbprint, _configuration.CertificateThumbprint(), false)[0];
            }
            finally
            {
                store.Close();
            }
            return certificate;
        }

    }
}