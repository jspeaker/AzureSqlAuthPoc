using System.Data;

namespace AzureSqlAuth.SqlConnection
{
    public class AadPasswordConnection : IConnection
    {
        private readonly IDbConnection _dbConnection;

        public AadPasswordConnection(string connectionString) : this(new System.Data.SqlClient.SqlConnection(connectionString)) { }

        public AadPasswordConnection(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public void Open()
        {
            _dbConnection.Open();
        }

        public void Dispose()
        {
            if (_dbConnection == null || _dbConnection.State.Equals(ConnectionState.Closed)) return;
            _dbConnection.Dispose();
        }
    }
}
