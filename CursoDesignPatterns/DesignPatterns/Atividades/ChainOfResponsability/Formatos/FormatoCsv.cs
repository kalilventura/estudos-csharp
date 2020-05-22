using Exercicios.Entidades;
using Exercicios.Formatos.Enum;
using Exercicios.Formatos.Interface;

namespace Exercicios.Formatos
{
    public class FormatoCsv : IFormato
    {
        public IFormato ProximoFormato { get; set; }

        public string FormatoDesejado(Formato formato, Conta conta)
        {
            if (Formato.CSV == formato)
                return $"{conta.Titular};{conta.Saldo}";

            return ProximoFormato.FormatoDesejado(formato, conta);
        }
    }
}