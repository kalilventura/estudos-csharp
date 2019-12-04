using System;
using System.Data;

namespace Samples.InMemoryDatabase.SalesReport.App.Infra
{
    public interface IDatabaseContext : IDisposable
    {
        IDbConnection Connection { get; }
    }
}
