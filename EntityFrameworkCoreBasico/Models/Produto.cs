using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkCore.Models
{
    public class Produto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }

        //Foreign Key
        public Guid ProdutoGrupoId { get; set; }
        // Referencia a outra tabela
        public virtual ProdutoGrupo ProdutoGrupo { get; set; }
        public virtual ICollection<ProdutoCategoria> ProdutoCategorias { get; set; }
    }
}
