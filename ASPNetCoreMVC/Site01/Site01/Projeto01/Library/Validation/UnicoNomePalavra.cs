using Projeto01.Database;
using Projeto01.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto01.Library.Validation
{
    public class UnicoNomePalavra : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            Palavra palavra = validationContext.ObjectInstance as Palavra;

            var _db = (DatabaseContext)validationContext.GetService(typeof(DatabaseContext));

            //Já existe no banco um registro que tenha o nome que estamos inserindo e o id seja diferente
            var palavraBanco = _db.Palavras.Where(a => a.Nome == palavra.Nome && a.Id != palavra.Id).FirstOrDefault();

            if (palavraBanco == null)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("A palavra '" + palavra.Nome + "' já existe!");
            }
        }
    }
}
