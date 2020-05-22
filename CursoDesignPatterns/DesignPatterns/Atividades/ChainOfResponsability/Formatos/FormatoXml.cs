using Exercicios.Entidades;
using Exercicios.Formatos.Enum;
using Exercicios.Formatos.Interface;

namespace Exercicios.Formatos
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