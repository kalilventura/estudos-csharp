using CursoDesignPatterns.Entidades;

namespace CursoDesignPatterns.Impostos
{
    public class Iss : Imposto
    {
        public double Calcular(Orcamento orcamento)
        {
            return orcamento.Valor * 0.06;
        }
    }
}