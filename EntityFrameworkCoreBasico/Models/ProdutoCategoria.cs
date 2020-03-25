using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkCore.Models
{
    public class ProdutoCategoria
    {
        public Guid ProdutoCategoriaId { get; set; }

        public Guid ProdutoId { get; set; }
        public virtual Produto Produto { get; set; }

        public Guid CategoriaId { get; set; }
        public virtual Categoria Categoria { get; set; }
    }
}
