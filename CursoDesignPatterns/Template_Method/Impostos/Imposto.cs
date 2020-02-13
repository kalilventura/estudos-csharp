using CursoDesignPatterns.Entidades;

namespace CursoDesignPatterns.Impostos
{
    public interface Imposto
    {
        double Calcular(Orcamento orcamento);
    }
}