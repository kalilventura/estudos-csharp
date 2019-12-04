using System.Data;

namespace Samples.InMemoryDatabase.SalesReport.App.Infra
{
    public class DatabaseContext : IDatabaseContext
    {
        public DatabaseContext(IDbConnection connection)
        {
            this.Connection = connection;
            this.Connection.Open();
        }
        
        public IDbConnection Connection { get; }

        public void Dispose()
        {
            if (this.Connection.State != ConnectionState.Closed)
            {
                this.Connection.Close();
            }
        }
    }
}
