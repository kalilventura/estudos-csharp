namespace CursoDesignPatterns
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