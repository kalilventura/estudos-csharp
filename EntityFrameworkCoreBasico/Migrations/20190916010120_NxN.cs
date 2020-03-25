using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFrameworkCore.Migrations
{
    public partial class NxN : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProdutoCategorias_Categoria_CategoriaId",
                table: "ProdutoCategorias");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProdutoCategorias",
                table: "ProdutoCategorias");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categoria",
                table: "Categoria");

            migrationBuilder.RenameTable(
                name: "Categoria",
                newName: "Categorias");

            migrationBuilder.AddColumn<Guid>(
                name: "ProdutoCategriaId",
                table: "ProdutoCategorias",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProdutoCategorias",
                table: "ProdutoCategorias",
                column: "ProdutoCategriaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categorias",
                table: "Categorias",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_ProdutoCategorias_ProdutoId",
                table: "ProdutoCategorias",
                column: "ProdutoId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProdutoCategorias_Categorias_CategoriaId",
                table: "ProdutoCategorias",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "CategoriaId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProdutoCategorias_Categorias_CategoriaId",
                table: "ProdutoCategorias");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProdutoCategorias",
                table: "ProdutoCategorias");

            migrationBuilder.DropIndex(
                name: "IX_ProdutoCategorias_ProdutoId",
                table: "ProdutoCategorias");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categorias",
                table: "Categorias");

            migrationBuilder.DropColumn(
                name: "ProdutoCategriaId",
                table: "ProdutoCategorias");

            migrationBuilder.RenameTable(
                name: "Categorias",
                newName: "Categoria");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProdutoCategorias",
                table: "ProdutoCategorias",
                columns: new[] { "ProdutoId", "CategoriaId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categoria",
                table: "Categoria",
                column: "CategoriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProdutoCategorias_Categoria_CategoriaId",
                table: "ProdutoCategorias",
                column: "CategoriaId",
                principalTable: "Categoria",
                principalColumn: "CategoriaId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
