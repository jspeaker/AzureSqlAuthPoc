using System.Threading.Tasks;
using AzureSqlAuth.Configuration;
using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace AzureSqlAuth.AadAuth
{
    public class AadTokenAuthN : IAadAuthN
    {
        private readonly IIdentity _identity;
        private readonly IConfiguration _configuration;

        public AadTokenAuthN() : this(new Configuration.Configuration()) { }

        public AadTokenAuthN(IConfiguration configuration) : this(new Identity(configuration), configuration) { }

        public AadTokenAuthN(IIdentity identity, IConfiguration configuration)
        {
            _identity = identity;
            _configuration = configuration;
        }

        public async Task<AuthenticationResult> AuthenticationResult()
        {
            var clientAssertionCertificate = _identity.Assertion();
            var authenticationContext = new AuthenticationContext(_configuration.Authority());
            return await authenticationContext.AcquireTokenAsync(_configuration.AdventureWorksDbResource(), clientAssertionCertificate);
        }
    }
}