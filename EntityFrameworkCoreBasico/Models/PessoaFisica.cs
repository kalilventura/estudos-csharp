using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkCore.Models
{
    public class PessoaFisica : Pessoa
    {
        public Sexo Sexo { get; set; }
    }
}
