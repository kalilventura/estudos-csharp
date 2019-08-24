using System;
using System.Collections.Generic;
using System.Text;

namespace Switch.Domain.Entities
{
    public class InstituicaoEnsino
    {
        public int Id { get; set; }
        public int UsuarioID { get; set; }
        public virtual Usuario Usuario { get; set; }
        public string Instituicao { get; set; }
        public DateTime? AnoFormacao { get; set; }
        
    }
}
