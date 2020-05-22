using Exercicios.Entidades;
using Exercicios.Formatos.Enum;

namespace Exercicios.Formatos.Interface
{
    public interface IFormato
    {
         string FormatoDesejado(Formato formato, Conta conta);
         IFormato ProximoFormato { get; set; }
    }
}