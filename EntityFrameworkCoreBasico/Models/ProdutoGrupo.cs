using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkCore.Models
{
    public class ProdutoGrupo
    {
        public Guid ProdutoGrupoId { get; set; }
        public string Nome { get; set; }
        public virtual IList<Produto> Produtos { get; set; }
    }
}
