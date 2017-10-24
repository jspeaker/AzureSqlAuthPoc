using System;
using AzureSqlAuth.AadAuth;
using AzureSqlAuth.SqlConnection;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AzureSqlAuth.Tests.SqlConnection
{
    [TestClass]
    public class AadTokenConnectionTests
    {
        private readonly string _connectionString = new AzureSqlAuth.Configuration.Configuration().ConnectionString("adventure-works-token");

        [TestMethod, TestCategory("Functional")]
        public void GivenSecretBasedAuthNConnectionShouldOpen()
        {
            using (IConnection connection = new AadTokenConnection(_connectionString, new AadSecretAuthN()))
            {
                Action action = () =>
                {
                    // ReSharper disable once AccessToDisposedClosure
                    connection.Open();
                };

                action.ShouldNotThrow();
            }
        }

        [TestMethod, TestCategory("Functional")]
        public void GivenCertificateBasedAuthNTokenConnectionShouldOpen()
        {
            using (IConnection connection = new AadTokenConnection(_connectionString, new AadTokenAuthN()))
            {

                Action action = () =>
                {
                    // ReSharper disable once AccessToDisposedClosure
                    connection.Open();
                };

                action.ShouldNotThrow();
            }
        }

        [TestMethod, TestCategory("Unit")]
        public void GivenBadConnectionStringShouldThrow()
        {
            const string connectionString = "foo";

            Action action = () =>
            {
                // ReSharper disable once ObjectCreationAsStatement
                new AadTokenConnection(connectionString, new AadTokenAuthN());
            };
            action.ShouldThrow<Exception>();
        }
    }
}