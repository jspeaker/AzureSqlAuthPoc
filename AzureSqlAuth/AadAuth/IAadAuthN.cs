using System.Threading.Tasks;
using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace AzureSqlAuth.AadAuth
{
    public interface IAadAuthN
    {
        Task<AuthenticationResult> AuthenticationResult();
    }
}