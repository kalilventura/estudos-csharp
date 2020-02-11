using CursoDesignPatterns.Entidades;

namespace CursoDesignPatterns.Impostos
{
    public class Icms : Imposto
    {
        public double Calcular(Orcamento orcamento)
        {
            return orcamento.Valor * 0.1;
        }
    }
}