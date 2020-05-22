using Exercicios.Entidades;
using Exercicios.Formatos.Enum;
using Exercicios.Formatos.Interface;

namespace Exercicios.Formatos
{
    public class FormatoInvalido : IFormato
    {
        public IFormato ProximoFormato { get; set; }

        public string FormatoDesejado(Formato formato, Conta conta)
        {
            return "Formato inválido";
        }
    }
}