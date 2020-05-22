using Exercicios.Entidades;
using Exercicios.Formatos.Enum;
using Exercicios.Formatos.Interface;

namespace Exercicios.Formatos
{
    public class FormatoPorcento : IFormato
    {
        public IFormato ProximoFormato { get; set; }

        public string FormatoDesejado(Formato formato, Conta conta)
        {
            if(Formato.PORCENTO == formato)
                return $"{conta.Titular}%{conta.Saldo}";

            return ProximoFormato.FormatoDesejado(formato, conta);
        }
    }
}