using System;
using FluentMigrator;

namespace Samples.InMemoryDatabase.SalesReport.Tests.Infra.Migrations
{
    [Migration(1)]
    public class CreateTestTablesMigration : Migration
    {
        public override void Up()
        {
            this.CreateTableProducts();
            this.CreateTableSellers();
            this.CreateTableSales();
        }

        private void CreateTableProducts()
        {
            this.Create.Table("Products")
                .WithColumn("Id").AsInt64().PrimaryKey().Identity()
                .WithColumn("Identifier").AsGuid().NotNullable()
                .WithColumn("Name").AsString(50).NotNullable()
                .WithColumn("Price").AsDecimal().NotNullable()
                .WithColumn("Description").AsString(500);

            this.Insert.IntoTable("Products")
                .Row(new { Identifier = Guid.NewGuid(), Name = "Cadeira Gamer", Price = 982.99, Description = "Cadeira Gamer Preta e Vermelha" })
                .Row(new { Identifier = Guid.NewGuid(), Name = "Monitor Gamer", Price = 1499.99, Description = "Monitor Gamer Widescreen 32 Polegadas" })
                .Row(new { Identifier = Guid.NewGuid(), Name = "Notebook Gamer", Price = 10890.99, Description = "Notebook Gamer i7, 32GB RAM, SDD 512, Placa de Vídeo NVIDIA GEFORCE 1060 GB GDDR5" });
        }

        private void CreateTableSellers()
        {
            this.Create.Table("Sellers")
                .WithColumn("Id").AsInt64().PrimaryKey().Identity()
                .WithColumn("Identifier").AsGuid().NotNullable()
                .WithColumn("FirstName").AsString(50).NotNullable()
                .WithColumn("LastName").AsString(50).NotNullable()
                .WithColumn("PhoneNumber").AsString(50).NotNullable()
                .WithColumn("Email").AsString(50).NotNullable();

            this.Insert.IntoTable("Sellers")
                .Row(new { Identifier = Guid.NewGuid(), FirstName = "John", LastName = "Doe", PhoneNumber = "+5511998997889", Email = "john.doe@saller.com" })
                .Row(new { Identifier = Guid.NewGuid(), FirstName = "Mary", LastName = "Jane", PhoneNumber = "+5511997668976", Email = "mary.jane@saller.com" });
        }

        private void CreateTableSales()
        {
            this.Create.Table("Sales")
                .WithColumn("Id").AsInt64().PrimaryKey().Identity()
                .WithColumn("Identifier").AsGuid().NotNullable()
                .WithColumn("SellerId").AsInt64().ForeignKey("SellerFk", "Sellers", "Id")
                .WithColumn("ProductId").AsInt64().ForeignKey("ProductFk", "Products", "Id")
                .WithColumn("Quantity").AsInt64().NotNullable();

            this.Insert.IntoTable("Sales")
                .Row(new { Identifier = Guid.NewGuid(), SellerId = 1, ProductId = 1, Quantity = 3 })
                .Row(new { Identifier = Guid.NewGuid(), SellerId = 1, ProductId = 2, Quantity = 2 })
                .Row(new { Identifier = Guid.NewGuid(), SellerId = 1, ProductId = 3, Quantity = 1 })
                .Row(new { Identifier = Guid.NewGuid(), SellerId = 2, ProductId = 3, Quantity = 1 })
                .Row(new { Identifier = Guid.NewGuid(), SellerId = 2, ProductId = 2, Quantity = 2 })
                .Row(new { Identifier = Guid.NewGuid(), SellerId = 2, ProductId = 1, Quantity = 3 });
        }

        public override void Down()
        {
            this.Delete.Table("Products");
            this.Delete.Table("Sellers");
            this.Delete.Table("Sales");
        }
    }
}
