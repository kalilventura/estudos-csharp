using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Projeto01.Models
{
    public class Usuario
    {
        [Required(ErrorMessage = "O campo 'Email' é obrigatório!")]
        [EmailAddress(ErrorMessage = "O campo 'E-mail' é inválido!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "O campo 'Senha' é obrigatório!")]
        public string Senha { get; set; }

    }
}