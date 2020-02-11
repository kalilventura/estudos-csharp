namespace CursoDesignPatterns
{
    public class Icms : Imposto
    {
        public double Calcular(Orcamento orcamento)
        {
            return orcamento.Valor * 0.1;
        }
    }
}