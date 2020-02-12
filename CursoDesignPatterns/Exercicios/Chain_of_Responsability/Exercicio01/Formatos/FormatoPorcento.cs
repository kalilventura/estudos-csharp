using Exercicio01.Entidades;
using Exercicio01.Formatos.Enum;
using Exercicio01.Formatos.Interface;

namespace Exercicio01.Formatos
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