using Dapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using QueryResults = Samples.InMemoryDatabase.SalesReport.App.Domain.QueryResults;

namespace Samples.InMemoryDatabase.SalesReport.App.Infra.Repositories
{
    public class SalesReportRepository : ISalesReportRepository
    {
        private readonly IDatabaseContext databaseContext;
        public SalesReportRepository(IDatabaseContext databaseContext) => this.databaseContext = databaseContext;

        public Task<IEnumerable<QueryResults.SalesReport>> GetSalesReportFromAllSellersAsync()
        {
            const string SALES_REPORT_QUERY = @"SELECT
                                                    CAST(Sales.Identifier AS VARCHAR(36)) AS 'SaleIdentifier', 
                                                    Products.Name AS 'ProductName', 
                                                    Products.Price AS 'UnitPrice',
                                                    Sales.Quantity 'SoldAmount', 
                                                    (Products.Price * Sales.Quantity) AS 'TotalSaleAmount',
                                                    CAST(Sellers.Identifier AS VARCHAR(36)) AS 'SellerIdentifier',
                                                    Sellers.FirstName + ' ' + Sellers.LastName AS 'SellerName',
                                                    Sellers.Email AS 'SellerEmail'
                                                FROM Sales
                                                    INNER JOIN Products ON Sales.ProductId = Products.Id
                                                    INNER JOIN Sellers ON Sales.SellerId = Sellers.Id";

            return this.databaseContext.Connection.QueryAsync<QueryResults.SalesReport>(SALES_REPORT_QUERY);
        }

        public Task<IEnumerable<QueryResults.SalesReport>> GetSalesReportFromSallerByIdentifierAsync(string sellerIdentifier)
        {
            const string SALES_REPORT_QUERY = @"SELECT
                                                    CAST(Sales.Identifier AS VARCHAR(36)) AS 'SaleIdentifier', 
                                                    Products.Name AS 'ProductName', 
                                                    Products.Price AS 'UnitPrice',
                                                    Sales.Quantity 'SoldAmount', 
                                                    (Products.Price * Sales.Quantity) AS 'TotalSaleAmount',
                                                    CAST(Sellers.Identifier AS VARCHAR(36)) AS 'SellerIdentifier',
                                                    Sellers.FirstName + ' ' + Sellers.LastName AS 'SellerName',
                                                    Sellers.Email AS 'SellerEmail'
                                                FROM Sales
                                                    INNER JOIN Products ON Sales.ProductId = Products.Id
                                                    INNER JOIN Sellers ON Sales.SellerId = Sellers.Id
                                                WHERE Sellers.Identifier = @SellerIdentifier";

            return this.databaseContext.Connection.QueryAsync<QueryResults.SalesReport>(SALES_REPORT_QUERY, new { SellerIdentifier = sellerIdentifier });            
        }
    }
}
