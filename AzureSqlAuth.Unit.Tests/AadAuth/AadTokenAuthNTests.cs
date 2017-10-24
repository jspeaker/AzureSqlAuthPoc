using AzureSqlAuth.AadAuth;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AzureSqlAuth.Tests.AadAuth
{
    [TestClass]
    public class AadTokenAuthNTests
    {
        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnAccessToken()
        {
            var aadTokenAuthN = new AadTokenAuthN();
            var authenticationResult = aadTokenAuthN.AuthenticationResult().Result;
            authenticationResult.AccessToken.Should().NotBeNullOrWhiteSpace();
        }
    }
}