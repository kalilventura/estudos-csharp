using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using QueryResults = Samples.InMemoryDatabase.SalesReport.App.Domain.QueryResults;

namespace Samples.InMemoryDatabase.SalesReport.App.Infra.Repositories
{
    public interface ISalesReportRepository
    {
        Task<IEnumerable<QueryResults.SalesReport>> GetSalesReportFromAllSellersAsync();
        Task<IEnumerable<QueryResults.SalesReport>> GetSalesReportFromSallerByIdentifierAsync(string sallerIdentifier);
    }
}