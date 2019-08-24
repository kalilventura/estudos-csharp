using System;
using System.Collections.Generic;
using System.Text;

namespace Switch.Domain.Entities
{
    public class LocalTrabalho
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public string NomeEmpresa { get; set; }
        public DateTime DataAdmissao { get; set; }
        public DateTime? DataSaida { get; set; }
        public bool EmpresaAtual { get; set; }
    }
}
