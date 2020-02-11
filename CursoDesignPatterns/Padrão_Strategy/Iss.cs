namespace CursoDesignPatterns
{
    public class Iss : Imposto
    {
        public double Calcular(Orcamento orcamento)
        {
            return orcamento.Valor * 0.06;
        }
    }
}