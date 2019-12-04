using Samples.InMemoryDatabase.SalesReport.App.Infra;
using Samples.InMemoryDatabase.SalesReport.App.Infra.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using QueryResults = Samples.InMemoryDatabase.SalesReport.App.Domain.QueryResults;

namespace Samples.InMemoryDatabase.SalesReport.App
{
    internal class Program
    {
        private const string CONNECTION_STRING =
            "Data Source=localhost,11433;Initial Catalog=SalesReportDatabase;User ID=sa;Password=DockerSql2017!;Integrated Security=False;multipleactiveresultsets=True;application name=SalesReport.App";

        private static void Main(string[] args)
        {
            MainAsync().GetAwaiter().GetResult();
            Console.ReadKey();
        }

        private static async Task MainAsync()
        {
            var salesReport = await GetSalesReport(CONNECTION_STRING);

            ShowReport(salesReport);
            ExportReport(salesReport);
        }

        private static async Task<IList<QueryResults.SalesReport>> GetSalesReport(string connectionString)
        {
            var databaseContext = new DatabaseContext(new SqlConnection(connectionString));
            var repository = new SalesReportRepository(databaseContext);
            var salesReport = await repository.GetSalesReportFromAllSellersAsync();
            return salesReport.ToList();
        }

        private static void ShowReport(IEnumerable<QueryResults.SalesReport> salesReport)
        {
            var printer = new SalesReportScreenPrinter(salesReport);
            printer.PrintReport();
        }

        private static void ExportReport(IEnumerable<QueryResults.SalesReport> salesReport)
        {
            var exportReportPath = BuildExportReportPath("sales-report.csv");
            var exporter = new SalesReportExporter(salesReport);
            exporter.ExportToCsv(exportReportPath);
        }

        private static string BuildExportReportPath(string fileName)
        {
            var currentPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            var exportPath = Path.Combine(currentPath, fileName);

            return exportPath;
        }
    }
}
