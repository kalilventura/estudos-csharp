using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Samples.InMemoryDatabase.SalesReport.App.Infra
{
    public class SalesReportExporter
    {
        private readonly IList<Domain.QueryResults.SalesReport> salesReport;
        public SalesReportExporter(IEnumerable<Domain.QueryResults.SalesReport> salesReport) 
            => this.salesReport = salesReport.ToList();

        public void ExportToCsv(string exportPath)
        {
            using (var writer = new StreamWriter(exportPath))
            {
                using (var csv = new CsvWriter(writer))
                {
                    csv.WriteRecords(this.salesReport);
                }
            }
            Console.WriteLine($"Report was exported to: { exportPath }");
        }
    }
}
