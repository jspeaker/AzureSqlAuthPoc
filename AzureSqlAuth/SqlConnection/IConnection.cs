using System;

namespace AzureSqlAuth.SqlConnection
{
    public interface IConnection : IDisposable
    {
        void Open();
    }
}