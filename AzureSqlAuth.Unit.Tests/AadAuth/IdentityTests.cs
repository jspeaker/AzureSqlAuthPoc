using AzureSqlAuth.AadAuth;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AzureSqlAuth.Tests.AadAuth
{
    [TestClass]
    public class IdentityTests
    {
        [TestMethod, TestCategory("Functional")]
        public void ShouldReturnClientAssertionCertificate()
        {
            IIdentity identity = new Identity();
            var clientAssertionCertificate = identity.Assertion();

            clientAssertionCertificate.Certificate.Subject.Should().Contain("Jim Speaker");
        }
    }
}