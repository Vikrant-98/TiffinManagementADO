using System.Data.SqlClient;

namespace TiffinManagement.DatabaseServices
{
    public class DBContext
    {
    }

    public class DBService : IDisposable
    {
        public SqlConnection Connection { get; }

        public DBService(string connectionString)
        {
            Connection = new SqlConnection(connectionString);
        }
        public void Dispose() => Connection.Dispose();
    }
}
