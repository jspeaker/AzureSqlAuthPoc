using System.Data;
using AzureSqlAuth.AadAuth;
using SqlClient = System.Data.SqlClient;

namespace AzureSqlAuth.SqlConnection
{
    public class AadTokenConnection : IConnection
    {
        private readonly IAadAuthN _authN;
        private readonly IDbConnection _dbConnection;

        public AadTokenConnection(string connectionString, IAadAuthN authN) : this(new SqlClient.SqlConnection(connectionString), authN) { }

        public AadTokenConnection(IDbConnection dbConnection, IAadAuthN authN)
        {
            _dbConnection = dbConnection;
            _authN = authN;
        }

        public void Open()
        {
            var authenticationResult = _authN.AuthenticationResult().Result;
            ((SqlClient.SqlConnection) _dbConnection).AccessToken = authenticationResult.AccessToken;
            _dbConnection.Open();
        }

        public void Dispose()
        {
            if (_dbConnection == null || _dbConnection.State.Equals(ConnectionState.Closed)) return;
            _dbConnection.Dispose();
        }
    }
}