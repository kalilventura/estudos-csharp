using Exercicio01.Entidades;
using Exercicio01.Formatos.Enum;
using Exercicio01.Formatos.Interface;

namespace Exercicio01.Formatos
{
    public class FormatoXml : IFormato
    {
        public IFormato ProximoFormato { get; set; }

        public string FormatoDesejado(Formato formato, Conta conta)
        {
            if(Formato.XML == formato)
                return $"<conta><titular>{conta.Titular}</titular><saldo>{conta.Saldo}</saldo></conta>";
            
            return ProximoFormato.FormatoDesejado(formato, conta);
        }
    }
}