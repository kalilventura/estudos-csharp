using CursoDesignPatterns.Entidades;

namespace CursoDesignPatterns.Impostos
{
    public class CalculadorDeImpostos
    {
        public void RealizarCalculo(Orcamento orcamento, Imposto imposto)
        {
            double impostoCalculado = imposto.Calcular(orcamento);
            System.Console.WriteLine(impostoCalculado);
        }
    }
}