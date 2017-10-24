using System.Threading.Tasks;
using AzureSqlAuth.Configuration;
using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace AzureSqlAuth.AadAuth
{
    public class AadSecretAuthN : IAadAuthN
    {
        private readonly AuthenticationContext _authenticationContext;
        private readonly ClientCredential _clientCredential;
        private readonly string _resource;

        public AadSecretAuthN() : this(new Configuration.Configuration()) { }

        public AadSecretAuthN(IConfiguration configuration) : 
            this(new AuthenticationContext(configuration.Authority()), new ClientCredential(configuration.ClientId(), configuration.ClientSecret()),  configuration.AdventureWorksDbResource()) {  }

        public AadSecretAuthN(AuthenticationContext authenticationContext, ClientCredential clientCredential, string resource)
        {
            _authenticationContext = authenticationContext;
            _clientCredential = clientCredential;
            _resource = resource;
        }

        public async Task<AuthenticationResult> AuthenticationResult()
        {
            return await _authenticationContext.AcquireTokenAsync(_resource, _clientCredential);
        }
    }
}