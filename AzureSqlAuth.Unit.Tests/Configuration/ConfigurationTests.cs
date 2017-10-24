using AzureSqlAuth.Configuration;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AzureSqlAuth.Tests.Configuration
{
    [TestClass]
    public class ConfigurationTests
    {
        [TestMethod, TestCategory("Unit")]
        public void GivenCorrectConnectionStringNameShouldReturnConnectionString()
        {
            IConfiguration configuration = new AzureSqlAuth.Configuration.Configuration();
            var connectionString = configuration.ConnectionString("adventure-works");

            connectionString.Should().NotBeNullOrWhiteSpace();
        }

        [TestMethod, TestCategory("Unit")]
        public void GivenIncorrectConnectionStringNameShouldReturnEmptyString()
        {
            IConfiguration configuration = new AzureSqlAuth.Configuration.Configuration();
            var connectionString = configuration.ConnectionString("foo");

            connectionString.Should().BeEmpty();
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnAuthority()
        {
            IConfiguration configuration = new AzureSqlAuth.Configuration.Configuration();
            var authority = configuration.Authority();

            authority.Should().Be("https://login.microsoftonline.com/bcba9482-9fc1-4e9e-9f6d-23b86392354f");
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnClientId()
        {
            IConfiguration configuration = new AzureSqlAuth.Configuration.Configuration();
            var clientId = configuration.ClientId();

            clientId.Should().NotBeNullOrWhiteSpace();
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnClientSecret()
        {
            IConfiguration configuration = new AzureSqlAuth.Configuration.Configuration();
            var clientSecret = configuration.ClientSecret();

            clientSecret.Should().NotBeNullOrWhiteSpace();
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnAdventureWorksDbResource()
        {
            IConfiguration configuration = new AzureSqlAuth.Configuration.Configuration();
            var adventureWorksDbResource = configuration.AdventureWorksDbResource();

            adventureWorksDbResource.Should().NotBeNullOrWhiteSpace();
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldReturnCertificateThumbprint()
        {
            IConfiguration configuration = new AzureSqlAuth.Configuration.Configuration();
            var certificateThumbprint = configuration.CertificateThumbprint();

            certificateThumbprint.Should().NotBeNullOrWhiteSpace();
        }
    }
}