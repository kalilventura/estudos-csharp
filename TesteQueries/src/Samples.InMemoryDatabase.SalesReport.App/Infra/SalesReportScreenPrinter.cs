using ConsoleTables;
using System.Collections.Generic;
using System.Linq;
using QueryResults = Samples.InMemoryDatabase.SalesReport.App.Domain.QueryResults;

namespace Samples.InMemoryDatabase.SalesReport.App.Infra
{
    public class SalesReportScreenPrinter
    {
        private readonly IList<QueryResults.SalesReport> salesReport;
        public SalesReportScreenPrinter(IEnumerable<QueryResults.SalesReport> salesReport) 
            => this.salesReport = salesReport.ToList();

        public void PrintReport()
        {
            var columns = this.GetReportColumns();
            var table = new ConsoleTable(columns);

            foreach (var line in this.salesReport)
            {
                table.AddRow(line.SaleIdentifier,
                             line.ProductName,
                             line.UnitPrice,
                             line.SoldAmount,
                             line.TotalSaleAmount,
                             line.SellerIdentifier,
                             line.SellerName,
                             line.SellerEmail);
            }

            table.Write(Format.Alternative);
        }

        private string[] GetReportColumns()
        {
            var properties = this.salesReport[0].GetType().GetProperties();
            var columns = properties.Select(property => property.Name).ToList();
            return columns.ToArray();
        }
    }
}
