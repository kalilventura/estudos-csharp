using Exercicios.Entidades;

namespace Exercicios.Formatos
{
    public class VerificaFormato
    {
        public string Verificar(Requisicao requisicao, Conta conta)
        {
            var formatoXml = new FormatoXml();
            var formatoPorcento = new FormatoPorcento();
            var formatoCsv = new FormatoCsv();
            var formatoInvalido = new FormatoInvalido();

            formatoXml.ProximoFormato = formatoPorcento;
            formatoPorcento.ProximoFormato = formatoCsv;
            formatoCsv.ProximoFormato = formatoInvalido;

            return formatoXml.FormatoDesejado(requisicao.Formato, conta);
        }
    }
}