using Projeto01.Library.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto01.Models
{
    public class Palavra
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Digite o nome corretamente.")]
        [MaxLength(70,ErrorMessage ="O campo 'Nome' deve conter no máximo 70 caracteres.")]
        [UnicoNomePalavra]
        public string Nome { get; set; }

        //1 - fácil, 2 - médio, 3 - dificil
        [Required(ErrorMessage ="Digite o nível corretamente.")]
        public byte? Nivel { get; set; }
    }
}
