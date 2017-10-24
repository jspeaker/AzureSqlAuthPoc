using AzureSqlAuth.AadAuth;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AzureSqlAuth.Tests.AadAuth
{
    [TestClass]
    public class AadSecretAuthNTests
    {
        [TestMethod, TestCategory("Functional")]
        public void ShouldReturnAccessToken()
        {
            var aadSecretAuthN = new AadSecretAuthN();
            var authenticationResult = aadSecretAuthN.AuthenticationResult().Result;
            authenticationResult.AccessToken.Should().NotBeNullOrWhiteSpace();
        }
    }
}