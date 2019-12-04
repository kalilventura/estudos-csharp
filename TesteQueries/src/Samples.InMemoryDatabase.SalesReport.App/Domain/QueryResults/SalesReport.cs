namespace Samples.InMemoryDatabase.SalesReport.App.Domain.QueryResults
{
    public class SalesReport
    {
        public string SaleIdentifier { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int SoldAmount { get; set; }
        public decimal TotalSaleAmount { get; set; }
        public string SellerIdentifier { get; set; }
        public string SellerName { get; set; }
        public string SellerEmail { get; set; }

        public override string ToString() => string.Join(",", 
                                                         this.SaleIdentifier, 
                                                         this.ProductName, 
                                                         this.UnitPrice, 
                                                         this.SoldAmount, 
                                                         this.TotalSaleAmount, 
                                                         this.SellerIdentifier, 
                                                         this.SellerName, 
                                                         this.SellerEmail);
    }
}
