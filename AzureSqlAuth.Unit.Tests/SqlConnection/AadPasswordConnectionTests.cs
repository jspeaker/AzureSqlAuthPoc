using System;
using AzureSqlAuth.SqlConnection;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AzureSqlAuth.Tests.SqlConnection
{
    [TestClass]
    public class AadPasswordConnectionTests
    {
        private readonly string _connectionString = new AzureSqlAuth.Configuration.Configuration().ConnectionString("adventure-works");

        [TestMethod, TestCategory("Functional")]
        public void GivenConnectionStringConnectionShouldOpen()
        {
            using (IConnection connection = new AadPasswordConnection(_connectionString))
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
                new AadPasswordConnection(connectionString);
            };
            action.ShouldThrow<Exception>();
        }
    }
}
