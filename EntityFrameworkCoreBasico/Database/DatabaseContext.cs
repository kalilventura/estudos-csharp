using EntityFrameworkCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkCore.Database
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<ProdutoGrupo> ProdutosGrupos { get; set; }

        // Quando há esse tipo de configuração, ele irá criar uma Tabela chamada Pessoas e
        // utilizara um Discriminator para separar qual será PF e PJ
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<PessoaFisica> PessoasFisicas { get; set; }
        public DbSet<PessoaJuridica> PessoasJuridicas { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

        // Relacionamento NxN
        public DbSet<ProdutoCategoria> ProdutosCategorias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Chave Composta da tabela ProdutoCategorias
            modelBuilder
                .Entity<ProdutoCategoria>()
                .HasKey(x => new { x.ProdutoCategoriaId });

            base.OnModelCreating(modelBuilder);
        }
    }
}
