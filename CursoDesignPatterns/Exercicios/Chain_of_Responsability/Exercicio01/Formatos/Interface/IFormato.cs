using Exercicio01.Entidades;
using Exercicio01.Formatos.Enum;

namespace Exercicio01.Formatos.Interface
{
    public interface IFormato
    {
         string FormatoDesejado(Formato formato, Conta conta);
         IFormato ProximoFormato { get; set; }
    }
}