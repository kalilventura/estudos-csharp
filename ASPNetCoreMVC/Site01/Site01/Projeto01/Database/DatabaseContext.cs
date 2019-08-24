using Microsoft.EntityFrameworkCore;
using Projeto01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto01.Database
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Palavra> Palavras { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            //EF - Garantir que o banco de dados seja criado
            Database.EnsureCreated();

        }
    }
}
