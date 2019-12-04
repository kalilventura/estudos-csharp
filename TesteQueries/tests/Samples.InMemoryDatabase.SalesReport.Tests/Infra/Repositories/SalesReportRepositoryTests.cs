using Dapper;
using FluentAssertions;
using Samples.InMemoryDatabase.SalesReport.App.Infra.Repositories;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Samples.InMemoryDatabase.SalesReport.Tests.Infra.Repositories
{
    public class SalesReportRepositoryTests : RepositoryTests
    {
        private readonly ISalesReportRepository salesReportsRepository;
        public SalesReportRepositoryTests() => this.salesReportsRepository = new SalesReportRepository(this.Context);

        [Fact]
        public async Task GivenThatSellerExistsInTheDatabaseWhenToRequestASalesReportByItsIdentifierThenTheReportShouldContainOnlySalesOfThisSameSeller()
        {
            var identifier = await this.Context.Connection.QueryFirstOrDefaultAsync<string>(@"SELECT Identifier FROM Sellers");

            var records = await this.salesReportsRepository.GetSalesReportFromSallerByIdentifierAsync(identifier);

            records.ToList().ForEach(record => record.SellerIdentifier.Should().BeEquivalentTo(identifier));

            InMemoryDatabase.Runner.MigrateDown(1);
        }

        [Fact]
        public async Task GivenThatSellerExistsInTheDatabaseWhenToRequestSalesReportByItsIdentifierThenShouldContainOnTheTheReportTheTotalAmountEachSale()
        {
            var identifier = await this.Context.Connection.QueryFirstOrDefaultAsync<string>(@"SELECT Identifier FROM Sellers");

            var records = await this.salesReportsRepository.GetSalesReportFromSallerByIdentifierAsync(identifier);

            records.ToList().ForEach(record => record.TotalSaleAmount.Should().Be(record.SoldAmount * record.UnitPrice,
                                    because: "The TotalSaleAmount should be the multiplication of the quantity by the unit price"));

            InMemoryDatabase.Runner.MigrateDown(1);
        }
    }
}