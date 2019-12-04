using NSubstitute;
using Samples.InMemoryDatabase.SalesReport.App.Infra;

namespace Samples.InMemoryDatabase.SalesReport.Tests.Infra.Repositories
{
    public abstract class RepositoryTests
    {
        protected RepositoryTests()
        {
            InMemoryDatabase.CreateTable();
            
            this.Context = Substitute.For<IDatabaseContext>();
            this.Context.Connection.Returns(InMemoryDatabase.Connection);
        }

        protected IDatabaseContext Context { get; }
    }
}
